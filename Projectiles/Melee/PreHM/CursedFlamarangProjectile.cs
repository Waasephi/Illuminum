using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles.Melee.PreHM
{
	public class CursedFlamarangProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			 DisplayName.SetDefault("Cursed Flamarang");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 20;
			Projectile.height = 32;
			Projectile.aiStyle = 3;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.MeleeNoSpeed;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 3000;
			Projectile.light = 0.5f;
			Projectile.extraUpdates = 1;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (Main.rand.NextBool(4))
				target.AddBuff(BuffID.CursedInferno, 60);
		}

		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch);
				dust.noGravity = true;
				dust.scale = 2f;
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

			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
			}
			return false;
		}
	}
}