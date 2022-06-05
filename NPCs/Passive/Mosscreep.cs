using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.NPCs.Passive
{
	public class Mosscreep : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mosscreep");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.width = 34;
			NPC.height = 26;
			NPC.damage = 0;
			NPC.lifeMax = 5;
			NPC.life = 5;
			NPC.defense = 0;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.aiStyle = 7;
			AIType = NPCID.Bunny;
			AnimationType = NPCID.Frog;
			NPC.knockBackResist = 0f;
			//banner = NPC.type;
			NPC.friendly = false;
			//bannerItem = ModContent.ItemType<MosscreepBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.ZoneJungle ? 0.2f : 0f;
		}

		int frame = 0;
		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			if (NPC.frameCounter > 7)
			{  //7 frames between each "frame" of animation
				NPC.frameCounter = 0;
				frame++;
				if (frame >= Main.npcFrameCount[NPC.type])
				{
					frame = 0;
				}
			}
			NPC.frame.Y = frame * frameHeight;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			int amount = NPC.life <= 0 ? 10 : 2;

			for (int i = 0; i < amount; i++)
			{
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.JungleGrass, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
				dust.velocity *= 0.8f;
			}
			if (NPC.life <= 0)
			{
				for (int i = 0; i < 1; i++)
				{
					Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("Illuminum/MosscreepGore" + (i + 1)).Type, 1);
				}
			}
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
				new FlavorTextBestiaryInfoElement("Weakling that covers itself in leaves to appear larger. Hides amongst the undergrowth. " +
				"\nI used to think these things were merely ambling plants. When I learned they were actually living creatures, I began to kill them on sight. This is the nature of the Hunt!")
			});
		}
	}
}