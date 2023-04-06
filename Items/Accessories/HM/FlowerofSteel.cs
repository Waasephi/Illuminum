using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories.HM
{
	public class FlowerofSteel : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flower of Steel");
			Tooltip.SetDefault("Grants Immunity to Electrified" +
                "\n+7% Damage Reduction" +
                "\nA Flower of the highest quality.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.endurance *= 1.07f;
			player.buffImmune[BuffID.Electrified] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 26;
			Item.value = Item.sellPrice(gold: 20);
			Item.rare = ItemRarityID.Pink;
			Item.accessory = true;
			Item.expert = false;
			Item.defense = 4;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "SteelPetal1");
			recipe.AddIngredient(Mod, "SteelPetal2");
			recipe.AddIngredient(Mod, "SteelPetal3");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}