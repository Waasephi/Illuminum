using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class GaiasGrace : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gaia's Grace");
			Tooltip.SetDefault("Infused with the gifts of the earth." +
                "\n+60 Mana" +
                "\n-15% Mana Cost" +
                "\n+3 Mana Regeneration" +
                "\nAutomatically use mana potions when needed.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.manaRegen += 3;
			player.statManaMax2 += 60;
			player.manaCost *= 0.85f;
			player.manaFlower = true;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 42;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ManaRegenerationBand);
			recipe.AddIngredient(ItemID.ManaFlower);
			recipe.AddIngredient(ItemID.SorcererEmblem);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}