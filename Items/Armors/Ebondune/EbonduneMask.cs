using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Ebondune
{
	[AutoloadEquip(EquipType.Head)]
	public class EbonduneMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Ebondune Mask");
			Tooltip.SetDefault("+7% Melee Damage");
			ArmorIDs.Head.Sets.DrawHead[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = false;
		}

		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) *= 1.07f;
			//player.endurance *= 1.05f;
			//player.statManaMax2 += 20;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<EbonduneBody>() && legs.type == ModContent.ItemType<EbonduneBoots>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+8% Melee Crit";
			player.GetCritChance(DamageClass.Melee) += 8;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 5);
			recipe.AddIngredient(ItemID.Sandstone, 50); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}