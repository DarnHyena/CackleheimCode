using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Cackleheim
{
    public class CackleMane
    {
        //SetA
        private static GameObject MaA1Obj;
        private static GameObject MaA2Obj;
        private static GameObject MaA3Obj;
        //SetB
        private static GameObject MaB1Obj;
        private static GameObject MaB2Obj;
        private static GameObject MaB3Obj;
        //SetC
        private static GameObject MaC1Obj;
        private static GameObject MaC2Obj;
        private static GameObject MaC3Obj;

        public static void AddCackleMane()
        {

            //========ASSETBUNDLES========//

            AssetBundle ManeBundle = AssetUtils.LoadAssetBundleFromResources("itemmane", typeof(CackleMane).Assembly);
            MaA1Obj = ManeBundle.LoadAsset<GameObject>("chMaA1");
            MaA2Obj = ManeBundle.LoadAsset<GameObject>("chMaA2");
            MaA3Obj = ManeBundle.LoadAsset<GameObject>("chMaA3");
            //
            MaB1Obj = ManeBundle.LoadAsset<GameObject>("chMaB1");
            MaB2Obj = ManeBundle.LoadAsset<GameObject>("chMaB2");
            MaB3Obj = ManeBundle.LoadAsset<GameObject>("chMaB3");
            //
            MaC1Obj = ManeBundle.LoadAsset<GameObject>("chMaC1");
            MaC2Obj = ManeBundle.LoadAsset<GameObject>("chMaC2");
            MaC3Obj = ManeBundle.LoadAsset<GameObject>("chMaC3");
            ManeBundle.Unload(false);


            //==========RECIPES==========//
            //===========SETA===========//
            
            CustomItem MaA1Item = new CustomItem(MaA1Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 0,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(MaA1Item);

            CustomItem MaA2Item = new CustomItem(MaA2Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 5,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "TrollHide",
                        Amount = 0,
                        AmountPerLevel = 10
                    },
                }
            });
            ItemManager.Instance.AddItem(MaA2Item);

            CustomItem MaA3Item = new CustomItem(MaA3Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "WolfPelt",
                        Amount = 2,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Silver",
                        Amount = 10,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 0,
                        AmountPerLevel = 10
                    }
                }
            });
            ItemManager.Instance.AddItem(MaA3Item);

            //===========================//
            //===========SETB===========//

            CustomItem MaB1Item = new CustomItem(MaB1Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 0,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(MaB1Item);

            CustomItem MaB2Item = new CustomItem(MaB2Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 5,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "TrollHide",
                        Amount = 0,
                        AmountPerLevel = 10
                    },
                }
            });
            ItemManager.Instance.AddItem(MaB2Item);

            CustomItem MaB3Item = new CustomItem(MaB3Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "WolfPelt",
                        Amount = 2,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Silver",
                        Amount = 10,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 0,
                        AmountPerLevel = 10
                    }
                }
            });
            ItemManager.Instance.AddItem(MaB3Item);

            //===========================//
            //===========SETC===========//

            CustomItem MaC1Item = new CustomItem(MaC1Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 2,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 0,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(MaC1Item);

            CustomItem MaC2Item = new CustomItem(MaC2Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 5,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "TrollHide",
                        Amount = 0,
                        AmountPerLevel = 10
                    },
                }
            });
            ItemManager.Instance.AddItem(MaC2Item);

            CustomItem MaC3Item = new CustomItem(MaC3Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "WolfPelt",
                        Amount = 2,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Silver",
                        Amount = 10,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 0,
                        AmountPerLevel = 10
                    }
                }
            });
            ItemManager.Instance.AddItem(MaC3Item);

            //============================//


            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chMA1", "[CH]Light ManeA" },
                    {"chMA2", "[CH]Medium ManeA"},
                    {"chMA3", "[CH]Heavy ManeA"},
                    {"chMB1", "[CH]Light ManeB"},
                    {"chMB2", "[CH]Medium ManeB"},
                    {"chMB3", "[CH]Heavy ManeB"},
                    {"chMC1", "[CH]Light ManeC"},
                    {"chMC2", "[CH]Medium ManeC"},
                    {"chMC3", "[CH]Heavy ManeC"},

                    {"chM1_D", "Scruffy mane adorn with wooden bands"},
                    {"chM2_D", "Scruffy mane adorn with leather bands"},
                    {"chM3_D", "Scruffy mane adorn with metal bands"},
            });
        }
    }
}