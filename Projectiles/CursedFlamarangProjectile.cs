using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles
{
	public class CursedFlamarangProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = 3;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
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
	}
}