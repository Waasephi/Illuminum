using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Materials
{
	public class DragonScale : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Dragon Scale"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("It is warm to the touch.");
		}

		public override void SetDefaults() 
		{
			Item.width = 18;
			Item.height = 24;
			Item.value = Item.sellPrice(silver: 27);
			Item.rare = ItemRarityID.LightRed;
			Item.maxStack = 999;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(Mod, "DragonScale", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.ReplaceResult(ItemID.DD2SquireBetsySword); // Flying Dragon
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe2.AddIngredient(Mod, "DragonScale", 10);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.ReplaceResult(ItemID.ApprenticeStaffT3); //Betsy's Wrath
			recipe2.Register();

			Recipe recipe3 = CreateRecipe();
			recipe3.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe3.AddIngredient(Mod, "DragonScale", 10);
			recipe3.AddTile(TileID.MythrilAnvil);
			recipe3.ReplaceResult(ItemID.DD2BetsyBow); //Aerial Bane
			recipe3.Register();

			Recipe recipe4 = CreateRecipe();
			recipe4.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe4.AddIngredient(Mod, "DragonScale", 10);
			recipe4.AddTile(TileID.MythrilAnvil);
			recipe4.ReplaceResult(ItemID.MonkStaffT3); //Sky Dragon's Fury
			recipe4.Register();

			Recipe recipe5 = CreateRecipe();
			recipe5.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe5.AddIngredient(Mod, "DragonScale", 20);
			recipe5.AddIngredient(ItemID.SoulofFlight, 20);
			recipe5.AddTile(TileID.MythrilAnvil);
			recipe5.ReplaceResult(ItemID.BetsyWings); //Betsy's Wings
			recipe5.Register();
		}
	}
}