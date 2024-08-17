using CustomItemBehaviourLibrary.AbstractItems;
using ScifiBox.Behaviour;
namespace ScifiBox.Util
{
    internal static class Constants
    {
        internal const string ITEM_SCAN_NODE_KEY_FORMAT = "Enable scan node of {0}";
        internal const bool ITEM_SCAN_NODE_DEFAULT = true;
        internal const string ITEM_SCAN_NODE_DESCRIPTION = "Shows a scan node on the item when scanning";

        internal const string SCIFI_BOX_PRICE_KEY = $"{ScifiBoxBehaviour.ITEM_NAME} price";
        internal const int SCIFI_BOX_PRICE_DEFAULT = 500;
        internal const string SCIFI_BOX_PRICE_DESCRIPTION = $"Price for {ScifiBoxBehaviour.ITEM_NAME}.";

        internal const string SCIFI_BOX_WEIGHT_KEY = "Item weight";
        internal const int SCIFI_BOX_WEIGHT_DEFAULT = 15;
        internal const string SCIFI_BOX_WEIGHT_DESCRIPTION = "Weight (in lbs)";

        internal const string SCIFI_BOX_CONDUCTIVE_KEY = "Conductive";
        internal const bool SCIFI_BOX_CONDUCTIVE_DEFAULT = true;
        internal const string SCIFI_BOX_CONDUCTIVE_DESCRIPTION = "Wether it attracts lightning to the item or not. (Or other mechanics that rely on item being conductive)";

        internal const string SCIFI_BOX_DROP_AHEAD_PLAYER_KEY = "Drop ahead of player when dropping";
        internal const bool SCIFI_BOX_DROP_AHEAD_PLAYER_DEFAULT = true;
        internal const string SCIFI_BOX_DROP_AHEAD_PLAYER_DESCRIPTION = "If on, the item will drop infront of the player. Otherwise, drops underneath them and slightly infront.";

        internal const string SCIFI_BOX_GRABBED_BEFORE_START_KEY = "Grabbable before game start";
        internal const bool SCIFI_BOX_GRABBED_BEFORE_START_DEFAULT = true;
        internal const string SCIFI_BOX_GRABBED_BEFORE_START_DESCRIPTION = "Allows wether the item can be grabbed before hand or not";

        internal const string SCIFI_BOX_HIGHEST_SALE_PERCENTAGE_KEY = "Highest Sale Percentage";
        internal const int SCIFI_BOX_HIGHEST_SALE_PERCENTAGE_DEFAULT = 50;
        internal const string SCIFI_BOX_HIGHEST_SALE_PERCENTAGE_DESCRIPTION = "Maximum percentage of sale allowed when this item is selected for a sale.";

        internal const string SCIFI_BOX_RESTRICTION_MODE_KEY = $"Restrictions on the {ScifiBoxBehaviour.ITEM_NAME} Item";
        internal const ContainerBehaviour.Restrictions SCIFI_BOX_RESTRICTION_MODE_DEFAULT = ScifiBoxBehaviour.Restrictions.ItemCount;
        internal const string SCIFI_BOX_RESTRICTION_MODE_DESCRIPTION = $"Restriction applied when trying to insert an item on the {ScifiBoxBehaviour.ITEM_NAME}.\n" +
                                                                        "Supported values: None, ItemCount, TotalWeight, All";

        internal const string SCIFI_BOX_MAXIMUM_WEIGHT_ALLOWED_KEY = $"Maximum amount of weight for {ScifiBoxBehaviour.ITEM_NAME}";
        internal const float SCIFI_BOX_MAXIMUM_WEIGHT_ALLOWED_DEFAULT = 100f;
        internal const string SCIFI_BOX_MAXIMUM_WEIGHT_ALLOWED_DESCRIPTION = $"How much weight (in lbs and after weight reduction multiplier is applied on the stored items) a {ScifiBoxBehaviour.ITEM_NAME} can carry in items before it is considered full.";

        internal const string SCIFI_BOX_MAXIMUM_AMOUNT_ITEMS_KEY = $"Maximum amount of items for {ScifiBoxBehaviour.ITEM_NAME}";
        internal const int SCIFI_BOX_MAXIMUM_AMOUNT_ITEMS_DEFAULT = 4;
        internal const string SCIFI_BOX_MAXIMUM_AMOUNT_ITEMS_DESCRIPTION = $"Amount of items allowed before the {ScifiBoxBehaviour.ITEM_NAME} is considered full";

        internal const string SCIFI_BOX_MINIMUM_VALUE_KEY = $"Minimum scrap value of {ScifiBoxBehaviour.ITEM_NAME}";
        internal const int SCIFI_BOX_MINIMUM_VALUE_DEFAULT = 50;
        internal const string SCIFI_BOX_MINIMUM_VALUE_DESCRIPTION = "Lower boundary of the scrap's possible value";

