using BepInEx.Configuration;
using CSync.Extensions;
using CSync.Lib;
using ScifiBox.Behaviour;
using ScifiBox.Util;
using System.Runtime.Serialization;
using CustomItemBehaviourLibrary.AbstractItems;

namespace ScifiBox.Misc
{
    [DataContract]
    public class PluginConfig : SyncedConfig2<PluginConfig>
    {
        [field: SyncedEntryField] public SyncedEntry<bool> SCAN_NODE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> WEIGHT { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> DROP_AHEAD_PLAYER { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> GRABBED_BEFORE_START { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> CONDUCTIVE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> HIGHEST_SALE_PERCENTAGE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<ContainerBehaviour.Restrictions> RESTRICTION_MODE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> MAXIMUM_AMOUNT_ITEMS { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> MAXIMUM_WEIGHT_ALLOWED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> WEIGHT_REDUCTION_MULTIPLIER { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> LOOK_SENSITIVITY_DRAWBACK { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> MOVEMENT_SLOPPY { get; set; }
        [field: SyncedEntryField] public SyncedEntry<ScifiBoxBehaviour.SpawnMode> SPAWN_MODE {  get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> MINIMUM_VALUE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> MAXIMUM_VALUE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> RARITY { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> SPAWN_CHANCE {  get; set; }
        public PluginConfig(ConfigFile cfg) : base(Metadata.GUID)
        {
            string topSection = ScifiBoxBehaviour.ITEM_NAME;

            PRICE = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_PRICE_KEY, Constants.SCIFI_BOX_PRICE_DEFAULT, Constants.SCIFI_BOX_PRICE_DESCRIPTION);
            WEIGHT = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_WEIGHT_KEY, Constants.SCIFI_BOX_WEIGHT_DEFAULT, Constants.SCIFI_BOX_WEIGHT_DESCRIPTION);
            SCAN_NODE = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_SCAN_NODE_KEY, Constants.ITEM_SCAN_NODE_DEFAULT, Constants.ITEM_SCAN_NODE_DESCRIPTION);
            DROP_AHEAD_PLAYER = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_DROP_AHEAD_PLAYER_KEY, Constants.SCIFI_BOX_DROP_AHEAD_PLAYER_DEFAULT, Constants.SCIFI_BOX_DROP_AHEAD_PLAYER_DESCRIPTION);
            CONDUCTIVE = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_CONDUCTIVE_KEY, Constants.SCIFI_BOX_CONDUCTIVE_DEFAULT, Constants.SCIFI_BOX_CONDUCTIVE_DESCRIPTION);
            GRABBED_BEFORE_START = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_GRABBED_BEFORE_START_KEY, Constants.SCIFI_BOX_GRABBED_BEFORE_START_DEFAULT, Constants.SCIFI_BOX_GRABBED_BEFORE_START_DESCRIPTION);
            HIGHEST_SALE_PERCENTAGE = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_HIGHEST_SALE_PERCENTAGE_KEY, Constants.SCIFI_BOX_HIGHEST_SALE_PERCENTAGE_DEFAULT, Constants.SCIFI_BOX_HIGHEST_SALE_PERCENTAGE_DESCRIPTION);
            RESTRICTION_MODE = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_RESTRICTION_MODE_KEY, Constants.SCIFI_BOX_RESTRICTION_MODE_DEFAULT, Constants.SCIFI_BOX_RESTRICTION_MODE_DESCRIPTION);
            MAXIMUM_WEIGHT_ALLOWED = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_MAXIMUM_WEIGHT_ALLOWED_KEY, Constants.SCIFI_BOX_MAXIMUM_WEIGHT_ALLOWED_DEFAULT, Constants.SCIFI_BOX_MAXIMUM_WEIGHT_ALLOWED_DESCRIPTION);
            MAXIMUM_AMOUNT_ITEMS = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_MAXIMUM_AMOUNT_ITEMS_KEY, Constants.SCIFI_BOX_MAXIMUM_AMOUNT_ITEMS_DEFAULT, Constants.SCIFI_BOX_MAXIMUM_AMOUNT_ITEMS_DESCRIPTION);
            WEIGHT_REDUCTION_MULTIPLIER = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_WEIGHT_REDUCTION_MULTIPLIER_KEY, Constants.SCIFI_BOX_WEIGHT_REDUCTION_MULTIPLIER_DEFAULT, Constants.SCIFI_BOX_WEIGHT_REDUCTION_MUTLIPLIER_DESCRIPTION);
            LOOK_SENSITIVITY_DRAWBACK = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_LOOK_SENSITIVITY_DRAWBACK_KEY, Constants.SCIFI_BOX_LOOK_SENSITIVITY_DRAWBACK_DEFAULT, Constants.SCIFI_BOX_LOOK_SENSITIVITY_DRAWBACK_DESCRIPTION);
            MOVEMENT_SLOPPY = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_MOVEMENT_SLOPPY_KEY, Constants.SCIFI_BOX_MOVEMENT_SLOPPY_DEFAULT, Constants.SCIFI_BOX_MOVEMENT_SLOPPY_DESCRIPTION);
            SPAWN_MODE = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_SPAWN_MODE_KEY, Constants.SCIFI_BOX_SPAWN_MODE_DEFAULT, Constants.SCIFI_BOX_SPAWN_MODE_DESCRIPTION);
            MINIMUM_VALUE = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_MINIMUM_VALUE_KEY, Constants.SCIFI_BOX_MINIMUM_VALUE_DEFAULT, Constants.SCIFI_BOX_MINIMUM_VALUE_DESCRIPTION);
            MAXIMUM_VALUE = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_MAXIMUM_VALUE_KEY, Constants.SCIFI_BOX_MAXIMUM_VALUE_DEFAULT, Constants.SCIFI_BOX_MAXIMUM_VALUE_DESCRIPTION);
            RARITY = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_RARITY_KEY, Constants.SCIFI_BOX_RARITY_DEFAULT, Constants.SCIFI_BOX_RARITY_DESCRIPTION);
            SPAWN_CHANCE = cfg.BindSyncedEntry(topSection, Constants.SCIFI_BOX_SPAWN_CHANCE_KEY, Constants.SCIFI_BOX_SPAWN_CHANCE_DEFAULT, Constants.SCIFI_BOX_SPAWN_CHANCE_DESCRIPTION);

            ConfigManager.Register(this);
        }
    }
}
