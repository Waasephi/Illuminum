using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials.PreHM
{
	public class QuartzIngot : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Quartz Ingot"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 30;
			Item.height = 24;
			Item.value = Item.sellPrice(silver: 2);
			Item.rare = ItemRarityID.White;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.maxStack = 999;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.QuartzIngotTile>();
			Item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<QuartzChunk>(), 2);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}