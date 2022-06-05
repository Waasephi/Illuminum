using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Melee
{
	public class CrimriseTrident : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimrise Trident");
			Tooltip.SetDefault("Shoots a Crimrise Bolt");
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 34;
			Item.useTime = 65;
			Item.shootSpeed = 2f;
			Item.knockBack = 6.5f;
			Item.width = 50;
			Item.height = 50;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 30);

			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			Item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<CrimriseTridentProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
			Projectile.NewProjectile(source, position, velocity, ProjectileType<CrimriseBolt>(), damage, knockback, player.whoAmI, ai1: 2);
			Projectile.NewProjectile(source, position, velocity, ProjectileType<CrimriseBolt>(), damage, knockback, player.whoAmI, ai1: 2);
			Projectile.NewProjectile(source, position, velocity, ProjectileType<CrimriseBolt>(), damage, knockback, player.whoAmI, ai1: 2);
			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.Sandstone, 75); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}