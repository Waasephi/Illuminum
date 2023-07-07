using Illuminum.Projectiles.Melee.PreHM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class GladiantGlaive : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Gladiant Glaive"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			// Tooltip.SetDefault("Shoots a lingering spectral glaive.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 54;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.shootSpeed = 2f;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			Item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.shoot = ProjectileType<GladiantGlaiveProjectile>();
			Item.reuseDelay = 1;
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity * 3f, 
			ProjectileType<PhantomGGlaive>(), damage, 0.1f, player.whoAmI);
            return true;
        }
    }
}