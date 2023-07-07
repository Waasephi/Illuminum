using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Illuminum.Tiles
{
	internal class CursedForge : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
			AdjTiles = new int[] { TileID.WorkBenches, TileID.Furnaces, TileID.Anvils, TileID.Hellforge, 114 /*Tinkerer's Workshop */, TileID.CookingPots };
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Cursed Forge");
			AddMapEntry(new Color(150, 0, 170), name);

			//Can't use this since texture is vertical.
			//animationFrameHeight = 56;
		}

		// Our textures animation frames are arranged horizontally, which isn't typical, so here we specify animationFrameWidth which we use later in AnimateIndividualTile
		private readonly int animationFrameWidth = 18;

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 1f;
			g = 0f;
			b = 1.2f;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<CursedForgeItem>());
		}
	}

	internal class CursedForgeItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			  // DisplayName.SetDefault("Cursed Forge");
			  /* Tooltip.SetDefault("Combines many stations into one, used for new crafting recipes." +
                "\nWorkbench, Anvil, Hellforge, Tinkerer's Workshop, Cooking Pot all included."); */ 
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Hellforge);
			Item.createTile = ModContent.TileType<CursedForge>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WorkBench);
			recipe.AddIngredient(ItemID.IronAnvil);
			recipe.AddIngredient(ItemID.Hellforge);
			recipe.AddIngredient(ItemID.TinkerersWorkshop);
			recipe.AddIngredient(ItemID.Bone, 50);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.WorkBench);
			recipe2.AddIngredient(ItemID.LeadAnvil);
			recipe2.AddIngredient(ItemID.Hellforge);
			recipe2.AddIngredient(ItemID.TinkerersWorkshop);
			recipe2.AddIngredient(ItemID.Bone, 50);
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.Register();

			Recipe recipe3 = CreateRecipe();
			recipe3.AddIngredient(ItemID.DemoniteBar);
			recipe3.AddTile(Mod, "CursedForge");
			recipe3.ReplaceResult(ItemID.CrimtaneBar);
			recipe3.Register();

			Recipe recipe4 = CreateRecipe();
			recipe4.AddIngredient(ItemID.CrimtaneBar);
			recipe4.AddTile(Mod, "CursedForge");
			recipe4.ReplaceResult(ItemID.DemoniteBar);
			recipe4.Register();

			Recipe recipe5 = CreateRecipe();
			recipe5.AddIngredient(ItemID.ShadowScale);
			recipe5.AddTile(Mod, "CursedForge");
			recipe5.ReplaceResult(ItemID.TissueSample);
			recipe5.Register();

			Recipe recipe6 = CreateRecipe();
			recipe6.AddIngredient(ItemID.TissueSample);
			recipe6.AddTile(Mod, "CursedForge");
			recipe6.ReplaceResult(ItemID.ShadowScale);
			recipe6.Register();
		}
	}
}