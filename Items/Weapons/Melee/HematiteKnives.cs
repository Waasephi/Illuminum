using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Melee
{
    public class HematiteKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hematite Knives");
            Tooltip.SetDefault("Shoots 2 knives at different speeds.");
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.width = 54;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 80);
            Item.rare = ItemRarityID.Green;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.knockBack = 1f;
            Item.noUseGraphic = true;
            Item.shoot = ProjectileType<HematiteKnife>();
            Item.shootSpeed = 15f;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 2;
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