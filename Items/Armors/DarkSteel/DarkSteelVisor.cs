using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.DarkSteel
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkSteelVisor : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Darksteel Visor");
			Tooltip.SetDefault("+9% Ranged Crit Chance");
			ArmorIDs.Head.Sets.DrawFullHair[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 8;
			Item.value = 1000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 9;
			//player.endurance *= 1.05f;
			//player.statManaMax2 += 20;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DarkSteelChestguard>() && legs.type == ModContent.ItemType<DarkSteelGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			player.setBonus = "Cannot be set on fire, Immune to Cursed Inferno, All weapons inflict Cursed Inferno";
			modPlayer.darkSteelSet = true;
			player.buffImmune[39] = true;
			player.fireWalk = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "DarksteelPlating", 10);
			recipe.AddIngredient(ItemID.MoltenHelmet);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}