using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class EnchantedLongbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Enchanted Longbow");
			Tooltip.SetDefault("Wooden Arrows turn into Jester Arrows.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 24;
			Item.height = 42;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 75);
			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 9f;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				Item.shootSpeed = 3f;
				type = ProjectileID.JestersArrow;
			}
            else
            {
				Item.shootSpeed = 9f;
            }
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FallenStar, 15);
			recipe.AddIngredient(ItemID.GoldBow);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.FallenStar, 15);
			recipe2.AddIngredient(ItemID.PlatinumBow);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}