using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Quartz
{
	[AutoloadEquip(EquipType.Body)]
	public class QuartzCoat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Quartz Coat");
			Tooltip.SetDefault("+2% Damage Reduction");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 22;
			Item.value = 1500;
			Item.rare = ItemRarityID.White;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.endurance *= 1.02f;
			//player.statManaMax2 += 20;
			//player.maxMinions++;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<QuartzIngot>(), 10);
			recipe.AddIngredient(ItemID.Leather, 20);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}