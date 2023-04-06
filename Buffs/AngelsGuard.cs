using Illuminum.Globals.NPCs;
using Illuminum.Globals.Players;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Buffs
{
	public class AngelsGuard : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angel's Guard");
			Description.SetDefault("Protected by the angels");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.endurance *= 1.2f;
			player.statDefense += 8;
			player.lifeRegen += 2;
			player.immune = true;         // make player immune
			player.immuneTime = 60;       // ... for 80 ticks
			player.immuneNoBlink = true;  // ... and don't make the player flash during the immune time
			player.longInvince = true;
		}
	}
}