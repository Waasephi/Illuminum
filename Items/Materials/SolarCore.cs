using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class SolarCore : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Solar Core"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 34;
			Item.height = 34;
			Item.value = Item.buyPrice(platinum: 1);
			Item.rare = ItemRarityID.Yellow;
			Item.maxStack = 1;
		}
	}
}