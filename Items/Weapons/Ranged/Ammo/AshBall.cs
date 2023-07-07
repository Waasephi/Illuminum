using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles.Ammo;
using Illuminum.Items.Materials.PreHM;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Ranged.Ammo
{
	public class AshBall : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ash Ball");
			// Tooltip.SetDefault("Slightly Warm");
		}

		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 9999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 4.5f;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.value = 1;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<AshBallProjectile>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 8f;                  //The speed of the projectile
			Item.ammo = AmmoID.Snowball;              //The ammo class this ammo belongs to.
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Swing;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(25);
			recipe.AddIngredient(ItemID.AshBlock);
			recipe.Register();
		}
	}
}