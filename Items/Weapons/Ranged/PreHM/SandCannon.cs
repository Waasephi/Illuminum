using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class SandCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sand Cannon");
			Tooltip.SetDefault("Shoots a spread of sand.");
		}

		public override void SetDefaults()
		{
			Item.damage = 42;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 52;
			Item.height = 26;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = ItemUseStyleID.Shoot;
			//Item.holdStyle = ItemHoldStyleID.HoldHeavy;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 3, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.SandBallGun;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Sand;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 6;

			for (int i = 0; i < NumProjectiles; i++)
			{
				
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

				
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false;
		}
	}
}