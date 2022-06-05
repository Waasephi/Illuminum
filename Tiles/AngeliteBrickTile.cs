using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Tiles
{
	public class AngeliteBrickTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileLighted[Type] = false;
			Main.tileBlockLight[Type] = true;
			AddMapEntry(new Color(238, 90, 167));
			ItemDrop = ModContent.ItemType<AngeliteBrick>();
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}