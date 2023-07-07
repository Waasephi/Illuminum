using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Materials.HM
{
	public class EmptyEmblem : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 // DisplayName.SetDefault("Angelite Chunk"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 28;
			Item.value = Item.buyPrice(gold: 20);
			Item.rare = ItemRarityID.Orange;
			Item.maxStack = 999;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DemonAltar);
			recipe.HasResult(ItemID.WarriorEmblem);
			recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(this);
            recipe2.AddTile(TileID.DemonAltar);
            recipe2.HasResult(ItemID.SorcererEmblem);
            recipe2.Register();

            Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(this);
            recipe3.AddTile(TileID.DemonAltar);
            recipe3.HasResult(ItemID.RangerEmblem);
            recipe3.Register();

            Recipe recipe4 = CreateRecipe();
            recipe4.AddIngredient(this);
            recipe4.AddTile(TileID.DemonAltar);
            recipe4.HasResult(ItemID.SummonerEmblem);
            recipe4.Register();
        }
	}
}