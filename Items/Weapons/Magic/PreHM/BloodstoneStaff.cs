using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Buffs;

namespace Illuminum.Items.Weapons.Magic.PreHM
{
	public class BloodstoneStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bloodstone Staff");
			Item.staff[Item.type] = true;
			/* Tooltip.SetDefault("Uses your life to spew blood at your foes" +
			"\n'An eye for an eye'"); */
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 38;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 40);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.BloodArrow;
			Item.shootSpeed = 12f;
			Item.mana = 5;
			Item.noMelee = true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 3;

			for (int i = 0; i < NumProjectiles; i++)
			{

				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(25));


				newVelocity *= 1f - Main.rand.NextFloat(0.3f);


				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			if (modPlayer.hematiteSet == false)
			{
				CombatText.NewText(player.getRect(), Color.Red, "8", true, false);
				player.statLife -= 8;
				if (player.statLife <= 0)
				{
					player.AddBuff(ModContent.BuffType<BloodFlame>(), 60);
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BloodShard", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}