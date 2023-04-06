using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.HM
{
	public class BlackenedCrystal : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blackened Crystal");
			Tooltip.SetDefault("It emanates cursed energy." +
                "\nImmunity to blackout... At a cost?");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.buffImmune[BuffID.Blackout] = true;
			player.AddBuff(BuffID.Cursed, 2);
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Diamond, 7);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}