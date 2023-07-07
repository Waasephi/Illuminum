using Illuminum.Items.Materials.HM;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.HM.Dragon
{
	[AutoloadEquip(EquipType.Head)]
	public class DragonscaleHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			// DisplayName.SetDefault("Dragonscale Helm");
			/* Tooltip.SetDefault("+14% Melee Damage" +
                "\n+15% Damage Reduction"); */
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.value = 750;
			Item.rare = ItemRarityID.Red;
			Item.defense = 20;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) *= 1.14f;
			player.endurance *= 1.15f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DragonscalePlatemail>() && legs.type == ModContent.ItemType<DragonscaleGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			player.setBonus = "Taking damage makes the player explode, Melee attacks inflict Betsy's Curse, +20% melee speed.";
			modPlayer.dragonSet = true;
			player.GetAttackSpeed(DamageClass.Melee) *= 1.3f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DragonScale>(), 10);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}