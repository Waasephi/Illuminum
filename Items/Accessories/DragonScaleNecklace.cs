﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories
{
	public class DragonScaleNecklace : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Scale Necklace");
			Tooltip.SetDefault("+50 Armor Penetration." +
                "\nIts still warm.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.GetArmorPenetration(DamageClass.Generic) += 50;
		}

		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 48;
			Item.value = Item.sellPrice(gold: 30);
			Item.rare = ItemRarityID.LightPurple;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 20);
			recipe.AddIngredient(Mod, "DragonScale", 30);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}