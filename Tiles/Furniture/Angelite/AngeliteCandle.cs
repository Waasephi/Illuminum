using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Tiles.Furniture.Angelite
{
	public class AngeliteCandle : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 34;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 100;
			Item.createTile = ModContent.TileType<AngeliteCandleTile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddTile(ModContent.TileType<AngeliteAltar>());
			recipe.AddIngredient(ModContent.ItemType<AngeliteBrick>(), 4);
			recipe.AddIngredient(ItemID.Torch);
			recipe.Register();
		}
	}
}