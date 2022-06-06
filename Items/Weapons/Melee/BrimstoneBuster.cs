using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class BrimstoneBuster : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Brimstone Buster"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Shoots swift brimstone slashes");
		}

		public override void SetDefaults() 
		{
			Item.damage = 66;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 48;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BrimstoneWave>();
			Item.shootSpeed = 25f;
			Item.scale *= 1.2f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BrimstoneCrystal", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}