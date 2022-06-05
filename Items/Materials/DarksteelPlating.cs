using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Materials
{
	public class DarksteelPlating : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Darksteel Plating"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A very durable plating, slightly hurts to hold.");
		}

		public override void SetDefaults() 
		{
			Item.width = 30;
			Item.height = 26;
			Item.value = Item.sellPrice(silver: 50);
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
			recipe.AddIngredient(ItemID.DemoniteBar, 2);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 1);
			recipe.AddIngredient(ItemID.MeteoriteBar, 2);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}