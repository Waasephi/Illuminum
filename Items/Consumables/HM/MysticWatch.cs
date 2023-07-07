using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Consumables.HM
{
	public class MysticWatch : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Blood Shard"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			// Tooltip.SetDefault("'A chunk of coagulated blood'");
		}

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldWatch);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.AddIngredient(ItemID.GraniteBlock, 20);
            recipe.AddIngredient(ItemID.MarbleBlock, 20);
            recipe.AddTile(TileID.DemonAltar);

            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.PlatinumWatch);
            recipe2.AddIngredient(ItemID.SoulofLight, 6);
            recipe2.AddIngredient(ItemID.SoulofNight, 6);
            recipe2.AddIngredient(ItemID.GraniteBlock, 20);
            recipe2.AddIngredient(ItemID.MarbleBlock, 20);
            recipe2.AddTile(TileID.DemonAltar);

            recipe2.Register();
        }

        public override bool? UseItem(Player player)
        { // it doesn't, sorry :P
            SoundEngine.PlaySound(SoundID.Item4, player.Center);
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.dayTime = !Main.dayTime;
                Main.time = 0;
                if (Main.dayTime)
                {
                    Main.NewText("The sun has risen once again", 175, 75, 255);
                }
                else Main.NewText("The moon has risen once again", 175, 75, 255);
            }

            /*if (Main.netMode != NetmodeID.SinglePlayer && (player.whoAmI == Main.LocalPlayer.whoAmI))
            {
                ModPacket timePacket = ModContent.GetInstance<tsorcRevamp>().GetPacket();
                timePacket.Write(tsorcPacketID.SyncTimeChange);
                timePacket.Write(!Main.dayTime);
                timePacket.Write(0);
                timePacket.Send();
            }*/
            return true;
        }

        public override void UpdateInventory(Player player)
        {
            player.accWatch = 3;
        }
    }
}