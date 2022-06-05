using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Materials
{
	public class BrimstoneCrystal : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Brimstone Crystal"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A red crystal stuck in solidified ash. It is very warm.");
		}

		public override void SetDefaults() 
		{
			Item.width = 34;
			Item.height = 32;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Green;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.maxStack = 999;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AshBlock, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 1);
			recipe.AddIngredient(ItemID.LivingFireBlock, 5);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.Register();
		}
	}
}