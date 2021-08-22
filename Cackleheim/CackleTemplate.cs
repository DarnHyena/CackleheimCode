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

namespace Cackle-
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class Cackle- : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.Cackle-";
        public const string PluginName = "Cackle-";
        public const string PluginVersion = "0.0.1";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;


        private void Awake()
        {
            //========ASSETBUNDLES========//

            AssetBundle -Bundle = AssetUtils.LoadAssetBundleFromResources("item-", typeof(Cackle-).Assembly);
            HatObj = -Bundle.LoadAsset<GameObject>("Item01");
            PantObj = -Bundle.LoadAsset<GameObject>("Item02");
            CapeObj = -Bundle.LoadAsset<GameObject>("Item03");
            -Bundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "===",
                        Amount = 0,
                        AmountPerLevel = 0
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
                        Item = "==",
                        Amount = 0,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "==",
                        Amount = 0,
                        AmountPerLevel = 0
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
                        Item = "==",
                        Amount = 0,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(pantItem);


            //===Item Names, Description===//
            //========&Localization========//

            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = {
                    {"ID01", "Name01" },
                    {"IDDesc01", "Desc01"},
                    {"ID02", "Name02" },
                    {"IDDesc02", "Desc02"},
                    {"ID03", "Name03" },
                    {"IDDesc03", "Desc03"},
                }
            });
        }
    }
}