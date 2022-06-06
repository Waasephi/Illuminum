using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Melee
{
	public class WoodenClub : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Wooden Club");
			Tooltip.SetDefault("BONK");
		}

		public override void SetDefaults() 
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(silver: 12);
			Item.rare = ItemRarityID.Blue;
			Item.scale = 1.2f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			SoundEngine.PlaySound(new("Illuminum/Sounds/Item/Bonk"), player.position);
			target.AddBuff(BuffID.Confused, 180);

			CombatText.NewText(target.getRect(), Color.Yellow, "Bonk", true, false);
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 16);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}