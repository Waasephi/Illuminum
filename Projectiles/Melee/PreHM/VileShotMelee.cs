using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Illuminum.Projectiles.Misc.PreHM;

namespace Illuminum.Projectiles.Melee.PreHM
{
	public class VileShotMelee : ModProjectile
	{
		public float start = 0;

		public override void SetDefaults()
		{
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.penetrate = 1;                       //this is the projectile penetration
            Main.projFrames[Projectile.type] = 1;           //this is projectile frames
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.aiStyle = 2;
            Projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            Projectile.ignoreWater = false;
        }

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}
        public override bool? CanHitNPC(NPC target)
        {
            return Projectile.ai[0] >= 60;
        }
		public override void AI()
		{
            Projectile.ai[0]++;
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
				Color col = Color.Green;
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
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
                target.AddBuff(BuffID.Poisoned, 60);
        }

        public override void Kill(int timeLeft)
		{

			for (int num623 = 0; num623 < 50; num623++)
			{
				int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Poisoned, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 1.5f;
				
			}
			SoundEngine.PlaySound(SoundID.NPCDeath1, Projectile.position);
            Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.position, Vector2.Zero, ModContent.ProjectileType<VileShotSplash>(), Projectile.damage / 2, 0, Projectile.owner);
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