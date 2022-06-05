using Illuminum.Items.Banners;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Biomes.Voidlands;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;

namespace Illuminum.NPCs.Enemies
{
	public class AbyssalTendril : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Tendril");
			Main.npcFrameCount[NPC.type] = 8;
		}

		public override void SetDefaults()
		{
			NPC.width = 24;
			NPC.height = 34;
			NPC.damage = 60;
			NPC.lifeMax = 400;
			NPC.life = 400;
			NPC.defense = 5;
			NPC.HitSound = SoundID.NPCHit13;
			NPC.DeathSound = SoundID.NPCDeath11;
			NPC.knockBackResist = 0f;
			NPC.value = 1000f;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<AbyssalTendrilBanner>();
			SpawnModBiomes = new int[1] { ModContent.GetInstance<VoidlandsUndergroundBiome>().Type };
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.InModBiome(ModContent.GetInstance<VoidlandsUndergroundBiome>()) && Main.hardMode ? 1f : 0f;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AbyssalFlesh>(), 2, 1, 3));
        }

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				new FlavorTextBestiaryInfoElement("Even the ground itself seems to be alive in the Voidlands, Whether it is alive or not is another story..." +
                "\nThese tendrils come out from the ground and flail wildly without end, coming in contact with these tendrils leaves a lasting pain.")
			});
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
	}
}