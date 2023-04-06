using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;

using Illuminum.Core;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
    public class MahoganyClub : SwingWeaponBase
    {
        public override int Length => 54;
        public override int TopSize => 32;
        public override float SwingDownSpeed => 14f;
        public override bool CollideWithTiles => true;
        static bool hasHitSomething = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mahogany Club");
            Tooltip.SetDefault("Deals more damage to enemies under half health and confuses on hit");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.width = 54;
            Item.height = 64;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = SwingUseStyle;
            Item.knockBack = 8;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 45);
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

                IlluminumPlayer.ScreenShakeAmount = 5;

                SoundEngine.PlaySound(SoundID.DD2_MonkStaffGroundMiss, player.Center);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            SoundEngine.PlaySound(new("Illuminum/Sounds/Item/Bonk"), player.position);
            target.AddBuff(BuffID.Confused, 300);

            CombatText.NewText(target.getRect(), Color.GreenYellow, "Bonk", true, false);

            if (target.life <= target.lifeMax * 0.50)
            {
                target.takenDamageMultiplier = 1.2f;
            }
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.JungleSpores, 7);
			recipe.AddIngredient(ItemID.RichMahogany, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}