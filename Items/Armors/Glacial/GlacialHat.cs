using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Glacial
{
	[AutoloadEquip(EquipType.Head)]
	public class GlacialHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Glacial Hat");
			Tooltip.SetDefault("+6% Ranged Crit");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			//player.endurance *= 1.05f;
			player.GetCritChance(DamageClass.Ranged) += 6;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<GlacialLongcoat>() && legs.type == ModContent.ItemType<GlacialPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Permanent Archery Buff, +6% Ranged Damage.";
			player.AddBuff(BuffID.Archery, 2);
			player.GetDamage(DamageClass.Ranged) *= 1.06f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(Mod,"VialofEvil", 5);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}