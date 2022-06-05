using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles
{
    public class CrimriseArrowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 8;
            Projectile.friendly = true;
            Projectile.penetrate = 2;                       //this is the projectile penetration
            Main.projFrames[Projectile.type] = 1;           //this is projectile frames
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            Projectile.ignoreWater = false;
        }
        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 0.7f, 0f, 0f);
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