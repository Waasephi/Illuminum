using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class CharmOfRemorse : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charm of Remorse");
			Tooltip.SetDefault("Your guilt resonate with this gem." +
                "\nDoubles Max Mana, Moderately Increased Mana Regeneration.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.statManaMax2 *= 2;
			player.manaRegen += 5;
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.value = Item.sellPrice(gold: 25);
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "CrystalTear");
			recipe.AddIngredient(Mod, "CrystalGuilt");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}