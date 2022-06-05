using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class AngeliteBroadsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Angelite Broadsword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Shoots crystal blasts.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 48;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 95);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.CrystalPulse; //Crystal Serpent
			Item.shootSpeed = 14f;
			Item.scale *= 1.2f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "RefinedAngelite", 15);
			recipe.AddTile(Mod,"AngeliteAltar");
			recipe.Register();
		}
	}
}