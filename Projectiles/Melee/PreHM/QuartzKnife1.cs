using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Projectiles.Melee.PreHM
{

	public class QuartzKnife1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			 DisplayName.SetDefault("Quartz Knife");
			Main.projFrames[base.Projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			Projectile.width = 56;
			Projectile.height = 66;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 11;
			Projectile.ignoreWater = true;
		}

		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 2)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			Vector2 angle = new Vector2(Projectile.ai[0], Projectile.ai[1]);
			Projectile.rotation = angle.ToRotation();
			Player player = Main.player[Projectile.owner];
			Projectile.position = player.Center + angle - new Vector2(Projectile.width / 2, Projectile.height / 2);
			if (Projectile.timeLeft == 2)
			{
				Projectile.friendly = false;
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			
			target.AddBuff(BuffID.Bleeding, 240);
			Vector2 angle = new Vector2(Projectile.ai[0], Projectile.ai[1]);
			angle *= 0.105f;
			Player player = Main.player[Projectile.owner];
			if (angle.Y > 0 && player.velocity.Y != 0)
			{
				angle *= 2.5f;
				player.velocity.Y = -angle.Y;
			}
			base.OnHitNPC(target, damage, knockback, crit);
		}

	}
}