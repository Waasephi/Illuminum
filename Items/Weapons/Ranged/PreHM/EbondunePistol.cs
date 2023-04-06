using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class EbondunePistol : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebondune Pistol");
			Tooltip.SetDefault("Shoots an extra tiny eater" +
                "\nMusket Balls turn into tiny eaters");
		}

		public override void SetDefaults()
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 24;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 8f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet)
			{
				Item.shootSpeed = 12f;
				type = ProjectileID.TinyEater;
			}
            else
            {
				Item.shootSpeed = 8f;
            }
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Projectile.NewProjectile(source, position, velocity * 1.5f, ProjectileID.TinyEater, damage, knockback, player.whoAmI);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.Sandstone, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}