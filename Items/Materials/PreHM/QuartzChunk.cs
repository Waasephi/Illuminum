using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Materials.PreHM
{
	public class QuartzChunk : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Quartz Chunk"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 10;
			Item.height = 18;
			Item.value = Item.sellPrice(copper: 50);
			Item.rare = ItemRarityID.White;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.maxStack = 999;
		}
	}
}