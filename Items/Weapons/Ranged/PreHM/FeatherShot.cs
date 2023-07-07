using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Illuminum.Projectiles.Ranged.PreHM;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class FeatherShot : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Cursed Fury");
			// Tooltip.SetDefault("Wooden Arrows turn into Cursed Flame Arrows.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 28;
			Item.height = 42;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(silver: 60);
			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 9f;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
			{
				type = ModContent.ProjectileType<FeatherArrowProjectile>(); // or ProjectileID.FireArrow;
			}
		}
	}
}