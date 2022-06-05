using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Tiles
{
	public class AngeliteBrick : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Angelite Brick"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 16;
			Item.height = 16;
			Item.value = 0;
			Item.rare = ItemRarityID.Blue;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.maxStack = 999;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = TileType<AngeliteBrickTile>();
			Item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemType<AngeliteChunk>(), 2);
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.Register();
		}
	}
}