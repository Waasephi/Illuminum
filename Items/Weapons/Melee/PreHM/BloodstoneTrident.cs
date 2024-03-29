using Illuminum.Projectiles.Melee.PreHM;
using Illuminum.Projectiles.Misc.PreHM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Illuminum.Items.Materials.PreHM;
using Illuminum.Buffs;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class BloodstoneTrident : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bloodstone Trident");
			/* Tooltip.SetDefault("Use your life to shoot 3 randomly spreading bolts" +
                "\n'An eye for an eye'"); */
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.shootSpeed = 4f;
			Item.knockBack = 6.5f;
			Item.width = 54;
			Item.height = 54;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 60);

			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			Item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()
			Item.reuseDelay = 1;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<BloodstoneTridentProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            // Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
            float numberProjectiles = 3;
            float rotation = MathHelper.ToRadians(10);
            position += Vector2.Normalize(velocity) * 10f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, velocity, ProjectileType<BloodstoneBolt>(), 20, knockback, player.whoAmI, ai1: 2);
            }
			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			if (modPlayer.hematiteSet == false)
			{
				CombatText.NewText(player.getRect(), Color.Red, "10", true, false);
				player.statLife -= 10;
				if (player.statLife <= 0)
				{
					player.AddBuff(BuffType<BloodFlame>(), 60);
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<BloodShard>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}