using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories.HM
{
	[AutoloadEquip(EquipType.Wings)]
	public class AngeliteWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Allows flight and slow fall");

			// Fly time: 180 ticks = 3 seconds
			// Fly speed: 9
			// Acceleration multiplier: 2.5
			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(200, 5f, 2f);
		}

		public override void SetDefaults()
		{
			Item.width = 56;
			Item.height = 38;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.9f;
			ascentWhenRising = 0.3f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 2.5f;
			constantAscend = 0.2f;
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