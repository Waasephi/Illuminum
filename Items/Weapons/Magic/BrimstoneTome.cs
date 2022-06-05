using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Magic
{
	public class BrimstoneTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brimstone Wave");
		}

		public override void SetDefaults()
		{
			Item.damage = 47;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BrimstoneWave>();
			Item.shootSpeed = 12f;
			Item.mana = 15;
			Item.noMelee = true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, ai1: 3);
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, ai1: 4);
			return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BrimstoneCrystal", 12);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}