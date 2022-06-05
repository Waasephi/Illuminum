using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Melee
{
	public class EbonduneLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebondune Lance");
			Tooltip.SetDefault("Leaves a Corrupt Thorn");
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 32;
			Item.useTime = 60;
			Item.shootSpeed = 2.5f;
			Item.knockBack = 6.5f;
			Item.width = 66;
			Item.height = 66;
			Item.scale = 0.9f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 30);

			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			Item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<EbonduneLanceProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		// How can I shoot 2 different projectiles at the same time?
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity * 5, ProjectileID.VilethornBase, damage / 2, knockback / 2, player.whoAmI);
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