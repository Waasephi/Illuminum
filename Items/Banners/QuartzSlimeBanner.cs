
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Tiles.Banners;
using Terraria.GameContent.Creative;

namespace Illuminum.Items.Banners
{
    public class QuartzSlimeBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<QuartzSlimeBannerTile>(), 0);
            Item.width = 12;
            Item.height = 28;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 10, 0);
        }
    }
}