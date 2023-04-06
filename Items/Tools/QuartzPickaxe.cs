using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Tools
{
	public class QuartzPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Pickaxe");
		}

		public override void SetDefaults()
		{
			Item.damage = 7;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 13;
			Item.pick = 60;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = 1000;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod,"QuartzIngot", 12);
			recipe.AddIngredient(ItemID.Wood, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}