using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Illuminum.Projectiles.Melee.HM
{
	public class RadianceProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.friendly = true;
			Projectile.aiStyle = 0;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 5;      //this is how many enemy this projectile penetrate before disappear
			Projectile.extraUpdates = 1;
			AIType = 507;
			Main.projFrames[Projectile.type] = 1;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
		}

		public override void SetStaticDefaults()
		{
			 DisplayName.SetDefault("Radiance");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void AI()
		{
			Projectile.ai[0]++;

			if (Projectile.ai[0] == 20)
            {
				Projectile.velocity *= 0.5f;
				Projectile.penetrate = 1;


				for (int i = 0; i < Projectile.oldPos.Length; i++)
				{
					for (int k = 0; k < 8; k++)
                    {
						Dust dust;
						// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
						Vector2 position = Projectile.oldPos[i];
						dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, DustID.SolarFlare, 0f, 0f, 0, new Color(255, 255, 255), 0.828947f)];
						dust.noGravity = true;
					}
				}
			}
			if (Projectile.ai[0] > 20)
            {
				Projectile.velocity.Y += 0.1f;
            }
            else
            {
				Projectile.velocity *= 1.01f;
			}

			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
		}

        public override Color? GetAlpha(Color lightColor)
		{
			if (Projectile.ai[0] < 20) return Color.Yellow;
			else return Color.Yellow;
		}
		// help me loco
        public override bool PreDraw(ref Color lightColor)
		{
			Main.spriteBatch.End();
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
			if (Projectile.ai[0] < 20)
			{
				for (int i = 0; i < Projectile.oldPos.Length; i++)
				{
					Color col = Color.Yellow;
					col.A = 255;
					Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, Projectile.oldPos[i] + new Vector2(Projectile.width / 2, Projectile.height / 2) - Main.screenPosition,
					new Rectangle(0, 0, 14, 30), col, Projectile.rotation,
					new Vector2(10 * 0.5f, 10 * 0.5f), Vector2.Lerp(new Vector2(1, 1), new Vector2(1, 0.3f), i / Projectile.oldPos.Length), SpriteEffects.None, 0f);
					Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, Vector2.Lerp(Projectile.oldPos[i], Projectile.oldPos[(int)MathHelper.Clamp(i - 1, 0, Projectile.oldPos.Length)], 0.5f) + new Vector2(Projectile.width / 2, Projectile.height / 2) - Main.screenPosition,
					new Rectangle(0, 0, 14, 30), col, Projectile.rotation,
					new Vector2(10 * 0.5f, 10 * 0.5f), Vector2.Lerp(new Vector2(1, 1), new Vector2(1, 0.3f), i / Projectile.oldPos.Length), SpriteEffects.None, 0f);
				}
			}
			else
			{
				for (int i = 0; i < Projectile.oldPos.Length / 2; i++)
				{
					Color col = Color.Orange;
					col.A = 255;
					Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, Projectile.oldPos[i] + new Vector2(Projectile.width / 2, Projectile.height / 2) - Main.screenPosition,
					new Rectangle(0, 0, 14, 30), col, Projectile.rotation,
					new Vector2(10 * 0.5f, 10 * 0.5f), Vector2.Lerp(new Vector2(1, 1), new Vector2(1, 0.3f), i / Projectile.oldPos.Length / 2), SpriteEffects.None, 0f);
				}
			}
			return true;
		}

		public override void PostDraw(Color lightColor)
		{
			Main.spriteBatch.End();
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			return false;
		}
	}
}