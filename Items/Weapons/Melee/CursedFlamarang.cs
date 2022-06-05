using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class CursedFlamarang : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Flamarang");
		}

		public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Melee;
			Item.width = 20;
			Item.height = 32;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(silver: 55);
			Item.rare = ItemRarityID.Blue;
			Item.shootSpeed = 12f;
			Item.shoot = ModContent.ProjectileType<CursedFlamarangProjectile>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "DarksteelPlating", 8);
			recipe.AddIngredient(ItemID.Flamarang);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}