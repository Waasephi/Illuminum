using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class DemonPipe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Demon Pipe");
			 Tooltip.SetDefault("I don't know if you should put this by your mouth...");
		}

		public override void SetDefaults() 
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 12;
			Item.useTime = 27;
			Item.useAnimation = 27;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 25);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 6f;
			Item.UseSound = SoundID.Item63;
			Item.autoReuse = false;
			Item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}