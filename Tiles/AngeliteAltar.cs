using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Illuminum.Tiles
{
	internal class AngeliteAltar : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
			AdjTiles = new int[] { TileID.WorkBenches, TileID.Furnaces, TileID.Anvils, TileID.Hellforge, TileID.TinkerersWorkbench, TileID.CookingPots, TileID.MythrilAnvil, TileID.AdamantiteForge, TileID.DemonAltar };
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Angelite Altar");
			AddMapEntry(new Color(238, 90, 167), name);

			//Can't use this since texture is vertical.
			//animationFrameHeight = 56;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.1f;
			g = 0.1f;
			b = 0.1f;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<AngeliteAltarItem>());
		}
	}

	internal class AngeliteAltarItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			 // DisplayName.SetDefault("Angelite Altar");
			 /* Tooltip.SetDefault("Combines many stations into one, used for new crafting recipes." +
                "\nCursed Forge, Hardmode Anvils, Hardmode Forges, and Altars Included."); */ 
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Hellforge);
			Item.createTile = ModContent.TileType<AngeliteAltar>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "CursedForgeItem");
			recipe.AddIngredient(ItemID.MythrilAnvil);
			recipe.AddIngredient(ItemID.AdamantiteForge);
			recipe.AddIngredient(Mod, "AngeliteChunk", 30);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(Mod, "CursedForgeItem");
			recipe2.AddIngredient(ItemID.MythrilAnvil);
			recipe2.AddIngredient(ItemID.TitaniumForge);
			recipe2.AddIngredient(Mod,"AngeliteChunk", 30);
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.Register();

			Recipe recipe3 = CreateRecipe();
			recipe3.AddIngredient(Mod, "CursedForgeItem");
			recipe3.AddIngredient(ItemID.OrichalcumAnvil);
			recipe3.AddIngredient(ItemID.AdamantiteForge);
			recipe3.AddIngredient(Mod, "AngeliteChunk", 30);
			recipe3.AddTile(TileID.DemonAltar);
			recipe3.Register();

			Recipe recipe4 = CreateRecipe();
			recipe4.AddIngredient(Mod, "CursedForgeItem");
			recipe4.AddIngredient(ItemID.OrichalcumAnvil);
			recipe4.AddIngredient(ItemID.TitaniumForge);
			recipe4.AddIngredient(Mod, "AngeliteChunk", 30);
			recipe4.AddTile(TileID.DemonAltar);
			recipe4.Register();
		}
	}
}