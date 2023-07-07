using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Illuminum.Items.Materials.PreHM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Items.Consumables.PreHM.Snails;
using Microsoft.Xna.Framework;

namespace Illuminum.NPCs.Passive.Snails
{
	public class PotSnailDungeon : ModNPC
	{
		public override void SetStaticDefaults()
		{
            Main.npcCatchable[NPC.type] = true;
            Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.width = 32;
			NPC.height = 22;
			NPC.damage = 0;
			NPC.lifeMax = 5;
			NPC.life = 5;
			NPC.defense = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 100f;
			NPC.knockBackResist = 0f;
			NPC.aiStyle = 67;
			AIType = NPCID.Snail;
			AnimationType = NPCID.Snail;
            NPC.catchItem = (short)ModContent.ItemType<PotSnailDungeonItem>();
            /*Banner = NPC.type;
			BannerItem = ModContent.ItemType<QuartzSlimeBanner>();*/
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.ZoneDungeon ? 0.1f : 0f;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon,
				new FlavorTextBestiaryInfoElement("A snail using a Pot as its shell. Its like a living gambling machine!")
			});
		}

        public override void HitEffect(NPC.HitInfo hit)
        {
			int amount = NPC.life <= 0 ? 10 : 2;
            if (NPC.life <= 0)
            {
                Projectile.NewProjectile(NPC.GetSource_Death(), NPC.Center.X, NPC.Center.Y, Main.rand.Next(-2, 2), -3,
                ModContent.ProjectileType<PotSnailDungeonPot>(), NPC.damage, 0, NPC.target, 0, 0);
            }
            for (int i = 0; i < amount; i++)
			{
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.SlimeBunny, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
				dust.velocity *= 0.8f;
			}
		}
	}
}