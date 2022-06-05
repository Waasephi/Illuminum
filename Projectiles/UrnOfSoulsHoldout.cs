using Illuminum.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles
{
	public class UrnOfSoulsHoldout : ModProjectile
	{

		// The vanilla Last Prism is an animated item with 5 frames of animation. We copy that here.
		private const int NumAnimationFrames = 1;

		// This value controls how sluggish the Prism turns while being used. Vanilla Last Prism is 0.08f.
		// Higher values make the Prism turn faster.
		private const float AimResponsiveness = 0.15f;

		public const int NumBeams = 5;

		private const int SoundInterval = 20;

		// This property encloses the internal AI variable projectile.ai[0]. It makes the code easier to read.
		private float FrameCounter
		{
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		// This property encloses the internal AI variable projectile.localAI[0].
		// localAI is not automatically synced over the network, but that does not cause any problems in this case.

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Urn of Souls");
			Main.projFrames[Projectile.type] = NumAnimationFrames;

			// Signals to Terraria that this projectile requires a unique identifier beyond its index in the projectile array.
			// This prevents the issue with the vanilla Last Prism where the beams are invisible in multiplayer.
			ProjectileID.Sets.NeedsUUID[Projectile.type] = true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true);

			// Update the Prism's position in the world and relevant variables of the player holding it.
			UpdatePlayerVisuals(player, rrp);

			// Update the Prism's behavior: project beams on frame 1, consume mana, and despawn if out of mana.
			if (Projectile.owner == Main.myPlayer)
			{
				// Slightly re-aim the Prism every frame so that it gradually sweeps to point towards the mouse.
				UpdateAim(rrp, player.HeldItem.shootSpeed);
			}

			// The Prism immediately stops functioning if the player is Cursed (player.noItems) or "Crowd Controlled", e.g. the Frozen debuff.
			// player.channel indicates whether the player is still holding down the mouse button to use the item.
			bool stillInUse = player.channel && !player.noItems && !player.CCed;

			Projectile.tileCollide = false;

			Projectile.ai[0]++;
			Projectile.DamageType = DamageClass.Ranged;

			if (Projectile.ai[0] > 20f && stillInUse)
            {
				Vector2 launchVelocity = new Vector2(0, 0);
				launchVelocity = Projectile.velocity;
				SoundEngine.PlaySound(SoundID.Item103, Projectile.position);
				Projectile.ai[0] = 0;
				Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.Center, launchVelocity, ProjectileID.LostSoulFriendly, Projectile.damage, Projectile.knockBack, Projectile.owner);				
            }


			if (player.channel == false)
            {
				Projectile.Kill();
            }

			// This ensures that the Prism never times out while in use.
			Projectile.timeLeft = 2;
		}

		private void UpdatePlayerVisuals(Player player, Vector2 playerHandPos)
		{
			// Place the Prism directly into the player's hand at all times.
			Projectile.Center = playerHandPos;
			// The beams emit from the tip of the Prism, not the side. As such, rotate the sprite by pi/2 (90 degrees).
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Projectile.spriteDirection = Projectile.direction;

			// The Prism is a holdout projectile, so change the player's variables to reflect that.
			// Constantly resetting player.itemTime and player.itemAnimation prevents the player from switching items or doing anything else.
			player.ChangeDir(Projectile.direction);
			player.heldProj = Projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;

			// If you do not multiply by projectile.direction, the player's hand will point the wrong direction while facing left.
			player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();
		}

		private void UpdateAim(Vector2 source, float speed)
		{
			// Get the player's current aiming direction as a normalized vector.
			Vector2 aim = Vector2.Normalize(Main.MouseWorld - source);
			if (aim.HasNaNs())
			{
				aim = -Vector2.UnitY;
			}

			// Change a portion of the Prism's current velocity so that it points to the mouse. This gives smooth movement over time.
			aim = Vector2.Normalize(Vector2.Lerp(Vector2.Normalize(Projectile.velocity), aim, AimResponsiveness));
			aim *= speed;

			if (aim != Projectile.velocity)
			{
				Projectile.netUpdate = true;
			}
			Projectile.velocity = aim;
		}

		// Because the Prism is a holdout projectile and stays glued to its user, it needs custom drawcode.
		public override bool PreDraw(ref Color lightColor)
		{
			// SpriteEffects helps to flip texture horizontally and vertically
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (Projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			// Getting texture of projectile
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

			// Calculating frameHeight and current Y pos dependence of frame
			// If texture without animation frameHeight is always texture.Height and startY is always 0
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int startY = frameHeight * Projectile.frame;

			// Get this frame on texture
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

			// Alternatively, you can skip defining frameHeight and startY and use this:
			// Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Projectile.type], frameY: Projectile.frame);

			Vector2 origin = sourceRectangle.Size() / 2f;

			// If image isn't centered or symmetrical you can specify origin of the sprite
			// (0,0) for the upper-left corner
			/*float offsetX = 16f;
			float offsetY = 24f;
			origin.X = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX);
			origin.Y = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetY : offsetY);*/

			// If sprite is vertical
			// float offsetY = 20f;
			// origin.Y = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Height - offsetY : offsetY);


			// Applying lighting and draw current frame
			Color drawColor = Projectile.GetAlpha(lightColor);
			Main.EntitySpriteDraw(texture,
				Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
				sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

			// It's important to return false, otherwise we also draw the original texture.
			return false;
		}
	}
}