using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using Illuminum.Items.Materials.HM;
using Illuminum.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Illuminum.Projectiles.Melee.HM;

namespace Illuminum.Items.Weapons.Melee.HM
{
    public class DragonHammer : SwingWeaponBase
    {
        public override int Length => 74;
        public override int TopSize => 45;
        public override float SwingDownSpeed => 18f;
        public override bool CollideWithTiles => true;
        static bool hasHitSomething = false;
        static bool hasHitEnemies = false;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dragon Hammer");
            // Tooltip.SetDefault("Explodes hit enemies");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 155;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.width = 92;
            Item.height = 86;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = SwingUseStyle;
            Item.knockBack = 10;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 5);
            Item.UseSound = SoundID.DD2_MonkStaffSwing;
            Item.scale = 1.2f;
        }

        public override void UseAnimation(Player player)
        {
            hasHitSomething = false;
            hasHitEnemies = false;
        }

        public override void OnHitTiles(Player player)
        {
            if (!hasHitSomething)
            {
                hasHitSomething = true;

                IlluminumPlayer.ScreenShakeAmount = 11;


                SoundEngine.PlaySound(SoundID.Item69, player.Center);
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.Center.X + (player.direction == 1 ? 90 + (Item.scale * 2) : -90 + (-Item.scale * 2)),
                player.Center.Y, 0, -6, ProjectileID.MonkStaffT2Ghast, 75, Item.knockBack = 3, player.whoAmI);
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!hasHitEnemies)
            {
                hasHitEnemies = true;

                SoundEngine.PlaySound(SoundID.Item69, player.Center);
                Projectile.NewProjectile(Item.GetSource_FromThis(), target.Center.X, target.Center.Y -40, 0, 0,
                ProjectileID.DD2ExplosiveTrapT3Explosion, Item.damage, 0f, Main.myPlayer, 0, 0);

                Projectile.NewProjectile(Item.GetSource_FromThis(), target.Center.X, target.Center.Y, 0, 0,
                ModContent.ProjectileType<HMHammerHit>(), Item.damage, 0f, Main.myPlayer, 0, 0);
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddIngredient(ModContent.ItemType<DragonScale>(), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}