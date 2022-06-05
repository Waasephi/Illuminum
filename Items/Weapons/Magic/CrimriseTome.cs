using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Magic
{
	public class CrimriseTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimrise Tome");
			Tooltip.SetDefault("Shoots Crimrise Bolts from the sky");
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 14;
			Item.width = 36;
			Item.height = 40;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(0, 0, 42, 0);
			Item.shoot = ProjectileType<CrimriseBolt>();
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.shootSpeed = 12f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			// Loop these functions 3 times.
			for (int i = 0; i < 3; i++)
			{
				position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
				position.Y -= 100 * i;
				Vector2 heading = target - position;

				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}

				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}

				heading.Normalize();
				heading *= velocity.Length();
				heading.Y += Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
			}

			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.Sandstone, 75); //Sandstone Block
			recipe.AddIngredient(ItemID.Book);
			recipe.AddTile(TileID.Bookcases);
			recipe.Register();
		}
	}
}