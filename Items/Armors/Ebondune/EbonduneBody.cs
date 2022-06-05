using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Ebondune
{
	[AutoloadEquip(EquipType.Body)]
	public class EbonduneBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Ebondune Body");
			Tooltip.SetDefault("+3% Damage, Immunity to Poison");
			ArmorIDs.Body.Sets.HidesBottomSkin[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body)] = false;
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 2000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) *= 1.03f;
			player.buffImmune[BuffID.Poisoned] = true;
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