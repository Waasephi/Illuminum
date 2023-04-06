using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles.Melee.HM
{
    public class PumpkinBomb : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Pumpkin Bomb");

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.DamageType = DamageClass.Ranged;

            Projectile.height = 14;
            Projectile.width = 14;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 500;
            Projectile.aiStyle = 2;
        }
		/*public override void AI()
		{
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 500f)       //how much time the projectile can travel before landing
			{
				Projectile.velocity.Y = Projectile.velocity.Y;    // projectile fall velocity
				Projectile.velocity.X = Projectile.velocity.X * 3f;    // projectile velocity
			}
		}*/
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return false;
		}
		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-9, -5)), ProjectileID.MolotovFire, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Pumpkin);
				Main.dust[d].scale = 1f;
			}
		}

		public override bool PreAI()
		{
		    //Projectile.rotation += 0.1f;
			return true;
		}
	}
}