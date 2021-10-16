// Cackleheim
// a Valheim mod using Jötunn
// 
// File:    Cackleheim.cs
// Project: Cackleheim

using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace CackleBronze
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleBronze : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleBronze";
        public const string PluginName = "CackleBronze";
        public const string PluginVersion = "1.0.1";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;

        private void Awake()
        {
            //========ASSETBUNDLES========//

            AssetBundle BronzeBundle = AssetUtils.LoadAssetBundleFromResources("itemtier04", typeof(CackleBronze).Assembly);
            HatObj = BronzeBundle.LoadAsset<GameObject>("chBzHelm");
            PantObj = BronzeBundle.LoadAsset<GameObject>("chBzPants");
            CapeObj = BronzeBundle.LoadAsset<GameObject>("chBzChest");
            BronzeBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 5,
                        AmountPerLevel = 3
                    }
                }
            });
            ItemManager.Instance.AddItem(hatItem);

            //============================//

            CustomItem capeItem = new CustomItem(CapeObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 5,
                        AmountPerLevel = 3
                    }
                }
            });
            ItemManager.Instance.AddItem(capeItem);

            //============================//

            CustomItem pantItem = new CustomItem(PantObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 5,
                        AmountPerLevel = 3
                    }
                }
            });
            ItemManager.Instance.AddItem(pantItem);


            //===Item Names, Description===//
            //========&Localization========//

            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = {
                    {"chBZH", "[CH]Bronze Helm" },
                    {"chBZH_D", "Shines gracefully like a Golden Egg."},
                    {"chBZC", "[CH]Bronze Plate" },
                    {"chBZC_D", "Some say the first gnoll to forge a bronze plate shined like the sun as they got flung away by a troll."},
                    {"chBZP", "[CH]Bronze Pants " },
                    {"chBZP_D", "Those necks will think twice before biting off your shins with these plated slacks!"},
                }
            });
        }
    }
}