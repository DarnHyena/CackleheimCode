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

namespace CackleTroll
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleTroll : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleTroll";
        public const string PluginName = "CackleTroll";
        public const string PluginVersion = "0.0.1";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;

        private void Awake()
        {
            //========ASSETBUNDLES========//

            AssetBundle trollBundle = AssetUtils.LoadAssetBundleFromResources("itemtier02", typeof(CackleTroll).Assembly);
            HatObj = trollBundle.LoadAsset<GameObject>("CKTroll_Hat");
            PantObj = trollBundle.LoadAsset<GameObject>("CKTroll_Pants");
            CapeObj = trollBundle.LoadAsset<GameObject>("CKTroll_Scarf");
            trollBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
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
            ItemManager.Instance.AddItem(hatItem);

            //============================//

            CustomItem capeItem = new CustomItem(CapeObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
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
            ItemManager.Instance.AddItem(capeItem);

            //============================//

            CustomItem pantItem = new CustomItem(PantObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
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

            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = {
                    {"cktrollhat", "[CH]Troll Hat" },
                    {"cktrollhat_D", "Great for keeping the sun out the eyes"},
                    {"cktrollscarf", "[CH]Troll Scarf" },
                    {"cktrollscarf_D", "A simple scarf with a decorative chunk of some poor souls rib cage you found in the woods"},
                    {"cktrollpant", "[CH]Troll Pants" },
                    {"cktrollpant_D", "A hardy pair of overalls for sneaky farmers. Even comes with extra bones for snacking"},
                }
            });
        }
    }
}