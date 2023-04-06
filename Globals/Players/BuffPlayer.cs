
using Illuminum.Buffs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Globals.Players
{
    public class BuffPlayer : ModPlayer
    {
        public bool bloodFlame;

        public override void ResetEffects()
        {
            bloodFlame = false;
        }
        public override void UpdateDead()
        {
            bloodFlame = false;
        }

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (bloodFlame)
            {
                if (Main.rand.NextBool(5) && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.Position, Player.width + 4, Player.height + 4, DustID.Blood);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].fadeIn = 1f;
                    Main.dust[dust].scale = Main.rand.NextFloat(0.6f, 1f);

                    drawInfo.DustCache.Add(dust);
                }

                r *= 0.8f;
                g *= 0.2f;
            }
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (Player.FindBuffIndex(ModContent.BuffType<BloodFlame>()) != -1 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
                damageSource = PlayerDeathReason.ByCustomReason(Player.name + " bled out");

            return true;
        }
    }
}