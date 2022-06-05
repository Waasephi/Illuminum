using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles
{
	class BrimstoneWave : ModProjectile
	{
		int timer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brimstone Wave");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.timeLeft = 210;
			Projectile.height = 20;
			Projectile.width = 30;
			Projectile.penetrate = 5;
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 1;
		}

        public override void AI()
        {
			Projectile.ai[0]++;
			if (Projectile.ai[1] == 3) Projectile.velocity = Projectile.velocity.RotatedBy(Math.Cos(Projectile.ai[0] * 0.1f) * MathHelper.ToRadians(2f));
			if (Projectile.ai[1] == 4) Projectile.velocity = Projectile.velocity.RotatedBy(Math.Cos(Projectile.ai[0] * 0.1f) * MathHelper.ToRadians(-2f));
			if (Projectile.ai[1] < 3)
            {
				Projectile.velocity *= 0.97f;
				if (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) / 2 < 0.2f)
                {
					Projectile.Kill();
                }
			}
			Projectile.tileCollide = false;
		}
        public override void Kill(int timeLeft)
		{
			for (int num623 = 0; num623 < 50; num623++)
			{
				int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 1.5f;
			}
		}
		public override bool PreDraw(ref Color lightColor)
		{
			float vel = MathHelper.Clamp(Vector2.Distance(Projectile.Center, Projectile.Center + Projectile.velocity) / 10, 0, 0.6f);

			Vector2 sc = new Vector2(1, 1);
			if (Projectile.ai[1] < 3) sc = new Vector2(1 - vel, 1 + vel);
			Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, sc, SpriteEffects.None, 0f);
			}
			return false;
		}

		public override bool PreAI()
		{
			Projectile.alpha++;
			float num = 1f - (float)Projectile.alpha / 255f;
			Projectile.velocity *= .98f;
			Projectile.rotation = Projectile.velocity.ToRotation() + 1.57f;
			num *= Projectile.scale;
			Lighting.AddLight(Projectile.Center, 0.3f * num, 0.2f * num, 0.1f * num);
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
			return true;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 200, 122, 100);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(4))
				target.AddBuff(BuffID.OnFire, 240);
		}

	}
}