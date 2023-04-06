using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials.PreHM
{
	public class BloodShard : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Blood Shard"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("'A chunk of coagulated blood'");
		}

		public override void SetDefaults() 
		{
			Item.width = 20;
			Item.height = 16;
			Item.value = Item.sellPrice(silver: 17);
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 9999;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<BloodShard>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.ReplaceResult(ItemID.BloodMoonStarter);
			recipe.Register();

			Recipe recipe2 = CreateRecipe(10);
			recipe2.AddIngredient(ItemID.BloodMoonStarter);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}