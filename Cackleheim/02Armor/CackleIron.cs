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

namespace CackleIron
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleIron : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleIron";
        public const string PluginName = "CackleIron";
        public const string PluginVersion = "1.0.1";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;
        //private GameObject ChestObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle IronBundle = AssetUtils.LoadAssetBundleFromResources("itemtier05", typeof(CackleIron).Assembly);
            HatObj = IronBundle.LoadAsset<GameObject>("chIrHelm");
            PantObj = IronBundle.LoadAsset<GameObject>("chIrSuit");
            CapeObj = IronBundle.LoadAsset<GameObject>("chIrChest");
            IronBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                CraftingStation = "forge", //Note: These look for the name of the crafting table prefabs. 
                MinStationLevel = 1,  //Level crafting table needs to be in order to make the item. Aka, those things you place around it
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 20,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(hatItem);
                
            //============================//

            CustomItem capeItem = new CustomItem(CapeObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 20,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
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
                        Item = "Iron",
                        Amount = 20,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(pantItem);

        //============================//

        //===Item Names, Description===//
        //========&Localization========//

        LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = { //Don't include the $ for the item id, the code doesn't like those
                    {"chIH", "[CH]Iron Helm" },
                    {"chIH_D", "Forged into the most optimal shape for headbutting"},
                    {"chIC", "[CH]Iron Plate" },
                    {"chIC_D", "Comes with it's very own picnic basket!"},
                    {"chIS", "[CH]Iron Suit" },
                    {"chIS_D", "Stylish armored coveralls"},
                }
            });
        }
    }
}