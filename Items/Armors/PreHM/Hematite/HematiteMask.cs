using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.PreHM.Hematite
{
	[AutoloadEquip(EquipType.Head)]
	public class HematiteMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Hematite Mask");
			Tooltip.SetDefault("+12% crit chance, +1 minion slot");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 22;
			Item.value = 1000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Generic) += 12;
			//player.endurance *= 1.05f;
			//player.statManaMax2 += 20;
			player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<HematiteChestplate>() && legs.type == ModContent.ItemType<HematiteLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			player.setBonus = "Cannot be set on fire" +
                "\nImmune to Ichor" +
                "\n+3 Life Regeneration" +
				"\nWeapons that steal your life to attack no longer take life.";
			player.lifeRegen += 3;
			player.buffImmune[69] = true; //Nice
			player.fireWalk = true;
			modPlayer.hematiteSet = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "HematiteChunk", 10);
			recipe.AddTile(Mod, "CursedForge");
			recipe.Register();
		}
	}
}