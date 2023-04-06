using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials.HM
{
	public class StardustCore : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Stardust Core"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 30;
			Item.height = 34;
			Item.value = Item.buyPrice(gold: 80);
			Item.rare = ItemRarityID.Yellow;
			Item.maxStack = 1;
		}
	}
}