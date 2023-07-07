using Illuminum.Items.Materials;
using Illuminum.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials.PreHM
{
	public class VialofEvil : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 // DisplayName.SetDefault("Vial of Evil"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 24;
			Item.height = 36;
			Item.value = Item.sellPrice(silver: 2);
			Item.rare = ItemRarityID.Blue;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.maxStack = 999;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.DemoniteBar);
			recipe.AddIngredient(ItemID.ShadowScale);
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.BottledWater);
			recipe2.AddIngredient(ItemID.CrimtaneBar);
			recipe2.AddIngredient(ItemID.TissueSample);
			recipe2.AddTile(TileID.Hellforge);
			recipe2.Register();
		}
	}
}