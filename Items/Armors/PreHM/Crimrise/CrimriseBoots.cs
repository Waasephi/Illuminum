using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.PreHM.Crimrise
{
	[AutoloadEquip(EquipType.Legs)]
	public class CrimriseBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Crimrise Boots");
			Tooltip.SetDefault("+10% Movement Speed");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 14;
			Item.value = Item.sellPrice(silver: 15);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1.1f;
			//player.statManaMax2 += 20;
			//player.maxMinions+=2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.Sandstone, 100); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}