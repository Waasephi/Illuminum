using Illuminum.Projectiles.Misc.PreHM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Illuminum.Buffs;

namespace Illuminum.Items.Weapons.Magic.PreHM
{
	public class Bloodfall : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bloodfall");
			/* Tooltip.SetDefault("Use your life to shoot bloodstone bolts from the sky" +
                "\n'An eye for an eye'"); */
		}

		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 8;
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(0, 0, 42, 0);
			Item.shoot = ProjectileType<BloodstoneBolt>();
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item8;
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
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			if (modPlayer.hematiteSet == false)
			{
				CombatText.NewText(player.getRect(), Color.Red, "7", true, false);
				player.statLife -= 7;
				if (player.statLife <= 0)
				{
					player.AddBuff(BuffType<BloodFlame>(), 60);
				}
			}
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BloodShard", 12);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddTile(TileID.Bookcases);
			recipe.Register();
		}
	}
}