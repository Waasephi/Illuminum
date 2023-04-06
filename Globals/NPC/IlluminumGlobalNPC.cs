using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Items.Materials;
using Illuminum.Items.Weapons.Melee.PreHM;
//using Illuminum.Biomes.ForgottenGrove;
using Illuminum.NPCs.Enemies;
using Illuminum.Items.Accessories.HM;
using Illuminum.Items.Weapons.Magic.PreHM;
using Illuminum.Items.Weapons.Magic.HM;
using Illuminum.Items.Materials.HM;
using Illuminum.Items.Materials.PreHM;

namespace Illuminum.Globals.NPC
{
    public class IlluminumGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(Terraria.NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.DD2Betsy)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DragonScale>(), 1, 20, 35));
            if (npc.type == NPCID.GraniteFlyer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GraniteCore>(), 25));
            if (npc.type == NPCID.GraniteGolem)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GraniteWarhammer>(), 20));
            if (npc.type == NPCID.GreekSkeleton)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GladiantGlaive>(), 30));
            if (npc.type == NPCID.IceGolem)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostStone>(), 12));
            if (npc.type == NPCID.BloodZombie || npc.type == NPCID.Drippler)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodShard>(), 2));
            if (npc.type == NPCID.EyeballFlyingFish)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodShard>(), 1, 7, 11));
            if (npc.type == NPCID.ZombieMerman)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodShard>(), 1, 8, 12));
            if (npc.type == NPCID.BlueJellyfish)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BlueJellyTrident>(), 15));
            if (npc.type == NPCID.PinkJellyfish)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PinkJellyWand>(), 15));
            if (npc.type == NPCID.GreenJellyfish)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GreenJellyStaff>(), 20));
            if (npc.type == NPCID.IlluminantBat || npc.type == NPCID.IlluminantSlime)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AngeliteChunk>(), 1, 1, 3));
            if (npc.type == NPCID.ChaosElemental || npc.type == NPCID.EnchantedSword)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AngeliteChunk>(), 1, 5, 8));
            if (npc.type == NPCID.Lavabat || npc.type == NPCID.RedDevil)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrimstoneCrystal>(), 10, 1, 2));
        }
    }
}