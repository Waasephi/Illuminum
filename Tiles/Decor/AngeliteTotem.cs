using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Illuminum.Tiles.Decor
{
	internal class AngeliteTotem : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Angelite Totem");
			AddMapEntry(new Color(238, 90, 167), name);
			Main.tileLighted[Type] = true;
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
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<AngeliteTotemItem>());
		}
	}

	internal class AngeliteTotemItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelite Totem");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Hellforge);
			Item.createTile = ModContent.TileType<AngeliteTotem>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "RefinedAngelite", 10);
			recipe.AddTile(Mod,"AngeliteAltar");
			recipe.Register();
		}
	}
}