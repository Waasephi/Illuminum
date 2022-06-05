using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.DarkSteel
{
	[AutoloadEquip(EquipType.Body)]
	public class DarkSteelChestguard : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Darksteel Chestguard");
			Tooltip.SetDefault("+9% Damage");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 22;
			Item.value = 2000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) *= 1.09f;
			//player.statManaMax2 += 20;
			//player.maxMinions++;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "DarksteelPlating", 20);
			recipe.AddIngredient(ItemID.MoltenBreastplate);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}