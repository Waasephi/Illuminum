using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Illuminum.Items.Materials.PreHM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Items.Banners;

namespace Illuminum.NPCs.Enemies
{
	public class QuartzSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			 // DisplayName.SetDefault("Quartz Slime");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.width = 30;
			NPC.height = 18;
			NPC.damage = 5;
			NPC.lifeMax = 40;
			NPC.life = 40;
			NPC.defense = 1;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 100f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 1;
			AIType = NPCID.BlueSlime;
			AnimationType = NPCID.BlueSlime;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<QuartzSlimeBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.ZoneRockLayerHeight && !spawnInfo.Player.ZoneDungeon ? 0.2f : 0f;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<QuartzChunk>(), 1, 1, 5));
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
				new FlavorTextBestiaryInfoElement("A type of slime that lives underground. It is said that they feed on minerals and turn them into quartz inside its body.")
			});
		}

        public override void HitEffect(NPC.HitInfo hit)
        {
			int amount = NPC.life <= 0 ? 10 : 2;

			for (int i = 0; i < amount; i++)
			{
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.Silver, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
				dust.velocity *= 0.8f;
			}
		}
	}
}