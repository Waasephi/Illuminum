using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class BugBite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bug Bite");
			Tooltip.SetDefault("Turns musket balls into stingers.");
		}

		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 24;
			Item.useTime = 43;
			Item.useAnimation = 43;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 2, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = false;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.HornetStinger;
			}
			const int NumProjectiles = 4;

			for (int i = 0; i < NumProjectiles; i++)
			{
				
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

				
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.Boomstick);
			recipe.AddIngredient(Mod, "VialofEvil", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}