using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Melee
{
	public class AbyssalBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Blade");
			Tooltip.SetDefault("Shoots abyssal tendrils.");
		}

		public override void SetDefaults()
		{
			Item.damage = 87;
			Item.DamageType = DamageClass.Melee;
			Item.width = 58;
			Item.height = 64;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 5);
			Item.shoot = ModContent.ProjectileType<AbyssalTendril>();
			Item.shootSpeed = 16f;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.channel = true;
			Item.UseSound = SoundID.Item111;
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddIngredient(Mod, "AbyssalFlesh", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}