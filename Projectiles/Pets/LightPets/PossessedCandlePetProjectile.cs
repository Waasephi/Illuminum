using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Buffs.Pets.LightPets;

namespace Illuminum.Projectiles.Pets.LightPets
{
	public class PossessedCandlePetProjectile : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			 DisplayName.SetDefault("Possessed Candle");

			Main.projFrames[Projectile.type] = 4;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			ProjectileID.Sets.LightPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.DD2PetGhost);
			AIType = ProjectileID.DD2PetGhost;
		}

		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WaterCandle);
				dust.noGravity = true;
				//dust.scale = 2f;
			}
		}
		public override void AI()
		{
			Player owner = Main.player[Projectile.owner];

			if (!CheckActive(owner))
			{
				return;
			}
		}

		private bool CheckActive(Player owner)
		{
			if (owner.dead || !owner.active)
			{
				owner.ClearBuff(ModContent.BuffType<PossessedCandleBuff>());

				return false;
			}

			if (owner.HasBuff(ModContent.BuffType<PossessedCandleBuff>()))
			{
				Projectile.timeLeft = 2;
			}

			return true;
		}
	}
}