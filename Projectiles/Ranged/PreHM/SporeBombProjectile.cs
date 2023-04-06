using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles.Ranged.PreHM
{
    public class SporeBombProjectile : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Spore Bomb");

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.DamageType = DamageClass.Ranged;

            Projectile.height = 14;
            Projectile.width = 20;

            Projectile.timeLeft = 300;
            Projectile.aiStyle = 2;
        }
        public override void AI()
        {
            var dust = Dust.NewDustDirect(Projectile.Center, 0, 0, DustID.JungleSpore, -Projectile.velocity.X / 2f, -Projectile.velocity.Y / 2f);
            dust.noGravity = true;
            dust.fadeIn = 1f;
            dust.scale = Main.rand.NextFloat(0.6f, 1f);

            Projectile.netUpdate = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            

            return true;
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.position, Vector2.Zero, ProjectileID.SporeCloud, 10, 0, Projectile.owner);
            for (int i = 0; i < 20; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width,
                    Projectile.height, DustID.JungleSpore, 0f, 0f, 5, default, 1f);
                Main.dust[dust].velocity *= 3f;
            }

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}