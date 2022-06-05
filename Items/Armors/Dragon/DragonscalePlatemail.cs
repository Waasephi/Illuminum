using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Dragon
{
	[AutoloadEquip(EquipType.Body)]
	public class DragonscalePlatemail : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Dragonscale Platemail");
			Tooltip.SetDefault("Increased Flight Time" +
                "\n+2 Max Minions" +
                "\n+10% Whip Attack Speed" +
                "\n+10% Melee Armor Penetration");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 20;
			Item.value = 1500;
			Item.rare = ItemRarityID.Red;
			Item.defense = 18;
		}

		public override void UpdateEquip(Player player)
		{
			player.wingTimeMax += 70;
			player.maxMinions += 2;
			player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) *= 1.1f;
			player.GetArmorPenetration(DamageClass.Melee) *= 1.10f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DragonScale>(), 20);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}