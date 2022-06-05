using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Illuminum.Projectiles
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
			if (Projectile.ai[0] >= 500f)       //how much time the projectile can travel before landing
			{
				Projectile.velocity.Y = Projectile.velocity.Y;    // projectile fall velocity
				Projectile.velocity.X = Projectile.velocity.X * 5f;    // projectile velocity
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
			Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.Center, Vector2.Zero, ProjectileID.DD2ExplosiveTrapT2Explosion, Projectile.damage, Projectile.knockBack, Projectile.owner);
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				Main.dust[d].scale = 0.5f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(4))
				target.AddBuff(BuffID.Burning, 180);
		}
		public override bool PreAI()
		{
			//    projectile.rotation += 0.1f;
			return true;
		}
	}
}