using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class Virulence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Virulence");
			Tooltip.SetDefault("Turns musket balls into cursed bullets");
		}

		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 46;
			Item.height = 26;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.CursedBullet;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.TheUndertaker);
			recipe.AddIngredient(Mod,"VialofEvil", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}