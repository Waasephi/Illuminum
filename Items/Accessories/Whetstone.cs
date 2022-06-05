using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Items.Materials;

namespace Illuminum.Items.Accessories
{
	public class Whetstone : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Whetstone");
			Tooltip.SetDefault("Sharpen your Sword on the go!" +
                "\nGives Permanent Sharpened buff.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.AddBuff(BuffID.Sharpened, 2);
		}

		public override void SetDefaults()
		{
			Item.width = 52;
			Item.height = 36;
			Item.value = Item.sellPrice(silver: 20);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<QuartzIngot>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}