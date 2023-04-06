using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.HM
{
	public class FrostStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Stone");
			Tooltip.SetDefault("Cold to the touch. " +
                "\nEmbues the holder with frost strength");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			modPlayer.frostStone = true;
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 32;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FrostCore, 5);
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}