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

namespace CackleLeather
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleLeather : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleLeather";
        public const string PluginName = "CackleLeather";
        public const string PluginVersion = "2.0.0";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;

        private void Awake()
        {
            //========ASSETBUNDLES========//

            AssetBundle leatherBundle = AssetUtils.LoadAssetBundleFromResources("itemtier02", typeof(CackleLeather).Assembly);
            HatObj = leatherBundle.LoadAsset<GameObject>("chLeMask");
            PantObj = leatherBundle.LoadAsset<GameObject>("chLePants");
            CapeObj = leatherBundle.LoadAsset<GameObject>("chLePoncho");
            leatherBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 6,
                        AmountPerLevel = 6
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 0,
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
                        Item = "DeerHide",
                        Amount = 6,
                        AmountPerLevel = 6
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 0,
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
                        Item = "DeerHide",
                        Amount = 6,
                        AmountPerLevel = 6
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 0,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(pantItem);


            //===Item Names, Description===//
            //========&Localization========//

            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = {
                    {"chLH", "[CH]Leather Mask" },
                    {"chLH_D", "A striking bone white mask"},
                    {"chLC", "[CH]Leather Poncho" },
                    {"chLC_D", "An enccentric cape for dashing rogues"},
                    {"chLP", "[CH]Leather Pants" },
                    {"chLP_D", "Finely tailored pants just like mother used to make"},
                }
            });
        }
    }
}