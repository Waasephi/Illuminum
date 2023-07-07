using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Tools
{
	public class GlacialHatchet : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Glacial Hatchet");
			// Tooltip.SetDefault("Inflicts frostbite");
		}

		public override void SetDefaults()
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Melee;
			Item.width = 44;
			Item.height = 36;
			Item.useTime = 18;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.axe = 20;
			Item.crit = 10;
		}

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
            // 60 frames = 1 second
            target.AddBuff(BuffID.Frostburn2, 60);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IceBlock, 25);
			recipe.AddIngredient(Mod, "VialofEvil", 6);
			recipe.AddIngredient(ItemID.GoldAxe);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.IceBlock, 25);
			recipe2.AddIngredient(Mod, "VialofEvil", 6);
			recipe2.AddIngredient(ItemID.PlatinumAxe);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}