using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Glacial
{
	[AutoloadEquip(EquipType.Legs)]
	public class GlacialPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Glacial Pants");
			Tooltip.SetDefault("\n+10% Movement Speed");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1.10f;
			//player.maxMinions+=2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.IceBlock, 100);
			recipe.AddIngredient(Mod,"VialofEvil", 8);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}