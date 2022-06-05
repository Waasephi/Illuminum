using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class RefinedAngelite : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Refined Angelite"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Item.width = 26;
			Item.height = 24;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Orange;
			Item.maxStack = 999;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<AngeliteChunk>(), 4);
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.Register();
		}
	}
}