using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class CrimriseBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Crimrise Bow");
			Tooltip.SetDefault("Wooden Arrows turn into slightly glowing Crimrise Arrows.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 34;
			Item.height = 46;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 57);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 7f;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = Mod.Find<ModProjectile>("CrimriseArrowProjectile").Type;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.Sandstone, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}