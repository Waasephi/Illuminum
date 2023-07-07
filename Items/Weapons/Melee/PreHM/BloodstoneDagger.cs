using Illuminum.Projectiles.Melee.PreHM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Illuminum.Items.Materials.PreHM;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Illuminum.Buffs;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class BloodstoneDagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bloodstone Dagger");
			/* Tooltip.SetDefault("Uses your life to damage foes" +
                "\nHitting enemies steals life and inflicts Bloodflame" +
                "\n'An eye for an eye'"); */
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.knockBack = 6f;
			Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.autoReuse = true;
			Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
			Item.noMelee = true; // The projectile will do the damage and not the item
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 40);

			Item.shoot = ProjectileType<BloodstoneDaggerProjectile>(); // The projectile is what makes a shortsword work
			Item.shootSpeed = 2.8f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			if (modPlayer.hematiteSet == false)
            {
				CombatText.NewText(player.getRect(), Color.Red, "5", true, false);
				player.statLife -= 5;
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