using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class MysticArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystic Arrow");
			Tooltip.SetDefault("Its cursed." +
                "\n+5% Magic Damage" +
                "\n-20% Chance to consume ammo" +
                "\n-3% Ranged Damage.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Magic) *= 1.05f;
			player.GetDamage(DamageClass.Ranged) *= 0.95f;
			player.ammoCost80 = true;
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 34;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(ItemID.SilverBar, 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}