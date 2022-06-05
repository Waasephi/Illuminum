﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class CopperCross : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Copper Cross");
			Tooltip.SetDefault("A pocket cross, good to keep on you." +
				"\n+2% Magic Damage.");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 20);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.GetDamage(DamageClass.Magic) *= 1.02f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}