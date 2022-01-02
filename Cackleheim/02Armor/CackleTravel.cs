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

namespace CackleTraveller
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleTraveller : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleTraveller";
        public const string PluginName = "CackleTraveller";
        public const string PluginVersion = "1.0.0";

        private GameObject TravObj;

        private void Awake()
        {
            //========ASSETBUNDLES========//

            AssetBundle travelBundle = AssetUtils.LoadAssetBundleFromResources("itemtravel", typeof(CackleTraveller).Assembly);
            TravObj = travelBundle.LoadAsset<GameObject>("chTravelPack");
            travelBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem TravItem = new CustomItem(TravObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 10,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 3
                    },
                    new RequirementConfig()
                    {
                        Item = "CookedMeat",
                        Amount = 1
                    },
                }
            });
            ItemManager.Instance.AddItem(TravItem);

            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chTrav", "[CH]Travel Pack" },
                    {"chTravD", "Bulky pack to transport your stash of meat in"},
            });
        }
    }
}