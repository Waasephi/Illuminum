using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Illuminum.Items.Placeables;

namespace Illuminum.Tiles.Voidlands
{
	public class VoidStoneTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileBlockLight[Type] = true;
			AddMapEntry(new Color(25, 25, 25));
			ItemDrop = ModContent.ItemType<VoidStone>();
			//soundStyle = 1;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = -0.2f;
            g = -0.2f;
            b = -0.2f;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
	}
}