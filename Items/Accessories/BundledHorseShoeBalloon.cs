using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	[AutoloadEquip(EquipType.Balloon)]
	public class BundledHorseShoeBalloon : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bundled Horseshoe Balloon");
			Tooltip.SetDefault("Bundle of balloons and horseshoe effects.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.hasJumpOption_Cloud = true;
			player.hasJumpOption_Blizzard = true;
			player.hasJumpOption_Sandstorm = true;
			player.jumpBoost = true;
			player.noFallDmg = true;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 3, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BundleofBalloons, 1);
			recipe.AddIngredient(ItemID.LuckyHorseshoe, 1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}