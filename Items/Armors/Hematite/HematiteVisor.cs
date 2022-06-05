using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Hematite
{
	[AutoloadEquip(EquipType.Head)]
	public class HematiteVisor : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Hematite Visor");
			Tooltip.SetDefault("+12% Ranged Crit Chance");
			ArmorIDs.Head.Sets.DrawFullHair[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 6;
			Item.value = 1000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 12;
			//player.endurance *= 1.05f;
			//player.statManaMax2 += 20;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<HematiteChestplate>() && legs.type == ModContent.ItemType<HematiteLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Cannot be set on fire, Immune to Ichor, +3 Life Regeneration.";
			player.lifeRegen += 3;
			player.buffImmune[69] = true; //Nice
			player.fireWalk = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "HematiteChunk", 10);
			recipe.AddIngredient(ItemID.NecroHelmet);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}