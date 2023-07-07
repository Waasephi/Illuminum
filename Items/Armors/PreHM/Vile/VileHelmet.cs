using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.PreHM.Vile
{
	[AutoloadEquip(EquipType.Head)]
	public class VileHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			// DisplayName.SetDefault("Ebondune Mask");
			// Tooltip.SetDefault("+7% Melee Damage");
			ArmorIDs.Head.Sets.DrawHead[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = false;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) *= 1.07f;
			//player.endurance *= 1.05f;
			//player.statManaMax2 += 20;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<VileChestplate>() && legs.type == ModContent.ItemType<VileLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            player.setBonus = "Upon taking damage, you get inflicted with poison." + "\nWhen poisoned you gain" + "\n+2 Life Regeneration" + "\n+5% Damage Reduction" + "\n+10% Movement Speed" + "\nAttacks deal 10 more damage" + "\n'It hurts so good'" + "";
            modPlayer.vileSet = true;
			if (player.HasBuff(BuffID.Poisoned))
			{
				player.lifeRegen += 2;
				player.endurance *= 1.05f;
				player.moveSpeed *= 1.10f;
				player.GetDamage(DamageClass.Generic).Flat += 10;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "VialofEvil", 5);
			recipe.AddIngredient(ItemID.GoldBar, 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(Mod, "VialofEvil", 5);
            recipe2.AddIngredient(ItemID.PlatinumBar, 7);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
    }
}