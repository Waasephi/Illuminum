using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using Illuminum.Projectiles.Melee.HM;
using Illuminum.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Melee.HM
{
    public class SpookyWoodClub : SwingWeaponBase
    {
        public override int Length => 100;
        public override int TopSize => 36;
        public override float SwingDownSpeed => 18f;
        public override bool CollideWithTiles => true;
        static bool hasHitSomething = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky Wood Club");
            Tooltip.SetDefault("Deals more damage to enemies under half health and confuses on hit" +
                "\nHitting enemies erupts into exploding pumpkin bombs");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.width = 92;
            Item.height = 108;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = SwingUseStyle;
            Item.knockBack = 8;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 2);
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

                IlluminumPlayer.ScreenShakeAmount = 8;

                SoundEngine.PlaySound(SoundID.DD2_MonkStaffGroundMiss, player.Center);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            SoundEngine.PlaySound(new("Illuminum/Sounds/Item/Bonk"), player.position);
            target.AddBuff(BuffID.Confused, 600);

            for (int i = 0; i < Main.rand.Next(2, 4); i++)
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), target.Center, new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, -7)), ModContent.ProjectileType<PumpkinBomb>(), 85, knockBack / 2, player.whoAmI);
            CombatText.NewText(target.getRect(), Color.Purple, "Bonk", true, false);

            if (target.life <= target.lifeMax * 0.50)
            {
                target.takenDamageMultiplier = 1.3f;
            }
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Pumpkin, 30);
			recipe.AddIngredient(ItemID.SpookyWood, 100);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            Texture2D textureGlow = ModContent.Request<Texture2D>(Item.ModItem.Texture + "_Glow").Value;
            Rectangle frame;
            if (Main.itemAnimations[Item.type] != null)
                frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            else
                frame = texture.Frame();

            Vector2 origin = frame.Size() / 2f;

            spriteBatch.Draw(texture, Item.Center - Main.screenPosition, frame, lightColor, rotation, origin, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureGlow, Item.Center - Main.screenPosition, frame, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);

            return false;
        }
    }
}