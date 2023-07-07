using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class PalmWoodReed : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 // DisplayName.SetDefault("Palm Wood Reed");
			 // Tooltip.SetDefault("Don't get a splinter.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 28;
			Item.height = 10;
			Item.useTime = 50;
			Item.useAnimation = 50;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 5f;
			Item.UseSound = SoundID.Item63;
			Item.autoReuse = false;
			Item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PalmWood, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}