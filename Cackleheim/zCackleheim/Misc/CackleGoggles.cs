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

namespace CackleGoggles
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleGoggles : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleGoggles";
        public const string PluginName = "CackleGoggles";
        public const string PluginVersion = "0.0.1";

        private GameObject HatObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle GogglesBundle = AssetUtils.LoadAssetBundleFromResources("itemgoggles", typeof(CackleGoggles).Assembly);
            HatObj = GogglesBundle.LoadAsset<GameObject>("chGoggles");
            GogglesBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                CraftingStation = "forge", //Note: These look for the name of the crafting table prefabs. 
                MinStationLevel = 2,  //Level crafting table needs to be in order to make the item. Aka, those things you place around it
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Coins",
                        Amount = 400,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "SurtlingCore",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Tin",
                        Amount = 5,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(hatItem);


            //============================//

            //===Item Names, Description===//
            //========&Localization========//

            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = { //Don't include the $ for the item id, the code doesn't like those
                    {"chgog", "[CH]Illuminated Visors" },
                    {"chgog_D", "Runic visors harnessing the power of cores to light the way"},
                }
            });
        }
    }
}