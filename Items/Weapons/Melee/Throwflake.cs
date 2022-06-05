using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class Throwflake : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Throwflake");
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(silver: 80);
			Item.rare = ItemRarityID.Blue;
			Item.shootSpeed = 12f;
			Item.shoot = ModContent.ProjectileType<ThrowflakeProjectile>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.IceBlock, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}