using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.PreHM
{
	public class TinCross : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tin Cross");
			/* Tooltip.SetDefault("A pocket cross, holding this gives you comfort." +
				"\nIncreases mana regeneration"); */
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 20);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.manaRegen += 2;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TinBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}