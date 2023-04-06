using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles.Magic.PreHM;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Magic.PreHM
{
	public class Bloodstream : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodstream");
			Tooltip.SetDefault("Shoots streams of blood" +
                "\nMeteor armor reduces mana cost to 0");
		}

		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Magic;
			Item.width = 48;
			Item.height = 34;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 40);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item13;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.BloodArrow;
			Item.shootSpeed = 10f;
			Item.mana = 5;
			Item.noMelee = true;
		}
		public override void ModifyManaCost(Player player, ref float reduce, ref float mult)
		{
			if (player.spaceGun)
			{
				mult = 0;
			}
			else
			{
				mult = 1;
			}
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 45f;
			if (Collision.CanHit(position, 0, 16, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			Projectile.NewProjectile(source, position, velocity, ProjectileID.BloodArrow, damage, knockback, player.whoAmI, 0f, 0f);
			return false;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "HematiteChunk", 12);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}