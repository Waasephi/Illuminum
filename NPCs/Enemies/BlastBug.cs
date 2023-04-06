using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Items.Banners;

namespace Illuminum.NPCs.Enemies
{
	public class BlastBug : ModNPC
	{
		public override void SetStaticDefaults()
		{
			 DisplayName.SetDefault("Blast Bug");
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.width = 30;
			NPC.height = 18;
			NPC.damage = 30;
			NPC.lifeMax = 45;
			NPC.life = 45;
			NPC.defense = 1;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 100f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 14;
			AIType = NPCID.CaveBat;
			AnimationType = NPCID.CaveBat;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<BlastBugBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.ZoneUnderworldHeight ? 0.2f : 0f;
		}

		/*public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<QuartzChunk>(), 1, 1, 5));
		}*/

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
				new FlavorTextBestiaryInfoElement("A Fly that survives by consuming ash and magma. How it is even alive is a mystery.")
			});
		}

        public override void HitEffect(int hitDirection, double damage)
        {
			int amount = NPC.life <= 0 ? 10 : 2;

			for (int i = 0; i < amount; i++)
			{
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.Lava, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
				dust.velocity *= 0.8f;
			}
			if (NPC.life <= 0)
			{
				for (int i = 0; i < 2; i++)
				{
					Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("Illuminum/BlastBugGore" + (i + 1)).Type, 1);
				}
			}
		}
	}
}