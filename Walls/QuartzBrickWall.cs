using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Illuminum.Walls
{
	public class QuartzBrickWall : ModItem
	{
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
			Item.createWall = ModContent.WallType<QuartzBrickWallTile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(4);
			recipe.AddIngredient(Mod, "QuartzBrick");
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(Mod, "QuartzBrickWall", 4);
			recipe2.AddTile(TileID.WorkBenches);
			recipe2.ReplaceResult(Mod, "QuartzBrick");
			recipe2.Register();
		}
	}
}