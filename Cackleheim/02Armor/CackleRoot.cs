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

namespace CackleRoot
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleRoot : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleRoot";
        public const string PluginName = "CackleRoot";
        public const string PluginVersion = "1.0.0";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;
        //private GameObject ChestObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle RootBundle = AssetUtils.LoadAssetBundleFromResources("itemtier08", typeof(CackleRoot).Assembly);
            HatObj = RootBundle.LoadAsset<GameObject>("chRoHelm");
            PantObj = RootBundle.LoadAsset<GameObject>("chRoPants");
            CapeObj = RootBundle.LoadAsset<GameObject>("chRoChest");
            RootBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench", 
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Root",
                        Amount = 10,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "ElderBark",
                        Amount = 10,
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
                        Item = "Root",
                        Amount = 10,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "ElderBark",
                        Amount = 10,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(capeItem);
            
            //============================//

            CustomItem pantItem = new CustomItem(PantObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "Root",
                        Amount = 10,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "ElderBark",
                        Amount = 10,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(pantItem);

            //============================//

            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                {"chRoH", "[CH]Root Helm" },
                {"chRoH_D", "Quite handy against bee stings"},
                {"chRoC", "[CH]Root Armor" },
                {"chRoC_D", "Sturdy old wooden armor"},
                {"chRoP", "[CH]Root Fit" },
                {"chRoP_D", "Latest in Bog Fashion"},
            });
        }
    }
}