using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Melee
{
	public class FrigidFlayer : ModItem
	{
		float shootCD;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frigid Flayer");
			Tooltip.SetDefault("Creates a frozen slash that repels and freezes enemies.");
		}

		public override void SetDefaults()
		{
			Item.damage = 37;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.width = 48;
			Item.height = 52;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.shoot = Mod.Find<ModProjectile>("FrigidFlayer1").Type;
			Item.shootSpeed = 30f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			position += new Vector2();
			Projectile.NewProjectile(source, position, velocity / 30, type, damage, knockback, player.whoAmI, velocity.X, velocity.Y);
			if (Item.shoot == Mod.Find<ModProjectile>("FrigidFlayer1").Type)
			{
				Item.shoot = Mod.Find<ModProjectile>("FrigidFlayer2").Type;
			}
			else
			{
				Item.shoot = Mod.Find<ModProjectile>("FrigidFlayer1").Type;
			}
			return false;
		}
	}
}