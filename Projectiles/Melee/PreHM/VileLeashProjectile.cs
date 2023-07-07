using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles.Melee.PreHM
{
    public class VileLeashProjectile : ModProjectile
    {
        private bool eyeSpawn = true;

        public override void SetStaticDefaults()
        {
             // DisplayName.SetDefault("Ebondune Leash");
        }

        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
        }

        public override void AI()
        {
            if (Projectile.timeLeft == 120) Projectile.ai[0] = 1f;

            if (Main.player[Projectile.owner].dead)
            {
                Projectile.Kill();
                return;
            }

            if (Projectile.alpha == 0)
            {
                if (Projectile.position.X + Projectile.width / 2 > Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2)
                    Main.player[Projectile.owner].ChangeDir(1);
                else
                    Main.player[Projectile.owner].ChangeDir(-1);
            }

            Vector2 vector14 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
            float num166 = Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 - vector14.X;
            float num167 = Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2 - vector14.Y;
            float distance = (float)Math.Sqrt(num166 * num166 + num167 * num167);
            if (Projectile.ai[0] == 0f)
            {
                if (distance > 300f) Projectile.ai[0] = 1f;
                Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
                Projectile.ai[1] += 1f;
                if (Projectile.ai[1] > 8f) Projectile.ai[1] = 8f;
                if (Projectile.velocity.X < 0f)
                    Projectile.spriteDirection = -1;
                else
                    Projectile.spriteDirection = 1;
            }
            //plz retract sir
            else if (Projectile.ai[0] == 1f)
            {
                Projectile.tileCollide = false;
                Projectile.rotation = (float)Math.Atan2(num167, num166) - 1.57f;
                float num169 = 30f;

                if (distance < 50f) Projectile.Kill();
                distance = num169 / distance;
                num166 *= distance;
                num167 *= distance;
                Projectile.velocity.X = num166 * 2.5f;
                Projectile.velocity.Y = num167 * 2.5f;
                if (Projectile.velocity.X < 0f)
                    Projectile.spriteDirection = 1;
                else
                    Projectile.spriteDirection = -1;
            }

            //Spew eye
            /*if ((int)projectile.ai[0] == 1f && projectile.owner == Main.myPlayer && eyeSpawn)
            {
                Vector2 vector54 = Main.player[projectile.owner].Center - projectile.Center;
                Vector2 vector55 = vector54 * -1f;
                vector55.Normalize();
                vector55 *= Main.rand.Next(45, 65) * 0.1f;
                vector55 = vector55.RotatedBy((Main.rand.NextDouble() - 0.5) * 1.5707963705062866);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector55.X, vector55.Y, mod.ProjectileType("EyeProjectile"), projectile.damage, projectile.knockBack,
                    projectile.owner, -10f);
                eyeSpawn = false;
            }*/
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.ai[0] != 1f)
            {
                int dist = 1000;

                for (int i = 0; i < 2; i++)
                {
                    Vector2 offset = new Vector2();
                    double angle = Main.rand.NextDouble() * 2d * Math.PI;
                    offset.X += (float)(Math.Sin(angle) * dist);
                    offset.Y += (float)(Math.Cos(angle) * dist);

                    Vector2 position = target.Center + offset - new Vector2(4, 4);
                    Vector2 velocity = Vector2.Normalize(target.Center - position) * 25;

                    /*int p = Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, velocity,
                        ProjectileID.VilethornTip, Projectile.damage, Projectile.knockBack, Projectile.owner, -10f);

                    if (p != Main.maxProjectiles)
                    {
                        Main.projectile[p].tileCollide = false;
                    }*/
                }
            }

            //retract
            Projectile.ai[0] = 1f;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            //smaller tile hitbox
            width = 25;
            height = 25;
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //retract
            Projectile.ai[0] = 1f;
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            return false;
        }


        // chain voodoo
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("Illuminum/Projectiles/Melee/PreHM/VileLeashChain", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

            Vector2 position = Projectile.Center;
            Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter;
            Rectangle? sourceRectangle = new Rectangle?();
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            float num1 = texture.Height;
            Vector2 vector24 = mountedCenter - position;
            float rotation = (float)Math.Atan2(vector24.Y, vector24.X) - 1.57f;
            bool flag = true;
            if (float.IsNaN(position.X) && float.IsNaN(position.Y))
                flag = false;
            if (float.IsNaN(vector24.X) && float.IsNaN(vector24.Y))
                flag = false;
            while (flag)
                if (vector24.Length() < num1 + 1.0)
                {
                    flag = false;
                }
                else
                {
                    Vector2 vector21 = vector24;
                    vector21.Normalize();
                    position += vector21 * num1;
                    vector24 = mountedCenter - position;
                    Color color2 = Lighting.GetColor((int)position.X / 16, (int)(position.Y / 16.0));
                    color2 = Projectile.GetAlpha(color2);
                    Main.EntitySpriteDraw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0);
                }

            return true;
        }
    }
}