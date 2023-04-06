using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.PostML
{
	public class ChaliceoftheMoon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chalice of the Moon");
			Tooltip.SetDefault("Releases Lunar Flares on taking damage," +
                "\nIncreases all damage by 20%." +
                "\nA Chalice with seemingly unending depth.");
		}
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 44;
			Item.value = Item.buyPrice(platinum: 1);
			Item.rare = ItemRarityID.Cyan;
			Item.accessory = true;
			Item.expert = false;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Generic) *= 1.2f;
			player.GetModPlayer<IlluminumPlayer>().lunarWrath = true;
		}
	}
}