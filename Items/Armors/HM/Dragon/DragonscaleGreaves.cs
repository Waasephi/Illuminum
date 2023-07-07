using Illuminum.Items.Materials.HM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.HM.Dragon
{
	[AutoloadEquip(EquipType.Legs)]
	public class DragonscaleGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			// DisplayName.SetDefault("Dragonscale Greaves");
			/* Tooltip.SetDefault("+16% Movement Speed" +
                "\nImmunity to Knockback"); */
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 14;
			Item.value = 1000;
			Item.rare = ItemRarityID.Red;
			Item.defense = 16;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1.16f;
			player.noKnockback = true;
			//player.statManaMax2 += 20;
			//player.maxMinions+=2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DragonScale>(), 15);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}