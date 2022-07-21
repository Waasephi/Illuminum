
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Tiles.Banners;
using Terraria.GameContent.Creative;

namespace Illuminum.Items.Banners
{
    public class MosscreepBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<MosscreepBannerTile>(), 0);
            Item.width = 16;
            Item.height = 48;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 10, 0);
        }
    }
}