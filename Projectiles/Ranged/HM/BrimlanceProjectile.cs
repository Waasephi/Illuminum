using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Illuminum.Projectiles.Ranged.HM
{
	public class BrimlanceProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 6;
			Projectile.height = 32;
			Projectile.friendly = true;
			Projectile.aiStyle = 1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 1;      //this is how many enemy this projectile penetrate before disappear
			Projectile.extraUpdates = 1;
			AIType = 507;
			Main.projFrames[Projectile.type] = 1;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
		}

		public override void AI()
		{
			Lighting.AddLight(Projectile.position, 1f, 0.9f, 0f);
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 1000f)       //how much time the projectile can travel before landing
			{
				Projectile.velocity.Y = Projectile.velocity.Y;    // projectile fall velocity
				Projectile.velocity.X = Projectile.velocity.X * 3f;    // projectile velocity
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Projectile.Kill();
			return false;
		}
		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item69, Projectile.position);
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y - 45, 0, 0,
            ProjectileID.DD2ExplosiveTrapT2Explosion, Projectile.damage, 0f, Main.myPlayer, 0, 0);
            for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				Main.dust[d].scale = 1.5f;
			}
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			if (Main.rand.NextBool(2))
				target.AddBuff(BuffID.OnFire3, 180);
		}
		public override bool PreAI()
		{
			//    projectile.rotation += 0.1f;
			return true;
		}
	}
}