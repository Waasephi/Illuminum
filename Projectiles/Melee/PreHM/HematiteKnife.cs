using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Items.Weapons.Ranged;

namespace Illuminum.Projectiles.Melee.PreHM
{
	public class HematiteKnife : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 6;
			Projectile.height = 16;
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
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 400f)       //how much time the projectile can travel before landing
			{
				Projectile.velocity.Y = Projectile.velocity.Y * 0.2f;    // projectile fall velocity
				Projectile.velocity.X = Projectile.velocity.X * 2f;    // projectile velocity
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{                                                           // sound that the projectile make when hitting the terrain
			Projectile.Kill();
			SoundEngine.PlaySound(SoundID.Item50, Projectile.position);
			for (int i = 1; i < 5; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
			{
				int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Blood, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 1.5f;
			}
			return false;

		}
	}
}