        internal const string SCIFI_BOX_SPAWN_CHANCE_KEY = $"Spawn Chance of the {ScifiBoxBehaviour.ITEM_NAME} Item";
        internal const float SCIFI_BOX_SPAWN_CHANCE_DEFAULT = 0.1f;
        internal const string SCIFI_BOX_SPAWN_CHANCE_DESCRIPTION = $"How likely it is for a {ScifiBoxBehaviour.ITEM_NAME} item to spawn when landing on a moon. (0.1 = 10%). Only relevant when LimitedScrap is chosen in the spawn mode";

        internal const string SCIFI_BOX_RARITY_KEY = $"Scrap Rarity of the {ScifiBoxBehaviour.ITEM_NAME} Item";
        internal const int SCIFI_BOX_RARITY_DEFAULT = 10;
        internal const string SCIFI_BOX_RARITY_DESCRIPTION = $"Spawn weight of {ScifiBoxBehaviour.ITEM_NAME} when generating scrap for the level. Only relevant when Scrap is chosen in the spawn mode";

        internal const string SCIFI_BOX_MAXIMUM_VALUE_KEY = $"Maximum scrap value of {ScifiBoxBehaviour.ITEM_NAME}";
        internal const int SCIFI_BOX_MAXIMUM_VALUE_DEFAULT = 100;
        internal const string SCIFI_BOX_MAXIMUM_VALUE_DESCRIPTION = "Higher boundary of the scrap's possible value";

        internal const string SCIFI_BOX_WEIGHT_REDUCTION_MULTIPLIER_KEY = $"Weight reduction multiplier for {ScifiBoxBehaviour.ITEM_NAME}";
        internal const float SCIFI_BOX_WEIGHT_REDUCTION_MULTIPLIER_DEFAULT = 0.7f;
        internal const string SCIFI_BOX_WEIGHT_REDUCTION_MUTLIPLIER_DESCRIPTION = $"How much an item's weight will be ignored to the {ScifiBoxBehaviour.ITEM_NAME}'s total weight";

        internal const string SCIFI_BOX_LOOK_SENSITIVITY_DRAWBACK_KEY = $"Look sensitivity drawback of the {ScifiBoxBehaviour.ITEM_NAME} Item";
        internal const float SCIFI_BOX_LOOK_SENSITIVITY_DRAWBACK_DEFAULT = 0.6f;
        internal const string SCIFI_BOX_LOOK_SENSITIVITY_DRAWBACK_DESCRIPTION = $"Value multiplied on the player's look sensitivity when moving with the {ScifiBoxBehaviour.ITEM_NAME} Item";

        internal const string SCIFI_BOX_MOVEMENT_SLOPPY_KEY = $"Sloppiness of the {ScifiBoxBehaviour.ITEM_NAME} Item";
        internal const float SCIFI_BOX_MOVEMENT_SLOPPY_DEFAULT = 7f;
        internal const string SCIFI_BOX_MOVEMENT_SLOPPY_DESCRIPTION = $"Value multiplied on the player's movement to give the feeling of drifting while carrying the {ScifiBoxBehaviour.ITEM_NAME} Item";

        internal const string SCIFI_BOX_SPAWN_MODE_KEY = $"Spawn Mode";
        internal const ScifiBoxBehaviour.SpawnMode SCIFI_BOX_SPAWN_MODE_DEFAULT = ScifiBoxBehaviour.SpawnMode.LimitedScrap;
        internal const string SCIFI_BOX_SPAWN_MODE_DESCRIPTION = "Accepted modes: Store (only in the Company Store), Scrap (spawns based on rarity), LimitedScrap (spawns only once based on spawn chance), StoreAndScrap, StoreAndLimitedScrap";

        internal const string DROP_ALL_ITEMS_SCIFI_BOX_KEYBIND_NAME = "Drop all items from Sci-fi Box";
        internal const string DROP_ALL_ITEMS_SCIFI_BOX_DEFAULT_KEYBIND = "<Mouse>/middleButton";

        internal const string DROP_RANDOM_ITEM_SCIFI_BOX_KEYBIND_NAME = "Drop Random Item";
        internal const string DROP_RANDOM_ITEM_SCIFI_BOX_DEFAULT_KEYBIND = "<Keyboard>/r";

        internal static readonly string SCIFI_BOX_SCAN_NODE_KEY = string.Format(ITEM_SCAN_NODE_KEY_FORMAT, ScifiBoxBehaviour.ITEM_NAME);
    }
}
