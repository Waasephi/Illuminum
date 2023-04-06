using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;

using Illuminum.Core;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
    public class WoodenClub : SwingWeaponBase
    {
        public override int Length => 40;
        public override int TopSize => 20;
        public override float SwingDownSpeed => 12f;
        public override bool CollideWithTiles => true;
        static bool hasHitSomething = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Club");
            Tooltip.SetDefault("Deals more damage to enemies at low health and confuses on hit");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = SwingUseStyle;
            Item.knockBack = 8;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 2);
            Item.UseSound = SoundID.DD2_MonkStaffSwing;
            Item.scale = 1.2f;
        }

        public override void UseAnimation(Player player)
        {
            hasHitSomething = false;
        }

        public override void OnHitTiles(Player player)
        {
            if (!hasHitSomething)
            {
                hasHitSomething = true;

                IlluminumPlayer.ScreenShakeAmount = 3;

                SoundEngine.PlaySound(SoundID.DD2_MonkStaffGroundMiss, player.Center);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            SoundEngine.PlaySound(new("Illuminum/Sounds/Item/Bonk"), player.position);
            target.AddBuff(BuffID.Confused, 300);

            CombatText.NewText(target.getRect(), Color.Yellow, "Bonk", true, false);

            if (target.life <= target.lifeMax * 0.33)
            {
                target.takenDamageMultiplier = 1.2f;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 16);
            recipe.AddTile(TileID.Sawmill);
            recipe.Register();
        }
    }
}