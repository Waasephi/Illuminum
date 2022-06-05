using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Magic
{
	public class MahoganyStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mahogany Staff");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Magic;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 60);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.SporeTrap;
			Item.shootSpeed = 14f;
			Item.mana = 12;
			Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.RichMahogany, 75);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}