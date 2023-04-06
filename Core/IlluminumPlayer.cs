using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
//using Illuminum.Biomes.ForgottenGrove;
using Illuminum.Items.Weapons.Ranged.PreHM;
using Illuminum.Buffs;
using Terraria.DataStructures;

namespace Illuminum
{
	public class IlluminumPlayer : ModPlayer
	{
		// Screen Shake
		public static int ShakeTimer = 0;
		public static float ScreenShakeAmount = 0;
		 
		// Accessories
		public bool boneZone;
		public bool electroShield;
		public bool lunarWrath;
		public bool venomGauntlet;
		public bool poisonGlove;
		public bool frozenQuiver;
		public bool frostStone;
		public bool prismaticGauntlet;
		public bool unholyHeart;

		// Armor Set Bonuses
		public bool hematiteSet;
		public bool darkSteelSet;
		public bool dragonSet;
		public bool angeliteSet;

		// Minions
		public bool darkCorruptor;
		public bool hematiteReaver;
		public bool miniDragon;

		// Buffs
		public bool bloodFlame;
		
		// Pets	
		public bool possessedCandle;

		public override void ResetEffects()
		{
			darkCorruptor = false;
			hematiteReaver = false;
			miniDragon = false;
			boneZone = false;
			electroShield = false;
			lunarWrath = false;
			venomGauntlet = false;
			poisonGlove = false;
			frozenQuiver = false;
			frostStone = false;
			darkSteelSet = false;
			angeliteSet = false;
			dragonSet = false;
			bloodFlame = false;
			prismaticGauntlet = false;
			hematiteSet = false;
			unholyHeart = false;
			possessedCandle = false;
		}
		public override void ModifyScreenPosition()
		{
			if (!Main.gameMenu)
			{
				ShakeTimer++;
				if (ScreenShakeAmount >= 0 && ShakeTimer >= 5)
				{
					ScreenShakeAmount -= 0.1f;
				}
				if (ScreenShakeAmount < 0)
				{
					ScreenShakeAmount = 0;
				}
				Main.screenPosition += new Vector2(ScreenShakeAmount * Main.rand.NextFloat(), ScreenShakeAmount * Main.rand.NextFloat());
			}
			else
			{
				ScreenShakeAmount = 0;
				ShakeTimer = 0;
			}
		}

		[System.Obsolete]
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
			if (dragonSet)
			{
				{
					SoundEngine.PlaySound(SoundID.Item69, Player.position);
					int p = Projectile.NewProjectile(Terraria.Entity.InheritSource(Player), Player.Center, Vector2.Zero, ProjectileID.DD2ExplosiveTrapT2Explosion, 150, 5, Player.whoAmI);
				}
			}
			if (angeliteSet)
			{
				{
					SoundEngine.PlaySound(SoundID.Item4, Player.position);
					Player.AddBuff(ModContent.BuffType<AngelsGuard>(), 180);				
				}
			}
			if (boneZone)
			{
				float xVel = Main.rand.NextFloat(-5f, 5f);
				float yVel = Main.rand.NextFloat(-2f, 2f);
				for (int i = 0; i < 5; i++)
				{
					int p = Projectile.NewProjectile(Terraria.Entity.InheritSource(Player), Player.Center, Vector2.Zero, ProjectileID.BoneGloveProj, 60, 5, Player.whoAmI);
					//Tweak values as you'd like.
					Main.projectile[p].timeLeft = 300;
				}
			}
			if (electroShield)
			{
				float xVel = Main.rand.NextFloat(-5f, 5f);
				float yVel = Main.rand.NextFloat(-2f, 2f);
				for (int i = 0; i < 5; i++)
				{
					int p = Projectile.NewProjectile(Terraria.Entity.InheritSource(Player), Player.Center, Vector2.Zero, ProjectileID.Electrosphere, 100, 5, Player.whoAmI);
					//Tweak values as you'd like.
					Main.projectile[p].timeLeft = 30;
				}
			}
			if (lunarWrath)
			{
				float xVel = Main.rand.NextFloat(-10f, 10f);
				float yVel = Main.rand.NextFloat(-5f, 5f);
				for (int i = 0; i < 3; i++)
				{
					int p = Projectile.NewProjectile(Terraria.Entity.InheritSource(Player), Player.Center, Vector2.Zero, ProjectileID.LunarFlare, 200, 5, Player.whoAmI);
					//Tweak values as you'd like.
					Main.projectile[p].timeLeft = 200;
				}
			}
			if (unholyHeart)
			{
				Player.AddBuff(BuffID.Panic, 180);
				Player.AddBuff(BuffID.RapidHealing, 600);
				float xVel = Main.rand.NextFloat(-10f, 10f);
				float yVel = Main.rand.NextFloat(-5f, 5f);
				for (int i = 0; i < 5; i++)
				{
					int p = Projectile.NewProjectile(Terraria.Entity.InheritSource(Player), Player.Center, Vector2.Zero, ProjectileID.TinyEater, 20, 5, Player.whoAmI);
					//Tweak values as you'd like.
					Main.projectile[p].timeLeft = 150;
				}
			}
		}

