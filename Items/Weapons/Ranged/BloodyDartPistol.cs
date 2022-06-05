using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class BloodyDartPistol : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Bloody Dart Pistol");
			 Tooltip.SetDefault("Lumpy and smooth.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 22;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 38);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 8f;
			Item.UseSound = SoundID.Item98;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimtaneBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}