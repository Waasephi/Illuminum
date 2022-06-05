using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class RubyBroadsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruby Broadsword");
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.scale = 1.1f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Ruby, 8);
			recipe.AddIngredient(ItemID.GoldBroadsword);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}