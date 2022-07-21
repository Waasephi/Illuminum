using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Tools
{
	public class AngeliteHamaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelite Hamaxe");
		}

		public override void SetDefaults()
		{
			Item.damage = 47;
			Item.DamageType = DamageClass.Melee;
			Item.width = 56;
			Item.height = 46;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.axe = 25;
			Item.hammer = 125;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "RefinedAngelite", 14);
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.Register();
		}
	}
}