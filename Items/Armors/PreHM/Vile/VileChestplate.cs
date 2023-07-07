using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.PreHM.Vile
{
	[AutoloadEquip(EquipType.Body)]
	public class VileChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
            // DisplayName.SetDefault("Ebondune Body");
            // Tooltip.SetDefault("+3% Damage Reduction");
            ArmorIDs.Body.Sets.HidesBottomSkin[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body)] = false;
        }

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 20;
			Item.value = 2000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			player.endurance += 3f;
			//player.statManaMax2 += 20;
			//player.maxMinions++;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "VialofEvil", 10);
            recipe.AddIngredient(ItemID.GoldBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(Mod, "VialofEvil", 10);
            recipe2.AddIngredient(ItemID.PlatinumBar, 15);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
	}
}