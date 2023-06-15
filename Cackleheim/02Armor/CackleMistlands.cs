using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Cackleheim
{   
    public class CackleMistlands
    {

        private static GameObject CaHatObj;
        private static GameObject CaPantObj;
        private static GameObject CaChestObj;

        private static GameObject EiPantObj;
        private static GameObject EiChestObj;
        private static GameObject EiHatObj;

        //private static Texture2D TunicTex;


        public static void AddCackleMistlands()
        {
            //========ASSETBUNDLES========// 

            AssetBundle MistlandsBundle = AssetUtils.LoadAssetBundleFromResources("itemmist", typeof(CackleMistlands).Assembly);
            CaHatObj = MistlandsBundle.LoadAsset<GameObject>("chCaHelm");
            CaPantObj = MistlandsBundle.LoadAsset<GameObject>("chCaSuit");
            CaChestObj = MistlandsBundle.LoadAsset<GameObject>("chCaChest");

            EiPantObj = MistlandsBundle.LoadAsset<GameObject>("chEiSuit");
            EiHatObj = MistlandsBundle.LoadAsset<GameObject>("chEiMask");
            EiChestObj = MistlandsBundle.LoadAsset<GameObject>("chEiTunic");
            //TunicTex = MistlandsBundle.LoadAsset<Texture2D>("CultTunics");

            MistlandsBundle.Unload(false);

            //==========Carapace==========//

            CustomItem cahatItem = new CustomItem(CaHatObj, true, new ItemConfig()
            {
                CraftingStation = "blackforge", 
                MinStationLevel = 1,  
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Carapace",
                        Amount = 20,
                        AmountPerLevel = 18
                    },
                    new RequirementConfig()
                    {
                        Item = "ScaleHide",
                        Amount = 3,
                        AmountPerLevel = 1
                    },
                    new RequirementConfig()
                    {
                        Item = "Eitr",
                        Amount = 4,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Mandible",
                        Amount = 2,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(cahatItem);

            CustomItem capantItem = new CustomItem(CaPantObj, true, new ItemConfig()
            {
                CraftingStation = "blackforge",
                MinStationLevel = 1,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "Carapace",
                        Amount = 20,
                        AmountPerLevel = 18
                    },
                    new RequirementConfig()
                    {
                        Item = "ScaleHide",
                        Amount = 3,
                        AmountPerLevel = 1
                    },
                    new RequirementConfig()
                    {
                        Item = "Eitr",
                        Amount = 4,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 5,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(capantItem);

            CustomItem cachestItem = new CustomItem(CaChestObj, true, new ItemConfig()
            {
                CraftingStation = "blackforge",
                MinStationLevel = 1,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "Carapace",
                        Amount = 20,
                        AmountPerLevel = 18
                    },
                    new RequirementConfig()
                    {
                        Item = "ScaleHide",
                        Amount = 3,
                        AmountPerLevel = 1
                    },
                    new RequirementConfig()
                    {
                        Item = "Eitr",
                        Amount = 4,
                        AmountPerLevel = 2
                    },
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 5,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(cachestItem);

            //==========Eitr==========//

            CustomItem EihatItem = new CustomItem(EiHatObj, true, new ItemConfig()
            {
                CraftingStation = "piece_magetable",
                MinStationLevel = 1,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "LinenThread",
                        Amount = 16,
                        AmountPerLevel = 8
                    },
                    new RequirementConfig()
                    {
                        Item = "Eitr",
                        Amount = 15,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 2,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(EihatItem);

            CustomItem EipantItem = new CustomItem(EiPantObj, true, new ItemConfig()
            {
                CraftingStation = "piece_magetable",
                MinStationLevel = 1,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "LinenThread",
                        Amount = 20,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "Eitr",
                        Amount = 20,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "ScaleHide",
                        Amount = 10,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(EipantItem);

            CustomItem EichestItem = new CustomItem(EiChestObj, true, new ItemConfig()
            {
                CraftingStation = "piece_magetable",
                MinStationLevel = 1,
                //StyleTex = TunicTex,

                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "LinenThread",
                        Amount = 20,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "Eitr",
                        Amount = 20,
                        AmountPerLevel = 5
                    },
                    new RequirementConfig()
                    {
                        Item = "ScaleHide",
                        Amount = 5,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Feathers",
                        Amount = 10,
                        AmountPerLevel = 0
                    }
                }
            });
            ItemManager.Instance.AddItem(EichestItem);

            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chCaH", "[CH]Carapace Helm" },
                    {"chCaC", "[CH]Carapace Vest" },
                    {"chCaS", "[CH]Carapace Pants" },
                    {"chCa_D", "Carapace Placeholder"},

                    {"chEiM", "[CH]Eitr Mask" },
                    {"chEiT", "[CH]Eitr Tunic" },
                    {"chEiS", "[CH]Eitr Suit" },
                    {"chEi_D", "Eitr Placeholder"},

            });
        }
    }
}