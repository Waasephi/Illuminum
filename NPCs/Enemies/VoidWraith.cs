using Illuminum.Items.Banners;
using Illuminum.Items.Materials;
using System;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Biomes.Voidlands;
using Terraria.GameContent.Bestiary;

namespace Illuminum.NPCs.Enemies
{
	public class VoidWraith : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Wraith");
			Main.npcFrameCount[NPC.type] = 4;
		}
		private Player player;
		private float speed;
		public override void SetDefaults()
		{
			NPC.width = 16;
			NPC.height = 40;
			NPC.damage = 35;
			NPC.lifeMax = 300;
			NPC.life = 300;
			NPC.defense = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 100f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 5;
			AIType = NPCID.DungeonSpirit;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<VoidWraithBanner>();
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			SpawnModBiomes = new int[1] { ModContent.GetInstance<VoidlandsUndergroundBiome>().Type };
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.InModBiome(ModContent.GetInstance<VoidlandsUndergroundBiome>()) && Main.hardMode ? 1f : 0f;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AbyssalFlesh>(), 1, 1, 5));
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				new FlavorTextBestiaryInfoElement("The supposed lifeforms of the voidlands are made entirely of some sort of flesh." +
                "\nIf they spot something in their territory, it will chase them until one of them perishes.")
			});
		}

		private void Target()
		{
			player = Main.player[NPC.target];
		}
		public override void AI()
		{
			Target();
			Move(Vector2.Zero);
        }
        private float Magnitude(Vector2 mag)
		{
			return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);

		}
		private void Move(Vector2 offset)
		{
			speed = 6f;
			Vector2 goalPosition = player.Center;
			Vector2 move = goalPosition - NPC.Center;
			float magnitude = Magnitude(move);
			if (magnitude > speed)
			{
				move *= speed / magnitude;
			}
			magnitude = Magnitude(move);
			if (magnitude > speed)
			{
				move *= speed / magnitude;
			}
			NPC.velocity = move;
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