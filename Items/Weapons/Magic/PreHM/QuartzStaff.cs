using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles.Magic.PreHM;

namespace Illuminum.Items.Weapons.Magic.PreHM
{
	public class QuartzStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Quartz Staff");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 40);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<QuartzBolt>();
			Item.shootSpeed = 7f;
			Item.mana = 6;
			Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "QuartzIngot", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}