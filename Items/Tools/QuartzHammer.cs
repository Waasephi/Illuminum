using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Tools
{
	public class QuartzHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Hammer");
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.hammer = 52;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 10;
			Item.value = 1000;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "QuartzIngot", 10);
			recipe.AddIngredient(ItemID.Wood, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}