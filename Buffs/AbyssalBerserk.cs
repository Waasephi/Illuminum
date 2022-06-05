using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Buffs
{
	public class AbyssalBerserk : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Rage");
			Description.SetDefault("Damage increased by 20%, but Defense reduced by 20.");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Generic) *= 1.2f;
			player.statDefense -= 20;
		}
	}
}