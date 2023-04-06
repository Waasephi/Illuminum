using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class HematiteRainBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hematite Rain-Bow");
			Tooltip.SetDefault("Wooden Arrows turn into Bones that rain from the sky" +
                "\nAll other Arrows turn into Bone Arrows");
		}

		public override void SetDefaults()
		{
			Item.damage = 43;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 36;
			Item.height = 58;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.knockBack = 3;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.value = Item.sellPrice(0, 0, 72, 0);
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item5;
			Item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = 532;
			}
            else
            {
				Item.shootSpeed = 14f;
				type = 474;				
            }
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			
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
			recipe.AddIngredient(Mod, "HematiteChunk", 12);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}