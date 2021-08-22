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

namespace CackleRags
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleRags : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleRags";
        public const string PluginName = "CackleRags";
        public const string PluginVersion = "0.0.1";

        private GameObject HoodObj;
        private GameObject PantObj;

        private void Awake()
        {
            //========ASSETBUNDLES========//

            AssetBundle ragBundle = AssetUtils.LoadAssetBundleFromResources("itemtier00", typeof(CackleRags).Assembly);
            HoodObj = ragBundle.LoadAsset<GameObject>("CKRag_Hood");
            PantObj = ragBundle.LoadAsset<GameObject>("CKRag_Pants");
            ragBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hoodItem = new CustomItem(HoodObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(hoodItem);

            //============================//

            CustomItem pantItem = new CustomItem(PantObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5,
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
                    {"ckragshat", "[CH]Ragged Hood" },
                    {"ckragshat_desc", "Smells faintly of potatos."},
                    {"ckragspant", "[CH]Ragged Pants" },
                    {"ckragspant_desc", "Hastily stiched together with leftovers from last nights hunt"},
                }
            });
        }
    }
}