using BepInEx;
using BepInEx.Logging;
using ScifiBox.Behaviour;
using ScifiBox.Misc;
using HarmonyLib;
using LethalLib.Modules;
using System.IO;
using System.Reflection;
using UnityEngine;
using ScifiBox.Input;
using ScifiBox.Compat;
using LethalLib.Extras;
using System.Collections.Generic;
using System.Linq;
using System;
namespace ScifiBox
{
    [BepInPlugin(Metadata.GUID,Metadata.NAME,Metadata.VERSION)]
    [BepInDependency("com.sigurd.csync")]
    [BepInDependency("evaisa.lethallib")]
    [BepInDependency("com.rune580.LethalCompanyInputUtils")]
    [BepInDependency("com.github.WhiteSpike.CustomItemBehaviourLibrary")]
    public class Plugin : BaseUnityPlugin
    {
        internal static readonly Harmony harmony = new(Metadata.GUID);
        internal static readonly ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(Metadata.NAME);

        public new static PluginConfig Config;

        void Awake()
        {
            // netcode patching stuff
            IEnumerable<Type> types;
            try
            {
                types = Assembly.GetExecutingAssembly().GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null);
            }
            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                    if (attributes.Length > 0)
                    {
                        method.Invoke(null, null);
                    }
                }
            }
            Config = new PluginConfig(base.Config);

            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "whitespike.scifibox");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);
            string root = "Assets/Sci-Fi Box/";

            Item ScifiBoxItem = ScriptableObject.CreateInstance<Item>();
            ScifiBoxItem.name = "ScifiBoxItemProperties";
            ScifiBoxItem.allowDroppingAheadOfPlayer = Config.DROP_AHEAD_PLAYER;
            ScifiBoxItem.canBeGrabbedBeforeGameStart = Config.GRABBED_BEFORE_START;
            ScifiBoxItem.canBeInspected = false;
            ScifiBoxItem.creditsWorth = Config.PRICE;
            ScifiBoxItem.floorYOffset = 0;
            ScifiBoxItem.restingRotation = new Vector3(0f, 0f, 0f);
            ScifiBoxItem.rotationOffset = new Vector3(0f, 0f, 0f);
            ScifiBoxItem.positionOffset = new Vector3(0f, 0f, 0f);
            ScifiBoxItem.verticalOffset = 0.2f;
            ScifiBoxItem.weight = 0.99f + (Config.WEIGHT / 100f);
            ScifiBoxItem.minValue = Config.MINIMUM_VALUE;
            ScifiBoxItem.maxValue = Config.MAXIMUM_VALUE;
            ScifiBoxItem.isScrap = false;
            ScifiBoxItem.twoHanded = true;
            ScifiBoxItem.itemIcon = bundle.LoadAsset<Sprite>(root + "Icon.png");
            ScifiBoxItem.spawnPrefab = bundle.LoadAsset<GameObject>(root + "ScifiBox.prefab");
            ScifiBoxItem.spawnPrefab.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            ScifiBoxItem.dropSFX = bundle.LoadAsset<AudioClip>(root + "Drop.ogg");
            ScifiBoxItem.grabSFX = bundle.LoadAsset<AudioClip>(root + "Grab.ogg");
            ScifiBoxItem.pocketSFX = bundle.LoadAsset<AudioClip>(root + "Pocket.ogg");
            ScifiBoxItem.throwSFX = bundle.LoadAsset<AudioClip>(root + "Throw.ogg");
            ScifiBoxItem.highestSalePercentage = Config.HIGHEST_SALE_PERCENTAGE;
            ScifiBoxItem.itemName = ScifiBoxBehaviour.ITEM_NAME;
            ScifiBoxItem.itemSpawnsOnGround = true;
            ScifiBoxItem.isConductiveMetal = Config.CONDUCTIVE;
            ScifiBoxItem.requiresBattery = false;
            ScifiBoxItem.batteryUsage = 0f;
            ScifiBoxItem.twoHandedAnimation = true;
            ScifiBoxItem.grabAnim = "HoldJetpack";

            ScifiBoxBehaviour grabbableObject = ScifiBoxItem.spawnPrefab.AddComponent<ScifiBoxBehaviour>();
            grabbableObject.itemProperties = ScifiBoxItem;
            grabbableObject.grabbable = true;
            grabbableObject.grabbableToEnemies = true;
            Utilities.FixMixerGroups(ScifiBoxItem.spawnPrefab);
            NetworkPrefabs.RegisterNetworkPrefab(ScifiBoxItem.spawnPrefab);

            Item scrapScifiBoxItem = ScriptableObject.CreateInstance<Item>();
            scrapScifiBoxItem.name = "ScrapScifiBoxItemProperties";
            scrapScifiBoxItem.allowDroppingAheadOfPlayer = Config.DROP_AHEAD_PLAYER;
            scrapScifiBoxItem.canBeGrabbedBeforeGameStart = Config.GRABBED_BEFORE_START;
            scrapScifiBoxItem.canBeInspected = false;
            scrapScifiBoxItem.creditsWorth = Config.PRICE;
            scrapScifiBoxItem.floorYOffset = 0;
            scrapScifiBoxItem.restingRotation = new Vector3(0f, 0f, 0f);
            scrapScifiBoxItem.rotationOffset = new Vector3(0f, 0f, 0f);
            scrapScifiBoxItem.positionOffset = new Vector3(0f, 0f, 0f);
            scrapScifiBoxItem.verticalOffset = 0.2f;
            scrapScifiBoxItem.weight = 0.99f + (Config.WEIGHT / 100f);
            scrapScifiBoxItem.minValue = Config.MINIMUM_VALUE;
            scrapScifiBoxItem.maxValue = Config.MAXIMUM_VALUE;
            scrapScifiBoxItem.isScrap = true;
            scrapScifiBoxItem.twoHanded = true;
            scrapScifiBoxItem.itemIcon = bundle.LoadAsset<Sprite>(root + "Icon.png");
            scrapScifiBoxItem.spawnPrefab = bundle.LoadAsset<GameObject>(root + "ScrapScifiBox.prefab");
            scrapScifiBoxItem.spawnPrefab.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            scrapScifiBoxItem.dropSFX = bundle.LoadAsset<AudioClip>(root + "Drop.ogg");
            scrapScifiBoxItem.grabSFX = bundle.LoadAsset<AudioClip>(root + "Grab.ogg");
            scrapScifiBoxItem.pocketSFX = bundle.LoadAsset<AudioClip>(root + "Pocket.ogg");
            scrapScifiBoxItem.throwSFX = bundle.LoadAsset<AudioClip>(root + "Throw.ogg");
            scrapScifiBoxItem.highestSalePercentage = Config.HIGHEST_SALE_PERCENTAGE;
            scrapScifiBoxItem.itemName = "Scrap " + ScifiBoxBehaviour.ITEM_NAME;
            scrapScifiBoxItem.itemSpawnsOnGround = true;
            scrapScifiBoxItem.isConductiveMetal = Config.CONDUCTIVE;
            scrapScifiBoxItem.requiresBattery = false;
            scrapScifiBoxItem.batteryUsage = 0f;
            scrapScifiBoxItem.twoHandedAnimation = true;
            scrapScifiBoxItem.grabAnim = "HoldJetpack";

            ScifiBoxBehaviour scrapGabbableObject = scrapScifiBoxItem.spawnPrefab.AddComponent<ScifiBoxBehaviour>();
            scrapGabbableObject.itemProperties = scrapScifiBoxItem;
            scrapGabbableObject.grabbable = true;
            scrapGabbableObject.grabbableToEnemies = true;
            Utilities.FixMixerGroups(scrapScifiBoxItem.spawnPrefab);
            NetworkPrefabs.RegisterNetworkPrefab(scrapScifiBoxItem.spawnPrefab);

            switch (Config.SPAWN_MODE.Value)
            {
                case ScifiBoxBehaviour.SpawnMode.Store:
                    {
                        TerminalNode infoNode = SetupInfoNode();
                        Items.RegisterShopItem(shopItem: ScifiBoxItem, itemInfo: infoNode, price: ScifiBoxItem.creditsWorth);
                        Items.RegisterItem(scrapScifiBoxItem);
                        break;
                    }
                case ScifiBoxBehaviour.SpawnMode.Scrap:
                    {
                        Items.RegisterItem(ScifiBoxItem);
                        Items.RegisterScrap(spawnableItem: scrapScifiBoxItem, rarity: Config.RARITY, levelFlags: Levels.LevelTypes.All);
                        break;
                    }
                case ScifiBoxBehaviour.SpawnMode.LimitedScrap:
                    {
                        Items.RegisterItem(ScifiBoxItem);
                        RegisterLimitedScrap(ref scrapScifiBoxItem);
                        break;
                    }
                case ScifiBoxBehaviour.SpawnMode.StoreAndScrap:
                    {
                        TerminalNode infoNode = SetupInfoNode();
                        Items.RegisterShopItem(shopItem: ScifiBoxItem, itemInfo: infoNode, price: ScifiBoxItem.creditsWorth);
                        Items.RegisterScrap(spawnableItem: scrapScifiBoxItem, rarity: Config.RARITY, levelFlags: Levels.LevelTypes.All);
                        break;
                    }
                case ScifiBoxBehaviour.SpawnMode.StoreAndLimitedScrap:
                    {
                        TerminalNode infoNode = SetupInfoNode();
                        Items.RegisterShopItem(shopItem: ScifiBoxItem, itemInfo: infoNode, price: ScifiBoxItem.creditsWorth);
                        RegisterLimitedScrap(ref scrapScifiBoxItem);
                        break;
                    }
            }

            InputUtilsCompat.Init();
            harmony.PatchAll(typeof(Keybinds));

            mls.LogInfo($"{Metadata.NAME} {Metadata.VERSION} has been loaded successfully.");
        }

        void RegisterLimitedScrap(ref Item item)
        {
            Items.RegisterItem(item);
            AnimationCurve curve = new(new Keyframe(0, 0), new Keyframe(1f - Config.SPAWN_CHANCE.Value, 1), new Keyframe(1, 1));
            SpawnableMapObjectDef mapObjDef = ScriptableObject.CreateInstance<SpawnableMapObjectDef>();
            mapObjDef.spawnableMapObject = new SpawnableMapObject
            {
                prefabToSpawn = item.spawnPrefab
            };
            MapObjects.RegisterMapObject(mapObjDef, Levels.LevelTypes.All, (_) => curve);
        }
        internal static TerminalNode SetupInfoNode()
        {
            TerminalNode infoNode = ScriptableObject.CreateInstance<TerminalNode>();
            infoNode.displayText += GetDisplayInfo() + "\n";
            infoNode.clearPreviousText = true;
            return infoNode;
        }
        public static string GetDisplayInfo()
        {
            return $"A portable container which has a maximum capacity of {Config.MAXIMUM_AMOUNT_ITEMS.Value}" +
                $" and reduces the effective weight of the inserted items by {Config.WEIGHT_REDUCTION_MULTIPLIER.Value * 100} %.\n" +
                $"It weighs {Config.WEIGHT.Value} lbs";
        }
    }   
}
