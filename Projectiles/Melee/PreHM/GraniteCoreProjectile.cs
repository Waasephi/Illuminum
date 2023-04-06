using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Projectiles.Melee.PreHM
{
	public class GraniteCoreProjectile : ModProjectile
	{
		int firing = 1;
		int fireTimer = 0;
		public override void SetStaticDefaults()
		{
			// The following sets are only applicable to yoyo that use aiStyle 99.
			// YoyosLifeTimeMultiplier is how long in seconds the yoyo will stay out before automatically returning to the player.
			// Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 10f;
			// YoyosMaximumRange is the maximum distance the yoyo sleep away from the player.
			// Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 200f;
			// YoyosTopSpeed is top speed of the yoyo projectile.
			// Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 15f;
		}

		public override void SetDefaults()
		{
			Projectile.extraUpdates = 0;
			Projectile.width = 18;
			Projectile.height = 18;
			// aiStyle 99 is used for all yoyos, and is Extremely suggested, as yoyo are extremely difficult without them
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 1f;
		}

		// notes for aiStyle 99:
		// localAI[0] is used for timing up to YoyosLifeTimeMultiplier
		// localAI[1] can be used freely by specific types
		// ai[0] and ai[1] usually point towards the x and y world coordinate hover point
		// ai[0] is -1f once YoyosLifeTimeMultiplier is reached, when the player is stoned/frozen, when the yoyo is too far away, or the player is no longer clicking the shoot button.
		// ai[0] being negative makes the yoyo move back towards the player
		// Any AI method can be used for dust, spawning projectiles, etc specific to your yoyo.
		public override void AI()
		{
			Projectile.rotation -= 10f;

			if (firing == 1)
			{
				if (fireTimer == 30 * 2)
				{
					Vector2 v0 = Projectile.Center;
					Vector2 v0s = Main.MouseWorld - v0;
					v0s = v0s / v0s.Length() * 22f;
					Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), v0, v0s, ProjectileID.MagnetSphereBolt, Projectile.damage, 1, Main.myPlayer, Projectile.ai[0], 0f);
					SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
					fireTimer = 0;
					return;
				}
				fireTimer++;
			}
		}

		public override bool PreAI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 60)
			{
				Projectile.frameCounter = 0;
				float num = 2000f;
				int num2 = -1;
				for (int i = 0; i < 200; i++)
				{
					float num3 = Vector2.Distance(Projectile.Center, Main.npc[i].Center);
					if (num3 < num && num3 < 640f && Main.npc[i].CanBeChasedBy(Projectile, false))
					{
						num2 = i;
						num = num3;
					}
				}

				if (num2 != -1)
				{
					bool flag = Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[num2].position, Main.npc[num2].width, Main.npc[num2].height);
					if (flag)
					{
						Vector2 value = Main.npc[num2].Center - Projectile.Center;
						float num4 = 3f;
						float num5 = (float)Math.Sqrt((double)(value.X * value.X + value.Y * value.Y));
						if (num5 > num4)
						{
							num5 = num4 / num5;
						}
						value *= num5;	
					}
				}
			}
			return true;
		}

		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D glow = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture + "_Glow").Value;
			var effects = Projectile.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			int height = texture.Height;
			int y = height * Projectile.frame;
			Rectangle rect = new(0, y, texture.Width, height);
			Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Rectangle?(rect), lightColor, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(glow, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);

			return false;
		}
	}
}