﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

using Illuminum.Core;
using Illuminum.Items.Weapons.Melee.PreHM;

namespace Illuminum.Core
{
    public abstract class SwingWeaponBase : ModItem
    {
        private List<Vector2> cache;
        private Trail trail;

        public abstract int Length { get; }
        public abstract int TopSize { get; }
        public abstract float SwingDownSpeed { get; }
        public virtual bool CollideWithTiles => true;
        public virtual float WindupAmount => MathHelper.PiOver2;
        public virtual float MainSwingAmount => 1.35f * MathHelper.Pi;

        //the total time spent on the actual swing
        public virtual float SwingTime => SwingDownSpeed;

        public virtual SoundStyle? SwingSound => SoundID.Item1;

        static Vector2 oldHitboxPosition;
        static bool hasHitTile;
        static float oldRot;
        static float mostRecentRotation;

        public const int SwingUseStyle = 1728;

        //gets the total amount of the swing spent on windup, from 0 to 1
        public float SwingWindup(Player player)
        {
            //this ensures we always spend SwingTime in the actual swing, unless the item animation is shorter than SwingTime
            return 1 - SwingTime / Math.Max(player.itemAnimationMax, SwingTime);
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (Item.useStyle != SwingUseStyle)
            {
                return;
            }

            /*if (player.altFunctionUse != 2 && Item.type == ModContent.ItemType<BigBoneHammer>())
            {
                Item.noMelee = false;
                Item.noUseGraphic = false;
            }*/

            float animationProgress = 1 - (player.itemAnimation - 1) / (float)player.itemAnimationMax;
            float swingWindup = SwingWindup(player);

            if (animationProgress < swingWindup)
            {
                hasHitTile = false;
            }

            if (!hasHitTile)
            {
                if (SwingSound != null && animationProgress >= swingWindup && 1 - player.itemAnimation / (float)player.itemAnimationMax < swingWindup)
                {
                    SoundEngine.PlaySound((SoundStyle)SwingSound, player.Center);
                }

                if (animationProgress < swingWindup)
                {
                    float motionProgress = 1 - (1 - animationProgress / swingWindup) * (1 - animationProgress / swingWindup);
                    player.itemRotation = (float)Math.IEEERemainder(-MathHelper.PiOver4 - WindupAmount * motionProgress, MathHelper.TwoPi);

                }
                else
                {
                    float motionProgress = (animationProgress - swingWindup) / (1 - swingWindup);
                    player.itemRotation = (float)Math.IEEERemainder(-MathHelper.PiOver4 - WindupAmount + MainSwingAmount * motionProgress, MathHelper.TwoPi);
                }

                //this affects which way the item is swung, up or down
                player.itemRotation *= player.direction * player.gravDir;

                bool goodRotation = player.itemRotation * player.direction * player.gravDir <= -MathHelper.PiOver4;

                Rectangle hitbox = GetHitbox(player);

                if (CollideWithTiles && !hasHitTile && oldHitboxPosition != Vector2.Zero && !goodRotation)
                {
                    int steps = Math.Max(1, (int)(hitbox.TopLeft() - oldHitboxPosition).Length() / 4);
                    Vector2 velocity = (hitbox.TopLeft() - oldHitboxPosition) / steps;
                    for (int i = 0; i < steps; i++)
                    {
                        Vector2 testPos = Vector2.Lerp(oldHitboxPosition, hitbox.TopLeft(), i / (float)steps);

                        bool goodYPosition = (testPos.Y + hitbox.Height / 2f) * player.gravDir + hitbox.Height / 2f > player.Center.Y * player.gravDir;

                        Vector2 colVelocity = Collision.noSlopeCollision(testPos, velocity, hitbox.Width, hitbox.Height, true, true);

                        if (goodYPosition && colVelocity != velocity)
                        {
                            Collision.HitTiles(testPos - new Vector2(1, 1), colVelocity, hitbox.Width + 1, hitbox.Height + 1);
                            //TileSound(testPos - new Vector2(1, 1), colVelocity, hitbox.Width + 1, hitbox.Height + 1);
                            hasHitTile = true;
                            mostRecentRotation = Utils.AngleLerp(oldRot, player.itemRotation, (i + colVelocity.Y / velocity.Y) / steps);

                            player.itemRotation = mostRecentRotation;

                            OnHitTiles(player);
                            break;
                        }
                    }
                }
            }
            else
            {
                player.itemRotation = mostRecentRotation;
            }

            if (player.itemRotation * player.direction * player.gravDir <= -MathHelper.PiOver4 && !hasHitTile)
            {
                player.itemLocation = player.MountedCenter.Floor() + new Vector2(player.direction * -6, player.gravDir * -10);
            }
            else
            {
                player.itemLocation = player.MountedCenter.Floor() + new Vector2(player.direction * 6, -player.gravDir * 6).RotatedBy(player.itemRotation);
            }

            ModifyItemPosition(player);

            oldRot = player.itemRotation;

            //adjust for player fullRotation
            player.itemRotation -= player.fullRotation;
            player.itemLocation = (player.position + player.fullRotationOrigin) + (player.itemLocation - (player.position + player.fullRotationOrigin)).RotatedBy(-player.fullRotation);
        }

        public override void UseItemFrame(Player player)
        {
            if (Item.useStyle != SwingUseStyle)
            {
                return;
            }

            float num23 = (player.itemRotation - player.fullRotation) * player.direction * player.gravDir - MathHelper.PiOver4;
            player.bodyFrame.Y = player.bodyFrame.Height * 3;
            if ((double)num23 < -0.75)
            {
                player.bodyFrame.Y = player.bodyFrame.Height * 2;
            }
            if ((double)num23 > 0.6)
            {
                player.bodyFrame.Y = player.bodyFrame.Height * 4;
            }
            if ((double)num23 < -1.5)
            {
                player.bodyFrame.Y = player.bodyFrame.Height;
            }
        }

        public override void UseItemHitbox(Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            if (Item.useStyle != SwingUseStyle)
            {
                return;
            }

            hitbox = GetHitbox(player);
            oldHitboxPosition = hitbox.TopLeft();
        }

        public override bool? CanHitNPC(Player player, NPC target)
        {
            if (Item.useStyle != SwingUseStyle)
            {
                return null;
            }

            float animationProgress = 1 - (player.itemAnimation - 1) / (float)player.itemAnimationMax;

            if (animationProgress < SwingWindup(player))
            {
                return false;
            }

            return null;
        }

        public Vector2 GetHitboxCenter(Player player)
        {
            return player.position + player.fullRotationOrigin + (player.itemLocation - (player.position + player.fullRotationOrigin) + new Vector2(player.direction * Length, -Length).RotatedBy(player.itemRotation).RotatedBy(player.gravDir == 1 ? 0 : player.direction * MathHelper.PiOver2)).RotatedBy(player.fullRotation);
        }

        public Rectangle GetHitbox(Player player)
        {
            Vector2 hitboxDisplacement = GetHitboxCenter(player);
            return new Rectangle((int)hitboxDisplacement.X - TopSize, (int)hitboxDisplacement.Y - TopSize, TopSize * 2, TopSize * 2);
        }

        public virtual void OnHitTiles(Player player) { }

        public virtual void ModifyItemPosition(Player player) { }
    }
}