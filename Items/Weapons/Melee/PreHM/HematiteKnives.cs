using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles.Melee.PreHM;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
    public class HematiteKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hematite Knives");
            // Tooltip.SetDefault("Shoots a spread of small knives.");
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.width = 28;
            Item.height = 28;
            Item.value = Item.sellPrice(silver: 80);
            Item.rare = ItemRarityID.Orange;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.knockBack = 1f;
            Item.noUseGraphic = true;
            Item.shoot = ProjectileType<HematiteKnife>();
            Item.shootSpeed = 9f;
            Item.UseSound = SoundID.Item39;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 3;

            for (int i = 0; i < NumProjectiles; i++)
            {

                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));


                newVelocity *= 1f - Main.rand.NextFloat(0.0f);


                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
            return true;
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