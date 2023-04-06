using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.PreHM.Hematite
{
	[AutoloadEquip(EquipType.Body)]
	public class HematiteChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Hematite Chestplate");
			Tooltip.SetDefault("+12% Damage, +40 mana");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 2000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) *= 1.12f;
			player.statManaMax2 += 40;
			//player.maxMinions++;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "HematiteChunk", 20);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}