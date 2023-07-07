using Illuminum.Projectiles.Ammo;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged.Ammo
{
	public class StoneSpike : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Stone Spike");
			// Tooltip.SetDefault("Slightly dull... still hurts though...");
		}

		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1.5f;
			Item.value = 1;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<StoneSpikeProjectile>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 5f;                  //The speed of the projectile
			Item.ammo = AmmoID.Dart;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(20);
			recipe.AddIngredient(ItemID.StoneBlock, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}