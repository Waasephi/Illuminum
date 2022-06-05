using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Ranged
{

	public class UrnOfSouls : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Urn of Souls");
		}

		// Our ExampleDamageItem abstract class handles all code related to our custom damage class
		public override void SetDefaults()
		{
			Item.shootSpeed = 8f;
			Item.shoot = ModContent.ProjectileType<UrnOfSoulsHoldout>();
			Item.width = 32;
			Item.height = 40;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 70;
			Item.crit = 4;
			Item.knockBack = 5;
			Item.channel = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(gold: 8);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddIngredient(Mod, "AbyssalFlesh", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<UrnOfSoulsHoldout>()] <= 0;
	}
}