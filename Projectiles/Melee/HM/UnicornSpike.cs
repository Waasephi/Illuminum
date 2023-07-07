using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles.Melee.HM
{
    public class UnicornSpike : ModProjectile
    {
        //public override void SetStaticDefaults() => DisplayName.SetDefault("Unicorn Spike");

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.DamageType = DamageClass.Ranged;

            Projectile.height = 10;
            Projectile.width = 16;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 300;
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
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleCrystalShard);
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