using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Illuminum.NPCs.Passive.Snails;

namespace Illuminum.Items.Consumables.PreHM.Snails
{
	public class PotSnailJungleItem : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Blood Shard"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			// Tooltip.SetDefault("'A chunk of coagulated blood'");
		}

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
            Item.shootSpeed = 10;
            Item.shoot = ProjectileType<PotSnailJunglePot>();
        }

    }
}