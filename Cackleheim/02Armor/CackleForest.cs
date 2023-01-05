using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Cackleheim
{
    public class CackleForest
    {

        private static GameObject THatObj;
        private static GameObject TPantObj;
        private static GameObject TCapeObj;

        private static GameObject BHatObj;
        private static GameObject BPantObj;
        private static GameObject BCapeObj;

        /// <summary>
        /// You need to execute this in the Awake of your main Cackleheim.cs by adding: AddCackleForest();
        /// </summary>
        public static void AddCackleForest()
        {
            //========ASSETBUNDLES========//

            AssetBundle ForestBundle = AssetUtils.LoadAssetBundleFromResources("itemforest", typeof(CackleForest).Assembly);
            THatObj = ForestBundle.LoadAsset<GameObject>("chTrHat");
            TPantObj = ForestBundle.LoadAsset<GameObject>("chTrPants");
            TCapeObj = ForestBundle.LoadAsset<GameObject>("chTrScarf");

            BHatObj = ForestBundle.LoadAsset<GameObject>("chBzHelm");
            BPantObj = ForestBundle.LoadAsset<GameObject>("chBzPants");
            BCapeObj = ForestBundle.LoadAsset<GameObject>("chBzChest");
            ForestBundle.Unload(false);


            //==========Troll==========//

            CustomItem ThatItem = new CustomItem(THatObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(ThatItem);

            CustomItem TcapeItem = new CustomItem(TCapeObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(TcapeItem);

            CustomItem TpantItem = new CustomItem(TPantObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(TpantItem);

            //==========Bronze==========//

            CustomItem BhatItem = new CustomItem(BHatObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 5,
                        AmountPerLevel = 3
                    }
                }
            });
            ItemManager.Instance.AddItem(BhatItem);

            CustomItem BcapeItem = new CustomItem(BCapeObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 5,
                        AmountPerLevel = 3
                    }
                }
            });
            ItemManager.Instance.AddItem(BcapeItem);

            CustomItem BpantItem = new CustomItem(BPantObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                Requirements = new RequirementConfig[]
            {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 5,
                        AmountPerLevel = 3
                    }
                }
            });
            ItemManager.Instance.AddItem(BpantItem);

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

                    {"chBZH", "[CH]Bronze Helm" },
                    {"chBZH_D", "Shines gracefully like a Golden Egg."},
                    {"chBZC", "[CH]Bronze Plate" },
                    {"chBZC_D", "Some say the first gnoll to forge a bronze plate shined like the sun as they got flung away by a troll."},
                    {"chBZP", "[CH]Bronze Pants " },
                    {"chBZP_D", "Those necks will think twice before biting off your shins with these plated slacks!"},
            });
        }
    }
}
