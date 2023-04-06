using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;

using Illuminum.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
    public class NaturesMallet : SwingWeaponBase
    {
        public override int Length => 48;
        public override int TopSize => 20;
        public override float SwingDownSpeed => 15f;
        public override bool CollideWithTiles => true;
        static bool hasHitSomething = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature's Mallet");
            Tooltip.SetDefault("Hitting an enemy gives dryad's blessing");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 44;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.width = 46;
            Item.height = 48;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = SwingUseStyle;
            Item.knockBack = 8;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 35);
            Item.UseSound = SoundID.DD2_MonkStaffSwing;
            Item.scale = 1.5f;
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

                IlluminumPlayer.ScreenShakeAmount = 5;


            SoundEngine.PlaySound(SoundID.DD2_MonkStaffGroundMiss, player.Center);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            player.AddBuff(BuffID.DryadsWard, 120);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CopperHammer);
            recipe.AddIngredient(ItemID.Vine, 3);
            recipe.AddIngredient(ItemID.JungleSpores, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}