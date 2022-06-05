using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class SteelPetal3 : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Steel Petal"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A sharp chunk of steel. It has a slight shock feeling...");
		}

		public override void SetDefaults() 
		{
			Item.width = 14;
			Item.height = 24;
			Item.value = Item.buyPrice(gold: 25);
			Item.rare = ItemRarityID.LightRed;
			Item.maxStack = 1;
		}
	}
}