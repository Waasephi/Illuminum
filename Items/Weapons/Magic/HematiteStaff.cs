using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Magic
{
	public class HematiteStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hematite Staff");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 80);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.RubyBolt;
			Item.shootSpeed = 12f;
			Item.mana = 10;
			Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "HematiteChunk", 12);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}