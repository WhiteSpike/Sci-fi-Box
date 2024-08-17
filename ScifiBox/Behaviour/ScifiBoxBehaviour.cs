using CustomItemBehaviourLibrary.AbstractItems;
using UnityEngine.InputSystem;
using ScifiBox.Input;
using ScifiBox.Misc;
using Unity.Netcode;
using GameNetcodeStuff;
using System.Collections.Generic;
using System.Linq;

namespace ScifiBox.Behaviour
{
    public class ScifiBoxBehaviour : ContainerBehaviour
    {
        internal const string ITEM_NAME = "Sci-fi Box";
        internal const string ITEM_DESCRIPTION = "Allows carrying multiple items";

        public enum SpawnMode
        {
            /// <summary>
            /// Item will only appear in the store
            /// </summary>
            Store,
            /// <summary>
            /// Item will only appear in the dungeon with respective scrap rarity (same mechanic as other scrap items)
            /// </summary>
            Scrap,
            /// <summary>
            /// Item will only spawn one time in the dungeon with spawn chance (same mechanic as traps)
            /// </summary>
            LimitedScrap,
            /// <summary>
            /// Item will appear in both store and scrap with rarity
            /// </summary>
            StoreAndScrap,
            /// <summary>
            /// Item will appear in both store and one-time spawn in the dungeon with spawn chance
            /// </summary>
            StoreAndLimitedScrap,
        }
        protected bool KeepScanNode
        {
            get
            {
                return Plugin.Config.SCAN_NODE;
            }
        }

        public string GetDisplayInfo()
        {
            return $"A portable container which has a maximum capacity of {Plugin.Config.MAXIMUM_AMOUNT_ITEMS.Value}" +
                $" and reduces the effective weight of the inserted items by {Plugin.Config.WEIGHT_REDUCTION_MULTIPLIER.Value * 100} %.\n" +
                $"It weighs {Plugin.Config.WEIGHT.Value} lbs";
        }

        public override void Start()
        {
            base.Start();
            PluginConfig config = Plugin.Config;
            maximumAmountItems = config.MAXIMUM_AMOUNT_ITEMS.Value;
            weightReduceMultiplier = config.WEIGHT_REDUCTION_MULTIPLIER.Value;
            restriction = config.RESTRICTION_MODE;
            maximumWeightAllowed = config.MAXIMUM_WEIGHT_ALLOWED.Value;
            sloppiness = config.MOVEMENT_SLOPPY.Value;
            lookSensitivityDrawback = config.LOOK_SENSITIVITY_DRAWBACK.Value;
            makeItemsInvisible = true;
            noiseRange = 0f;
            playSounds = false;
            wheelsClip = [];
            if (itemProperties.isScrap && scrapValue <= 0)
            {
                System.Random random = new System.Random(StartOfRound.Instance.randomMapSeed + 145);
                SetScrapValue(random.Next(config.MINIMUM_VALUE.Value, config.MAXIMUM_VALUE.Value));
            }
        }
        protected override bool ShowDepositPrompts()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;
            return player.isHoldingObject && playerHeldBy != player;
        }

        protected override void SetupScanNodeProperties()
        {
            if (itemProperties.isScrap) return;
            ScanNodeProperties scanNodeProperties = GetComponentInChildren<ScanNodeProperties>();
            if (scanNodeProperties != null) Tools.ChangeScanNode(ref scanNodeProperties, (Tools.NodeType)scanNodeProperties.nodeType, header: ITEM_NAME, subText: ITEM_DESCRIPTION);
            else Tools.AddGeneralScanNode(objectToAddScanNode: gameObject, header: ITEM_NAME, subText: ITEM_DESCRIPTION);
        }

        protected override string[] SetupContainerTooltips()
        {
            string dropAllItemsBind = IngameKeybinds.Instance.DropAllItemsKey.GetBindingDisplayString();
            return [$"Drop all items: [{dropAllItemsBind}]"];
        }
    }
}
