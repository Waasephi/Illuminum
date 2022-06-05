using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles.Ammo
{
    public class StoneSpikeProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.penetrate = 1;                       //this is the projectile penetration
            Main.projFrames[Projectile.type] = 1;           //this is projectile frames
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            Projectile.ignoreWater = false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hitting the terrain
            {
                Projectile.Kill();

                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            }
            return false;
        }
    }
}