using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;

using Illuminum.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Illuminum.Projectiles.Melee.HM;

namespace Illuminum.Items.Weapons.Melee.HM
{
    public class MegatonHammer : SwingWeaponBase
    {
        public override int Length => 76;
        public override int TopSize => 45;
        public override float SwingDownSpeed => 21f;
        public override bool CollideWithTiles => true;
        static bool hasHitSomething = false;
        static bool hasHitEnemies = false;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Megaton Hammer");
            /* Tooltip.SetDefault("Does more damage to injured enemies" +
                "\n'Kill em dead'"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 145;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.width = 94;
            Item.height = 84;
            Item.useTime = 55;
            Item.useAnimation = 55;
            Item.useStyle = SwingUseStyle;
            Item.knockBack = 10;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 2);
            Item.UseSound = SoundID.DD2_MonkStaffSwing;
            Item.scale = 1.5f;
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

                if (!hasHitEnemies)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.Center.X + (player.direction == 1 ? 90 + (Item.scale * 2) : -90 + (-Item.scale * 2)),
                    player.Center.Y, 0, 0, ModContent.ProjectileType<HMHammerHit>(), Item.damage, 0f, Main.myPlayer, 0, 0);
                }
                SoundEngine.PlaySound(SoundID.Item69, player.Center);
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.Center.X + (player.direction == 1 ? 90 + (Item.scale * 2) : -90 + (-Item.scale * 2)),
                player.Center.Y, 0, 6, ProjectileID.LunarFlare, 100, Item.knockBack = 3, player.whoAmI);
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!hasHitEnemies)
            {
                hasHitEnemies = true;

                Projectile.NewProjectile(Item.GetSource_FromThis(), target.Center.X, target.Center.Y, 0, 0,
                ModContent.ProjectileType<HMHammerHit>(), Item.damage, 0f, Main.myPlayer, 0, 0);
            }
            if (target.life <= target.lifeMax * 0.99)
            {
                target.takenDamageMultiplier = 1.7f;
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AdamantiteBar, 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}