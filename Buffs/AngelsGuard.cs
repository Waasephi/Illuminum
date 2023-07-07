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
			// DisplayName.SetDefault("Angel's Guard");
			// Description.SetDefault("Protected by the angels");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.endurance *= 1.5f;
			player.statDefense += 15;
			player.lifeRegen += 2;
			player.longInvince = true;
		}
	}
}