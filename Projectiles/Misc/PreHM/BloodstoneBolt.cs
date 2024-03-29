using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Illuminum.Projectiles.Misc.PreHM
{
	public class BloodstoneBolt : ModProjectile
	{
		public float start = 0;

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.aiStyle = 0;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.penetrate = 1;      //this is how many enemy this projectile penetrate before disappear
			Projectile.extraUpdates = 1;
			AIType = 507;
			Projectile.timeLeft = 600;
			Main.projFrames[Projectile.type] = 1;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
		}

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

        public override void AI()
		{
			start = MathHelper.Lerp(start, 6, 0.05f);
			Projectile.ai[0] += 1f;
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
			Projectile.localAI[0] += 1f;
			if (Projectile.ai[0] >= 300f)       //how much time the projectile can travel before landing
			{
				Projectile.velocity.X = Projectile.velocity.X * 1.5f;    // projectile velocity
				Projectile.Kill();
            }
            if (Projectile.ai[1] == 1)
			{
				if (Projectile.ai[0] > 20)
				{
					Projectile.velocity.X *= 0.98f;
					Projectile.velocity.Y += 0.18f;
				}
			}
			if (Projectile.ai[1] == 2)
            {
				Player projOwner = Main.player[Projectile.owner];

				if (projOwner.itemAnimation > projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
				{
					Projectile.position += projOwner.velocity / 6; 
				}
				if (projOwner.itemAnimation == (float)Math.Floor((decimal)projOwner.itemAnimationMax / 3))
				{
					Projectile.velocity *= 2.4f;
					Projectile.velocity.X += Main.rand.NextFloat(-2f, 2f);
					Projectile.velocity.Y += Main.rand.NextFloat(-2f, 2f);
				}
            }
        }



        public override bool PreDraw(ref Color lightColor)
        {
                 
	
			for (int i = 1; i < Projectile.oldPos.Length; i++)
			{
				Projectile.oldPos[i] = Projectile.oldPos[i - 1] + (Projectile.oldPos[i] - Projectile.oldPos[i - 1]).SafeNormalize(Vector2.Zero) * MathHelper.Min(Vector2.Distance(Projectile.oldPos[i - 1], Projectile.oldPos[i]), start);
			}

			Main.spriteBatch.End();
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
			{
				Color col = Color.Pink;
				col.A = 255;
				for (int i = 0; i < Projectile.oldPos.Length; i++)
				{
					Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, Projectile.oldPos[i] + new Vector2(Projectile.width / 2, Projectile.height / 2) - Main.screenPosition,
					new Rectangle(0, 0, 16, 16), col, Projectile.rotation,
					new Vector2(16 * 0.5f, 16 * 0.5f), Vector2.Lerp(new Vector2(0.5f, 0.5f), new Vector2(0, 0), i / (float)Projectile.oldPos.Length), SpriteEffects.None, 0f);
				}

				Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, Projectile.position + new Vector2(Projectile.width / 2, Projectile.height / 2) - Main.screenPosition,
				   new Rectangle(0, 0, 16, 16), col, Projectile.rotation,
				   new Vector2(16 * 0.5f, 16 * 0.5f), 1f, SpriteEffects.None, 0f);
				
			}
			return base.PreDraw(ref lightColor);
		}

		public override void PostDraw(Color drawColor)
		{
			Main.spriteBatch.End();
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
		}

		public override void Kill(int timeLeft)
		{

			for (int num623 = 0; num623 < 50; num623++)
			{
				int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.PinkFairy, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 1.5f;
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{                                                           // sound that the projectile make when hitting the terrain
			{
				Projectile.Kill();
			}
			return false;
		}
	}
}