using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class IceBall : ModItem
	{
		public override void SetStaticDefaults()
		{
			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
			DisplayName.SetDefault("Ice Ball");
			Tooltip.SetDefault("Shoots a frost bolt at the cursor.");
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 28;
			Item.height = 28;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 10f;
			Item.knockBack = 2.5f;
			Item.damage = 20;
			Item.rare = ItemRarityID.Blue;

			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;

			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(silver: 60);
			Item.shoot = ModContent.ProjectileType<IceBallProjectile>();
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