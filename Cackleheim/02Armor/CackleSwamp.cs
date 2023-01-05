using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Cackleheim
{   
    public class CackleSwamp
    {

        private static GameObject RHatObj;
        private static GameObject RPantObj;
        private static GameObject RCapeObj;

        private static GameObject IHatObj;
        private static GameObject IPantObj;
        private static GameObject ICapeObj;

        public static void AddCackleSwamp()
        {
            //========ASSETBUNDLES========// 

            AssetBundle SwampBundle = AssetUtils.LoadAssetBundleFromResources("itemswamp", typeof(CackleSwamp).Assembly);
            RHatObj = SwampBundle.LoadAsset<GameObject>("chRoHelm");
            RPantObj = SwampBundle.LoadAsset<GameObject>("chRoPants");
            RCapeObj = SwampBundle.LoadAsset<GameObject>("chRoChest");

            IHatObj = SwampBundle.LoadAsset<GameObject>("chIrHelm");
            IPantObj = SwampBundle.LoadAsset<GameObject>("chIrSuit");
            ICapeObj = SwampBundle.LoadAsset<GameObject>("chIrChest");
            SwampBundle.Unload(false);


            //==========ROOT==========//

            CustomItem RhatItem = new CustomItem(RHatObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench", 
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Root",
                        Amount = 10,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "ElderBark",
                        Amount = 10,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(RhatItem);

            CustomItem RcapeItem = new CustomItem(RCapeObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Root",
                        Amount = 10,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "ElderBark",
                        Amount = 10,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(RcapeItem);

            CustomItem RpantItem = new CustomItem(RPantObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "Root",
                        Amount = 10,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "ElderBark",
                        Amount = 10,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(RpantItem);

            //==========IRON==========//

            CustomItem IhatItem = new CustomItem(IHatObj, true, new ItemConfig()
            {
                CraftingStation = "forge", //Note: These look for the name of the crafting table prefabs. 
                MinStationLevel = 1,  //Level crafting table needs to be in order to make the item. Aka, those things you place around it
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 20,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(IhatItem);

            CustomItem IcapeItem = new CustomItem(ICapeObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 20,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(IcapeItem);

            CustomItem IpantItem = new CustomItem(IPantObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 20,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(IpantItem);

            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                {"chRoH", "[CH]Root Helm" },
                {"chRoH_D", "Quite handy against bee stings"},
                {"chRoC", "[CH]Root Armor" },
                {"chRoC_D", "Sturdy old wooden armor"},
                {"chRoP", "[CH]Root Fit" },
                {"chRoP_D", "Latest in Bog Fashion"},

                {"chIH", "[CH]Iron Helm" },
                {"chIH_D", "Forged into the most optimal shape for headbutting"},
                {"chIC", "[CH]Iron Plate" },
                {"chIC_D", "Comes with it's very own picnic basket!"},
                {"chIS", "[CH]Iron Suit" },
                {"chIS_D", "Stylish armored coveralls"},
            });
        }
    }
}