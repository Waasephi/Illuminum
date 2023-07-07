using Illuminum.Items.Materials.HM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.HM.Angelite
{
	[AutoloadEquip(EquipType.Body)]
	public class AngeliteChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			// DisplayName.SetDefault("Angelite Chestplate");
			/* Tooltip.SetDefault("+12% all Crit Chance" +
                "\n+2 Max Minions"); */
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 22;
			Item.value = 1500;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 14;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Generic) += 12;
			//player.statManaMax2 += 20;
			player.maxMinions += 2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RefinedAngelite>(), 20);
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.Register();
		}
	}
}