using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class ElectroDrive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electro Drive");
			Tooltip.SetDefault("Releases Electrosphere Blasts on taking damage." +
                "\nShockingly Advanced!");
		}
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 30;
			Item.value = Item.buyPrice(gold: 80);
			Item.value = Item.sellPrice(gold: 20);
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
			Item.expert = false;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<IlluminumPlayer>().electroShield = true;
		}
	}
}