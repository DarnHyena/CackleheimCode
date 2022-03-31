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

namespace CacklePlains
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CacklePlains : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CacklePlains";
        public const string PluginName = "CacklePlains";
        public const string PluginVersion = "2.2.0";

        private GameObject PHatObj;
        private GameObject PPantObj;
        private GameObject PCapeObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle PlainsBundle = AssetUtils.LoadAssetBundleFromResources("itemplains", typeof(CacklePlains).Assembly);
            PHatObj = PlainsBundle.LoadAsset<GameObject>("chPaHelm");
            PPantObj = PlainsBundle.LoadAsset<GameObject>("chPaSuit");
            PCapeObj = PlainsBundle.LoadAsset<GameObject>("chPaCoat");
            PlainsBundle.Unload(false);


            //==========PADDED==========//

            CustomItem PhatItem = new CustomItem(PHatObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(PhatItem);

            CustomItem PcapeItem = new CustomItem(PCapeObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(PcapeItem);

            CustomItem PpantItem = new CustomItem(PPantObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(PpantItem);


            //============================//

            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chPH", "[CH]Padded Helm" },
                    {"chPH_D", "The perfect helmet for charging into glorious battle!"},
                    {"chPC", "[CH]Padded Coat" },
                    {"chPC_D", "Lined with chain, this padded coat is perfect for thwarting the dreaded stings of deathsquitos"},
                    {"chPS", "[CH]Padded Suit" },
                    {"chPS_D", "Sturdy linen pants and top for life in the plains"},
            });
        }
    }
}