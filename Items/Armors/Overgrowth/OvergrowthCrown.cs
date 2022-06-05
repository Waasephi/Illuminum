using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Overgrowth
{
	[AutoloadEquip(EquipType.Head)]
	public class OvergrowthCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Overgrowth Crown");
			Tooltip.SetDefault("+7% Summoner Damage" +
                "\n+40 Mana" +
                "\n+1 Max Minion");
			ArmorIDs.Head.Sets.DrawHatHair[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 10;
			Item.value = 750;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) *= 1.05f;
			//player.endurance *= 1.05f;
			player.statManaMax2 += 20;
			player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.JungleShirt && legs.type == ItemID.JunglePants;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+10% Summon Damage, +5% Whip Speed, +1 Minion Slot.";
			player.GetDamage(DamageClass.Summon) *= 1.1f;
			player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) *= 1.05f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.JungleSpores, 10);
			recipe.AddIngredient(ItemID.MudBlock, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}