using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Magic
{

	public class VoidShriek : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Shriek");
		}

		// Our ExampleDamageItem abstract class handles all code related to our custom damage class
		public override void SetDefaults()
		{
			Item.shootSpeed = 10f;
			Item.shoot = ProjectileID.LostSoulFriendly;
			Item.UseSound = SoundID.Item103;
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.damage = 76;
			Item.crit = 4;
			Item.knockBack = 5;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Green;
			Item.mana = 16;
			Item.value = Item.sellPrice(gold: 7);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddIngredient(Mod, "AbyssalFlesh", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 4;

			for (int i = 0; i < NumProjectiles; i++)
			{

				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(25));


				newVelocity *= 1f - Main.rand.NextFloat(0.3f);


				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false;
		}
	}
}