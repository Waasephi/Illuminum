using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Materials
{
	public class AngeliteChunk : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Angelite Chunk"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 14;
			Item.height = 22;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.Orange;
			Item.maxStack = 999;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AdamantiteOre, 2);
			recipe.AddIngredient(ItemID.SoulofLight);
			recipe.AddIngredient(ItemID.CrystalShard, 5);
			recipe.AddIngredient(ItemID.PixieDust, 2);
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.TitaniumOre, 2);
			recipe2.AddIngredient(ItemID.SoulofLight);
			recipe2.AddIngredient(ItemID.CrystalShard, 5);
			recipe2.AddIngredient(ItemID.PixieDust, 2);
			recipe2.AddTile(Mod, "AngeliteAltar");
			recipe2.Register();
		}
	}
}