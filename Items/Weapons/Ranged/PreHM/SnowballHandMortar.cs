using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class SnowballHandMortar : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Snowball Hand Mortar");
			// Tooltip.SetDefault("Shoots a spread of snowballs.");
		}

		public override void SetDefaults()
		{
			Item.damage = 38;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 54;
			Item.height = 28;
			Item.useTime = 50;
			Item.useAnimation = 50;
			Item.useStyle = ItemUseStyleID.Shoot;
			//Item.holdStyle = ItemHoldStyleID.HoldHeavy;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.SnowBallFriendly;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Snowball;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 4;

			for (int i = 0; i < NumProjectiles; i++)
			{
				
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

				
				newVelocity *= 1f - Main.rand.NextFloat(0.2f);

				
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.SnowballCannon);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}