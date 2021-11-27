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

namespace CackleTroll
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleTroll : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleTroll";
        public const string PluginName = "CackleTroll";
        public const string PluginVersion = "2.0.1";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;

        private void Awake()
        {
            //========ASSETBUNDLES========//

            AssetBundle trollBundle = AssetUtils.LoadAssetBundleFromResources("itemtier03", typeof(CackleTroll).Assembly);
            HatObj = trollBundle.LoadAsset<GameObject>("chTrHat");
            PantObj = trollBundle.LoadAsset<GameObject>("chTrPants");
            CapeObj = trollBundle.LoadAsset<GameObject>("chTrScarf");
            trollBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "TrollHide",
                        Amount = 5,
                        AmountPerLevel = 3
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 3,
                        AmountPerLevel = 2
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
                        Item = "TrollHide",
                        Amount = 5,
                        AmountPerLevel = 3
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
                        Item = "TrollHide",
                        Amount = 5,
                        AmountPerLevel = 3
                    }
                }
            });
            ItemManager.Instance.AddItem(pantItem);


            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chTH", "[CH]Troll Hat" },
                    {"chTH_D", "Great for keeping the sun out the eyes"},
                    {"chTS", "[CH]Troll Scarf" },
                    {"chTS_D", "A simple scarf with a decorative chunk of some poor souls rib cage you found in the woods"},
                    {"chTP", "[CH]Troll Pants" },
                    {"chTP_D", "A hardy pair of overalls for sneaky farmers. Even comes with extra bones for snacking"},
            });
        }
    }
}