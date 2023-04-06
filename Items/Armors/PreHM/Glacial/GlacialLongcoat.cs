using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.PreHM.Glacial
{
	[AutoloadEquip(EquipType.Body)]
	public class GlacialLongcoat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Glacial Longcoat");
			Tooltip.SetDefault("+7% Ranged Damage, Immunity to Chilled");
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 18;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Ranged) *= 1.07f;
			player.buffImmune[BuffID.Chilled] = true;
			//player.maxMinions++;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.IceBlock, 150);
			recipe.AddIngredient(Mod, "VialofEvil", 10);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}