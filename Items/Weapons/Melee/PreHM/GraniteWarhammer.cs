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
    public class GraniteWarhammer : SwingWeaponBase
    {
        public override int Length => 58;
        public override int TopSize => 30;
        public override float SwingDownSpeed => 16f;
        public override bool CollideWithTiles => true;
        static bool hasHitSomething = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Warhammer");
            Tooltip.SetDefault("Hitting an enemy spawns blasts of electricity");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 38;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.width = 58;
            Item.height = 60;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = SwingUseStyle;
            Item.knockBack = 8;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 45);
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

                IlluminumPlayer.ScreenShakeAmount = 8;


            SoundEngine.PlaySound(SoundID.DD2_MonkStaffGroundMiss, player.Center);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            SoundEngine.PlaySound(SoundID.Item94, player.Center);
            Projectile.NewProjectile(player.GetSource_ItemUse(Item), target.Center, new Vector2(Main.rand.NextFloat(0, 0), Main.rand.NextFloat(0, 0)), ProjectileID.Electrosphere, 25, knockBack / 8, player.whoAmI);
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