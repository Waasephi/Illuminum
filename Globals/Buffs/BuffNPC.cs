
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Globals.NPCs
{
    public class BuffNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool bloodFlame;

        public override void ResetEffects(Terraria.NPC npc)
        {
            bloodFlame = false;
        }
        public static void AddDebuffImmunity(int npcType, int[] array)
        {
            if (!NPCID.Sets.DebuffImmunitySets.TryGetValue(npcType, out var entry) || entry?.SpecificallyImmuneTo is null)
                return;

            int[] array2 = NPCID.Sets.DebuffImmunitySets[npcType].SpecificallyImmuneTo;
            NPCID.Sets.DebuffImmunitySets[npcType] = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = array2.Concat(array).ToArray()
            };
        }
        public override void UpdateLifeRegen(Terraria.NPC npc, ref int damage)
        {
            if (bloodFlame)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;

                npc.lifeRegen -= 25;
            }
        }
        public override void DrawEffects(Terraria.NPC npc, ref Color drawColor)
        {
            if (bloodFlame)
            {
                if (Main.rand.NextBool(5))
                {
                    int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width + 4, npc.height + 4, DustID.Blood);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].fadeIn = 1f;
                    Main.dust[dust].scale = Main.rand.NextFloat(0.6f, 1f);
                }

            }
        }
    }
}