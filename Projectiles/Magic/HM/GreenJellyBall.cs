using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Projectiles.Magic.HM
{
	public class GreenJellyBall : ModProjectile
	{
		private int Bounces;

		public override void SetStaticDefaults()
		{
			 DisplayName.SetDefault("Green Jelly Ball");
		}

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 4;
			Projectile.aiStyle = 2;
			Bounces = 4;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Electrified, 120);
		}

		public override void Kill(int timeLeft)
		{
			{
				SoundEngine.PlaySound(SoundID.Item94, Projectile.position);
				SoundEngine.PlaySound(SoundID.Item85, Projectile.position);
				Vector2 usePos = Projectile.position;
				Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
				Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.position, Vector2.Zero, ProjectileID.Electrosphere, 40, 0, Projectile.owner);
				Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();

				for (int num623 = 0; num623 < 50; num623++)
				{
					int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.BubbleBurst_Green, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num624].noGravity = true;
					Main.dust[num624].velocity *= 1.5f;
				}
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Bounces > 0)
			{
				SoundEngine.PlaySound(SoundID.Item94, Projectile.position);
				Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.position, Vector2.Zero, ProjectileID.Electrosphere, 30, 0, Projectile.owner);
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item56, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X + 0.5f;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y + 0.5f;
				}
				//Projectile.penetrate -= 1;
				Bounces -= 1;
				return false;
			}
			return base.OnTileCollide(oldVelocity);
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric);
				dust.noGravity = true;
				dust.scale *= 0.75f;
			}
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int height = texture.Height;
			int y = height * Projectile.frame;
			Rectangle rect = new(0, y, texture.Width, height);
			Vector2 origin = new(texture.Width, Projectile.height);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + origin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(Color.White) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.EntitySpriteDraw(texture, drawPos, new Rectangle?(rect), color, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
			}
			return true;
		}
	}
}