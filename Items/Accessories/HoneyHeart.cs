using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class HoneyHeart : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Heart");
			Tooltip.SetDefault("Tempting to eat... except it isn't edible" +
                "\n+20 Max Life, Permanent Honey Buff.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.AddBuff(BuffID.Honey, 2);
			player.statLifeMax2 += 20;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BeeWax, 7);
			recipe.AddIngredient(ItemID.JungleSpores, 12);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}