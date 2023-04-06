using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials.PreHM
{
	public class HematiteChunk : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Hematite Chunk"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A chunk of fossilized blood, it is very smooth.");
		}

		public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 28;
			Item.value = Item.sellPrice(silver: 10);
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
			recipe.AddIngredient(ItemType<BloodShard>(), 2);
			recipe.AddIngredient(ItemID.Bone, 1);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}