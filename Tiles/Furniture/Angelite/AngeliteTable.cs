using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Tiles.Furniture.Angelite
{
	public class AngeliteTable : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 24;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 125;
			Item.createTile = ModContent.TileType<AngeliteTableTile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddTile(ModContent.TileType<AngeliteAltar>());
			recipe.AddIngredient(ModContent.ItemType<AngeliteBrick>(), 8);
			recipe.Register();
		}
	}
}