using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class AngeliteWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("(200 wing time, 1 accel)");
		}

		public override void SetDefaults()
		{
			Item.width = 56;
			Item.height = 38;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 200;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.5f;
			maxCanAscendMultiplier = 1.5f;
			maxAscentMultiplier = 1f;
			constantAscend = 1.5f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 6f;
			acceleration = 1f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Feather, 15);
			recipe.AddIngredient(Mod, "RefinedAngelite", 30);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.SortBefore(Main.recipe.First(recipe => recipe.createItem.wingSlot != -1));
			recipe.Register();
		}
	}
}