using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace ShrimplyOverhaul.Content.Items
{
    internal class ShrimpySword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // This accesses the creative catalog
            // Setting the research number to 100 before it can be fully accessed
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Hitbox
            Item.width = 64;
            Item.height = 64;

            // Use and Animation Style
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.autoReuse = true;

            // Damage Values
            Item.DamageType = DamageClass.Melee;
            Item.damage = 250;
            Item.knockBack = 5f;
            Item.crit = 10;

            // Misc
            Item.value = Item.buyPrice(gold: 5); // Value of the item 120 = silver: 1, Cooper: 20
            Item.value = ItemRarityID.LightPurple;
            Item.maxStack = 1;

            // Sound
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ShrimpyBar>(), 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}