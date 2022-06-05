using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Items.Weapons.Ranged;

namespace Illuminum.Projectiles
{
	public class GlacialKunaiProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 40;
			Projectile.friendly = true;
			Projectile.aiStyle = 1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 2;      //this is how many enemy this projectile penetrate before disappear
			Projectile.extraUpdates = 1;
			AIType = 507;
			Main.projFrames[Projectile.type] = 1;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
		}

		public override void AI()
		{
			Lighting.AddLight(Projectile.position, 0f, 0f, 2f);
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 250f)       //how much time the projectile can travel before landing
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
				int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Ice, Projectile.velocity.X * 1.2f, Projectile.velocity.Y * 1.2f, 1, default(Color), 3.50f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
				Main.dust[dust].noGravity = true; //this make so the dust has no gravity
				Main.dust[dust].velocity *= 0f;
			}
			return false;

		}
	}
}