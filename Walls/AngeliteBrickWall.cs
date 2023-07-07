using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Illuminum.Walls
{
	public class AngeliteBrickWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Angelite Brick Wall");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 0;
			Item.createWall = ModContent.WallType<AngeliteBrickWallTile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(4);
			recipe.AddIngredient(Mod, "AngeliteBrick");
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(Mod, "AngeliteBrickWall", 4);
			recipe2.AddTile(Mod, "AngeliteAltar");
			recipe2.ReplaceResult(Mod, "AngeliteBrick");
			recipe2.Register();
		}
	}
}