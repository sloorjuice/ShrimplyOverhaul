using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace ShrimplyOverhaul.Content.Items
{
    internal class ShrimpyBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 30;    // Hitbox Width from Bottom Center
            Item.height = 24;   // Hitbox Height from Bottom Center

            Item.value = Item.buyPrice(gold: 5); // Value of the item 120 = silver: 1, Cooper: 20
            Item.maxStack = 999;
        }
    }
}