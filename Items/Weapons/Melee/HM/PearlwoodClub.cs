using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using Illuminum.Projectiles.Melee.HM;
using Illuminum.Core;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Melee.HM
{
    public class PearlwoodClub : SwingWeaponBase
    {
        public override int Length => 65;
        public override int TopSize => 24;
        public override float SwingDownSpeed => 16f;
        public override bool CollideWithTiles => true;
        static bool hasHitSomething = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pearlwood Club");
            Tooltip.SetDefault("Deals more damage to enemies under half health and confuses on hit" +
                "\nHitting enemies erupts into unicorn horns");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 75;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.width = 80;
            Item.height = 78;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = SwingUseStyle;
            Item.knockBack = 8;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 90);
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

                IlluminumPlayer.ScreenShakeAmount = 6;

                SoundEngine.PlaySound(SoundID.DD2_MonkStaffGroundMiss, player.Center);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            SoundEngine.PlaySound(new("Illuminum/Sounds/Item/Bonk"), player.position);
            target.AddBuff(BuffID.Confused, 450);

            for (int i = 0; i < Main.rand.Next(2, 4); i++)
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), target.Center, new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, -7)), ModContent.ProjectileType<UnicornSpike>(), 60, knockBack / 2, player.whoAmI);
            CombatText.NewText(target.getRect(), Color.Pink, "Bonk", true, false);

            if (target.life <= target.lifeMax * 0.50)
            {
                target.takenDamageMultiplier = 1.2f;
            }
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.UnicornHorn, 7);
			recipe.AddIngredient(ItemID.Pearlwood, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}