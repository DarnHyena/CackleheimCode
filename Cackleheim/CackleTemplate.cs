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

namespace CackleNAME
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class Cackle- : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleNAME";
        public const string PluginName = "CackleNAME";
        public const string PluginVersion = "0.0.1";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;
        //private GameObject ChestObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle NAMEBundle = AssetUtils.LoadAssetBundleFromResources("itemNAME", typeof(CackleNAME).Assembly);
            HatObj = NAMEBundle.LoadAsset<GameObject>("Item01");
            PantObj = NAMEBundle.LoadAsset<GameObject>("Item02");
            CapeObj = NAMEBundle.LoadAsset<GameObject>("Item03");
         //   ChestObj = NAMEBundle.LoadAsset<GameObject>("Item04");
            -Bundle.Unload(false);


            //==========RECIPES==========//

            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench", //Note: These look for the name of the crafting table prefabs. 
                MinStationLevel = 0,  //Level crafting table needs to be in order to make the item. Aka, those things you place around it
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "RESOURCEHERE",
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
                MinStationLevel = 0,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "RESOURCEHERE",
                        Amount = 0,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "RESOURCEHERE",
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
                MinStationLevel = 0,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "RESOURCEHERE",
                        Amount = 0,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(pantItem);

            //============================//
            //Remove the /* */ on either side of this section below to turn it back on//

         /*   CustomItem chestItem = new CustomItem(ChestObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                MinStationLevel = 0,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "RESOURCEHERE",
                        Amount = 0,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(chestItem); */

        //============================//

        //===Item Names, Description===//
        //========&Localization========//

        LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = { //Don't include the $ for the item id, the code doesn't like those
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