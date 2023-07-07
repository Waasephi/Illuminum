using Illuminum.Globals.NPCs;
using Illuminum.Globals.Players;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Buffs
{
	public class BloodFlame : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Blood Flame");
			// Description.SetDefault("Your blood is boiling!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<BloodflamePlayer>().lifeRegenDebuff = true;
			player.GetModPlayer<BuffPlayer>().bloodFlame = true;
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<BuffNPC>().bloodFlame = true;
		}
	}

	public class BloodflamePlayer : ModPlayer
	{

		public bool lifeRegenDebuff;

		public override void ResetEffects()
		{
			lifeRegenDebuff = false;
		}

		public override void UpdateBadLifeRegen()
		{
			if (lifeRegenDebuff)
			{

				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;

				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 10;
			}
		}
	}
}