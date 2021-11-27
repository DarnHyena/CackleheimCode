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

namespace CacklePadded
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CacklePadded : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CacklePadded";
        public const string PluginName = "CacklePadded";
        public const string PluginVersion = "1.0.0";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle PaddedBundle = AssetUtils.LoadAssetBundleFromResources("itemtier07", typeof(CacklePadded).Assembly);
            HatObj = PaddedBundle.LoadAsset<GameObject>("chPaHelm");
            PantObj = PaddedBundle.LoadAsset<GameObject>("chPaSuit");
            CapeObj = PaddedBundle.LoadAsset<GameObject>("chPaCoat");
            PaddedBundle.Unload(false);


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
                        Amount = 10,
                        AmountPerLevel = 3
                    },
                    new RequirementConfig()
                    {
                        Item = "LinenThread",
                        Amount = 20,
                        AmountPerLevel = 10
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
                        Amount = 10,
                        AmountPerLevel = 3
                    },
                    new RequirementConfig()
                    {
                        Item = "LinenThread",
                        Amount = 20,
                        AmountPerLevel = 10
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
                        Amount = 10,
                        AmountPerLevel = 3
                    },
                    new RequirementConfig()
                    {
                        Item = "LinenThread",
                        Amount = 20,
                        AmountPerLevel = 10
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
                    {"chPH", "[CH]Padded Helm" },
                    {"chPH_D", "The perfect helmet for charging into glorious battle!"},
                    {"chPC", "[CH]Padded Coat" },
                    {"chPC_D", "Lined with chain, this padded coat is perfect for thwarting the dreaded stings of deathsquitos"},
                    {"chPS", "[CH]Padded Suit" },
                    {"chPS_D", "Sturdy linen pants and top for life in the plains"},
                }
            });
        }
    }
}