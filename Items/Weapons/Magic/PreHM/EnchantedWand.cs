using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Magic.PreHM
{
	public class EnchantedWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Glacial Trident");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 60);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.MagicMissile;
			Item.shootSpeed = 8f;
			Item.mana = 10;
			Item.noMelee = true;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FallenStar, 15);
            recipe.AddIngredient(ItemID.RubyStaff);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.FallenStar, 15);
            recipe2.AddIngredient(ItemID.DiamondStaff);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
    }
}