using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShrimplyOverhaul.Content.NPCs
{
    [AutoloadHead]
    public class Shrimp : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shrimp");
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 35;
            NPC.lifeMax = 300;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemID.Shrimp)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Shrimply",
                "Shrimplet",
                "Shrimpy",
                "Shrimper"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Summon the shrimp lord";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //Wooden Arrow
            shop.item[nextSlot].SetDefaults(ItemID.Shrimp, false);
            shop.item[nextSlot].value = 1;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<ShrimpyBar>(), false);
            shop.item[nextSlot].value = 1;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<ShrimpySword>(), false);
            shop.item[nextSlot].value = 500;          
            nextSlot++;

            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PlatinumBow, false);
                nextSlot++;
            }
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Shrimp>());
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "I don't normally enjoy being out of the water..";
                case 1:
                    return "This is the second case";
                case 2:
                    return "This is the third case";
                default:
                    return "I AM A FUCKING SHRIMP";
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 15;
            knockback = 2f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 5;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.WoodenArrowFriendly;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.GoldBow, 1, false, 0, false, false);
        }
    }
}