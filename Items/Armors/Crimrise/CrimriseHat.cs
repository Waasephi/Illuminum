using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Crimrise
{
	[AutoloadEquip(EquipType.Head)]
	public class CrimriseHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Crimrise Hat");
			Tooltip.SetDefault("+50 Mana");
			ArmorIDs.Head.Sets.DrawHatHair[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 20;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 50;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<CrimriseChestpiece>() && legs.type == ModContent.ItemType<CrimriseBoots>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+8% Increased Magic Damage, 5% Reduced Mana Usage, Increased Life Regeneration by 1.";
			player.GetDamage(DamageClass.Magic) *= 1.08f;
			player.manaCost *= 0.95f;
			player.lifeRegen += 1;
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