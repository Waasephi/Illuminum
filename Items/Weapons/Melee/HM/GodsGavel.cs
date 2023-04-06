using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;

using Illuminum.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Melee.HM
{
    public class GodsGavel : SwingWeaponBase
    {
        public override int Length => 72;
        public override int TopSize => 34;
        public override float SwingDownSpeed => 18f;
        public override bool CollideWithTiles => true;
        static bool hasHitSomething = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God's Gavel");
            Tooltip.SetDefault("Does more damage to healthy enemies" +
                "\n'Smite them in the name of the Lord!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 85;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.width = 72;
            Item.height = 72;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = SwingUseStyle;
            Item.knockBack = 10;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 1);
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

                IlluminumPlayer.ScreenShakeAmount = 9;


            SoundEngine.PlaySound(SoundID.Item69, player.Center);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            SoundEngine.PlaySound(SoundID.Item9, player.Center);
            for (int i = 0; i < Main.rand.Next(2, 2); i++)
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), target.Center, new Vector2(Main.rand.NextFloat(-15, 15), Main.rand.NextFloat(-25, -25)), ProjectileID.StarCannonStar, 60, knockBack / 2, player.whoAmI);
            for (int i = 0; i < Main.rand.Next(2, 2); i++)
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), target.Center, new Vector2(Main.rand.NextFloat(-15, 15), Main.rand.NextFloat(25, 25)), ProjectileID.StarCannonStar, 60, knockBack / 2, player.whoAmI);
            if (target.life == target.lifeMax)
            {
                target.takenDamageMultiplier = 1.6f;
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 18);
            recipe.AddTile(ItemID.MythrilAnvil);
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