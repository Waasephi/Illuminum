using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles.Melee.PreHM;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
    public class VileLeash : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ebondune Leash");
        }

        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.width = 58;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 13;
            Item.useTime = 13;
            Item.knockBack = 4f;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<VileLeashProjectile>();
            Item.shootSpeed = 25f;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "VialofEvil", 8);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(Mod, "VialofEvil", 8);
            recipe2.AddIngredient(ItemID.PlatinumBar, 10);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
    }
}