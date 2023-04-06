using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class AmberBroadsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Broadsword");
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Amber, 8);
			recipe.AddIngredient(ItemID.IronBroadsword);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.Amber, 8);
			recipe2.AddIngredient(ItemID.LeadBroadsword);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}