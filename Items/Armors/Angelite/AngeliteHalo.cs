using Illuminum.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Angelite
{
	[AutoloadEquip(EquipType.Head)]
	public class AngeliteHalo : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Angelite Halo");
			Tooltip.SetDefault("+12% Damage" +
                "\n+40 Mana");
			ArmorIDs.Head.Sets.DrawFullHair[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 14;
			Item.value = 750;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) *= 1.12f;
			//player.endurance *= 1.05f;
			player.statManaMax2 += 40;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<AngeliteChestplate>() && legs.type == ModContent.ItemType<AngeliteGreaves>();
		}

		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			color = drawPlayer.GetImmuneAlphaPure(Color.White, shadow);
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Gives a short amount of increased flight time.";
			player.wingTimeMax += 50;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RefinedAngelite>(), 10);
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.Register();
		}
	}
}