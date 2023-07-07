using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Items.Materials.PreHM;

namespace Illuminum.Items.Accessories.PreHM
{
	public class QuartzLacedGlove : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Quartz Laced Glove");
			/* Tooltip.SetDefault("Comfortable and gives a stronger grip." +
                "\n+8% Whip Speed."); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) *= 1.08f;
		}

		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 22;
			Item.value = Item.sellPrice(silver: 20);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Leather, 7);
			recipe.AddIngredient(ModContent.ItemType<QuartzIngot>(), 5);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}