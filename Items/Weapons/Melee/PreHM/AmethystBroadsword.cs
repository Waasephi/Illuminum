using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class AmethystBroadsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amethyst Broadsword");
		}

		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(silver: 20);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Amethyst, 8);
			recipe.AddIngredient(ItemID.CopperBroadsword);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}