		public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
		{
			bool inWater = !attempt.inLava && !attempt.inHoney;
			//bool inForgottenGroveSurface = Player.InModBiome(ModContent.GetInstance<ForgottenGroveSurfaceBiome>());
			//bool inForgottenGroveUnderground = Player.InModBiome(ModContent.GetInstance<ForgottenGroveUndergroundBiome>());
			bool inOcean = Player.ZoneBeach;
			bool inCorruption = Player.ZoneCorrupt;
			/*if (inWater && inForgottenGroveSurface && attempt.rare)
			{
				itemDrop = ModContent.ItemType<VoidFin>();
			}

			if (inWater && inForgottenGroveUnderground && attempt.uncommon)
			{
				itemDrop = ModContent.ItemType<VoidFin>();
			}*/

			if (inWater && inOcean && attempt.rare)
			{
				itemDrop = ModContent.ItemType<GunFish>();
			}

			if (inWater && inCorruption && attempt.rare)
			{
				itemDrop = ModContent.ItemType<Gloopie>();
			}
		}

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
			if (item.DamageType == DamageClass.Melee && venomGauntlet)
			{
				target.AddBuff(BuffID.Venom, 3 * 60);
			}
			if (item.DamageType == DamageClass.Melee && poisonGlove)
			{
				target.AddBuff(BuffID.Poisoned, 3 * 60);
			}
			if (item.DamageType == DamageClass.Melee && dragonSet)
			{
				target.AddBuff(BuffID.BetsysCurse, 3 * 60);
			}
			if (frostStone)
			{
				target.AddBuff(BuffID.Frostburn2, 1 * 60);
			}
			if (darkSteelSet)
			{
				target.AddBuff(BuffID.CursedInferno, 1 * 60);
			}
			if (item.DamageType == DamageClass.SummonMeleeSpeed && prismaticGauntlet)
			{
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.OnFire, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.Poisoned, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.Venom, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.Frostburn2, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.Ichor, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.OnFire3, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.ShadowFlame, 3 * 60);
				}
			}
		}

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
			if (proj.DamageType == DamageClass.Melee && venomGauntlet)
			{
				target.AddBuff(BuffID.Venom, 3 * 60);
			}
			if (proj.DamageType == DamageClass.Melee && poisonGlove)
			{
				target.AddBuff(BuffID.Poisoned, 3 * 60);
			}
			if (proj.DamageType == DamageClass.Melee && dragonSet)
			{
				target.AddBuff(BuffID.BetsysCurse, 3 * 60);
			}
			if (proj.DamageType == DamageClass.Melee && frozenQuiver)
			{
				target.AddBuff(BuffID.Frostburn2, 3 * 60);
			}
			if (frostStone)
			{
				target.AddBuff(BuffID.Frostburn2, 1 * 60);
			}
			if (darkSteelSet)
			{
				target.AddBuff(BuffID.CursedInferno, 1 * 60);
			}
			if (proj.DamageType == DamageClass.SummonMeleeSpeed && prismaticGauntlet)
			{
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.OnFire, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.Poisoned, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.Venom, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.Frostburn2, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.Ichor, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.OnFire3, 3 * 60);
				}
				Main.rand.Next(10);
				{
					target.AddBuff(BuffID.ShadowFlame, 3 * 60);
				}
			}
		}
	}
}