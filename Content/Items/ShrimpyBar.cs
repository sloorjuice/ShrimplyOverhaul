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
            // This accesses the creative catalog
            // Setting the research number to 100 before it can be fully accessed
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
        }

        public override void SetDefaults()
        {
            Item.width = 30;    // Hitbox Width from Bottom Center
            Item.height = 24;   // Hitbox Height from Bottom Center

            Item.value = Item.buyPrice(gold: 5); // Value of the item 120 = silver: 1, Cooper: 20
            Item.maxStack = 9999;
        }


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ChlorophyteBar)
                .AddIngredient(ItemID.Shrimp, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}