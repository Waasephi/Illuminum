using Illuminum.Projectiles.Melee.PreHM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class VileLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ebondune Lance");
			// Tooltip.SetDefault("Spawns tiny eaters on hit");
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.shootSpeed = 3.1f;
			Item.knockBack = 6.5f;
			Item.width = 66;
			Item.height = 66;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 30);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			Item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()
			Item.reuseDelay = 1;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<VileLanceProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "VialofEvil", 8);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(Mod, "VialofEvil", 8);
            recipe2.AddIngredient(ItemID.PlatinumBar, 10);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
    }
}