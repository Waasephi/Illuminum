using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class AngeliteLongbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Angelite Longbow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Wooden Arrows turn into Crystal Bolts.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 38;
			Item.height = 68;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 1, silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.CrystalPulse;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "RefinedAngelite", 15);
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.Register();
		}
	}
}