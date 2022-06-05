using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Items.Materials;

namespace Illuminum.Items.Weapons.Melee
{
	public class MahoganyKnives : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mahogany Knives");
			Tooltip.SetDefault("Shoots a spread of leaves");
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(silver: 60);
			Item.rare = ItemRarityID.Blue;
			Item.shootSpeed = 10f;
			Item.shoot = ProjectileID.Leaf;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 2 + Main.rand.Next(2);
			float rotation = MathHelper.ToRadians(20);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.JungleSpores, 7);
			recipe.AddIngredient(ItemID.RichMahogany, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}