using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Buffs;
using Terraria.GameContent;

namespace Illuminum.Projectiles.Ammo
{
    public class BloodstoneBulletProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bloodstone Bullet");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.alpha = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.Bullet;
        }
        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 0.5f, 0.2f, 0.2f);
        }

        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
                dust.noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<BloodFlame>(), 240);
            SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hitting the terrain
            {
                Projectile.Kill();
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            
            for (int num623 = 0; num623 < 50; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Blood, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 1.5f;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            int height = texture.Height;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 origin = new(texture.Width, Projectile.height);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + origin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(Color.White) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, new Rectangle?(rect), color, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
            }
            return true;
        }
    }
}