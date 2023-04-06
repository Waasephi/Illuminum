using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.PreHM.Crimrise
{
	[AutoloadEquip(EquipType.Body)]
	public class CrimriseChestpiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Crimrise Chestpiece");
			Tooltip.SetDefault("+3% Damage, Immunity to Feral Bite");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 24;
			Item.value = Item.sellPrice(silver: 20);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) *= 1.03f;
			player.buffImmune[BuffID.Rabies] = true;
			//player.statManaMax2 += 20;
			//player.maxMinions++;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 10);
			recipe.AddIngredient(ItemID.Sandstone, 150); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}