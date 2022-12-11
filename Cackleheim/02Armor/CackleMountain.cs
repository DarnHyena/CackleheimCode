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
using System.Collections.Generic;
using UnityEngine;

namespace CackleMountain
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleMountain : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleMountain";
        public const string PluginName = "CackleMountain";
        public const string PluginVersion = "2.2.0";

        private GameObject WHatObj;
        private GameObject WPantObj;
        private GameObject WCapeObj;
        private GameObject WChestObj;

        private GameObject CuPantObj;
        private GameObject CuChestObj;
        private GameObject CuHatObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle MountainBundle = AssetUtils.LoadAssetBundleFromResources("itemmountain", typeof(CackleMountain).Assembly);
            WHatObj = MountainBundle.LoadAsset<GameObject>("chWoHelm");
            WPantObj = MountainBundle.LoadAsset<GameObject>("chWoPants");
            WCapeObj = MountainBundle.LoadAsset<GameObject>("chWoVest");
            WChestObj = MountainBundle.LoadAsset<GameObject>("chWoCloak");

            CuPantObj = MountainBundle.LoadAsset<GameObject>("chCuSuit");
            CuChestObj = MountainBundle.LoadAsset<GameObject>("chCuTunic");
            CuHatObj = MountainBundle.LoadAsset<GameObject>("chCuMask");
            MountainBundle.Unload(false);


            //==========WOLF==========//

            CustomItem WhatItem = new CustomItem(WHatObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(WhatItem);

            CustomItem WcapeItem = new CustomItem(WCapeObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(WcapeItem);

            CustomItem WpantItem = new CustomItem(WPantObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(WpantItem);

            CustomItem WchestItem = new CustomItem(WChestObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(WchestItem);

            //==========CAVE==========//

            CustomItem CuhatItem = new CustomItem(CuHatObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(CuhatItem);

            CustomItem CupantItem = new CustomItem(CuPantObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(CupantItem);

            CustomItem CuchestItem = new CustomItem(CuChestObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(CuchestItem);

            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chWH", "[CH]Wolf Helm" },
                    {"chWH_D", "Wolf skull lined with fur to keep your own skull from turning into a numb skull"},
                    {"chWC", "[CH]Wolf Cloak" },
                    {"chWC_D", "Bulky heavy fur scarf for those hardened adventurers in the mountains"},
                    {"chWV", "[CH]Wolf Vest" },
                    {"chWV_D", "Dashing little furred vest to help new explorers ward off the cold"},
                    {"chWP", "[CH]Wolf Pants" },
                    {"chWP_D", "Yet another pair of pants"},

                    {"chCM", "[CH]Cultist Mask" },
                    {"chCM_D", ""},
                    {"chCT", "[CH]Cultist Tunic" },
                    {"chCT_D", ".."},
                    {"chCS", "[CH]Cultist Suit" },
                    {"chCS_D", ".."},

            });
        }
    }
}