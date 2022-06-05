using Illuminum.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Consumables
{
	public class AbyssalBrew : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Causes the consumer to go berserk." +
				"\nIt smells awful");
		}

		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 22;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(gold: 1);
			Item.buffType = ModContent.BuffType<AbyssalBerserk>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 7200; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Deathweed, 2);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(Mod, "VoidFin");
			recipe.AddTile(TileID.ImbuingStation);
			recipe.Register();
		}
	}
}