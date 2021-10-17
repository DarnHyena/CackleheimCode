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

namespace CackleWolf
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleWolf : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleWolf";
        public const string PluginName = "CackleWolf";
        public const string PluginVersion = "1.0.0";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;
        private GameObject ChestObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle WolfBundle = AssetUtils.LoadAssetBundleFromResources("itemtier06", typeof(CackleWolf).Assembly);
            HatObj = WolfBundle.LoadAsset<GameObject>("chWoHelm");
            PantObj = WolfBundle.LoadAsset<GameObject>("chWoPants");
            CapeObj = WolfBundle.LoadAsset<GameObject>("chWoVest");
            ChestObj = WolfBundle.LoadAsset<GameObject>("chWoCloak");
            WolfBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                CraftingStation = "forge", 
                MinStationLevel = 1,  
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "TrophyWolf",
                        Amount = 5,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "WolfPelt",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Silver",
                        Amount = 20,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(hatItem);
                
            //============================//

            CustomItem capeItem = new CustomItem(CapeObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "TrophyWolf",
                        Amount = 1,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "WolfPelt",
                        Amount = 6,
                        AmountPerLevel = 4
                    },
                    new RequirementConfig()
                    {
                        Item = "Silver",
                        Amount = 4,
                        AmountPerLevel = 2
                    }
                }
            });
            ItemManager.Instance.AddItem(capeItem);

            //============================//

            CustomItem pantItem = new CustomItem(PantObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "WolfFang",
                        Amount = 4,
                        AmountPerLevel = 1
                    },
                    new RequirementConfig()
                    {
                        Item = "WolfPelt",
                        Amount = 5,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Silver",
                        Amount = 20,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(pantItem);

            //============================//

            CustomItem chestItem = new CustomItem(ChestObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "Chain",
                        Amount = 1,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "WolfPelt",
                        Amount = 5,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Silver",
                        Amount = 20,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(chestItem);

        //============================//

        //===Item Names, Description===//
        //========&Localization========//

        LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = { 
                    {"chWH", "[CH]Wolf Helm" },
                    {"chWH_D", "Wolf skull lined with fur to keep your own skull from turning into a numb skull"},
                    {"chWC", "[CH]Wolf Cloak" },
                    {"chWC_D", "Bulky heavy fur scarf for those hardened adventurers in the mountains"},
                    {"chWV", "[CH]Wolf Vest" },
                    {"chWV_D", "Dashing little furred vest to help new explorers ward off the cold"},
                    {"chWP", "[CH]Wolf Pants" },
                    {"chWP_D", "Yet another pair of pants"},
                }
            });
        }
    }
}