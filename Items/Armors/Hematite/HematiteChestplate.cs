using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Hematite
{
	[AutoloadEquip(EquipType.Body)]
	public class HematiteChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Hematite Chestplate");
			Tooltip.SetDefault("+12% Damage");
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 24;
			Item.value = 2000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) *= 1.12f;
			//player.statManaMax2 += 20;
			//player.maxMinions++;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "HematiteChunk", 20);
			recipe.AddIngredient(ItemID.NecroBreastplate);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}