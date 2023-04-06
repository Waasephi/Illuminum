using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class DiamondBroadsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diamond Broadsword");
		}

		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 56;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 60);
			Item.rare = ItemRarityID.Blue;
			Item.scale = 0.9f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Diamond, 8);
			recipe.AddIngredient(ItemID.PlatinumBroadsword);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}