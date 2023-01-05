using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Cackleheim
{
    public class CackleMeadow
    {
        private static GameObject RHoodObj;
        private static GameObject RPantObj;
        private static GameObject RCapeObj;

        private static Texture2D RagTex;
        private static List<Sprite> Ragcons = new List<Sprite>();

        private static GameObject LHatObj;
        private static GameObject LPantObj;
        private static GameObject LCapeObj;

        public static void AddCackleMeadow()
        {
            //========ASSETBUNDLES========//

            AssetBundle meadowBundle = AssetUtils.LoadAssetBundleFromResources("itemmeadow", typeof(CackleMeadow).Assembly);
            RHoodObj = meadowBundle.LoadAsset<GameObject>("chRaHood");
            RPantObj = meadowBundle.LoadAsset<GameObject>("chRaPants");
            RCapeObj = meadowBundle.LoadAsset<GameObject>("chRaTunic");
            RagTex = meadowBundle.LoadAsset<Texture2D>("RagStyles");
            

            for (int i = 1; i <= 5; i++)
            {
                string assetName = $"RagTunIcon{i:00}";
                Ragcons.Add(meadowBundle.LoadAsset<Sprite>(assetName));
            }


            LHatObj = meadowBundle.LoadAsset<GameObject>("chLeMask");
            LPantObj = meadowBundle.LoadAsset<GameObject>("chLePants");
            LCapeObj = meadowBundle.LoadAsset<GameObject>("chLePoncho");
            meadowBundle.Unload(false);


            //==========RAGS==========//

            CustomItem RhoodItem = new CustomItem(RHoodObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 1,
                        AmountPerLevel = 2
                    }
                }
            });
            ItemManager.Instance.AddItem(RhoodItem);

            CustomItem RCapeItem = new CustomItem(RCapeObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                StyleTex = RagTex,
                Icons = Ragcons.ToArray(),

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
            ItemManager.Instance.AddItem(RCapeItem);

            CustomItem RpantItem = new CustomItem(RPantObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(RpantItem);

            //==========LEATHER==========//

            CustomItem LhatItem = new CustomItem(LHatObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 6,
                        AmountPerLevel = 6
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 0,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(LhatItem);

            CustomItem LcapeItem = new CustomItem(LCapeObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 6,
                        AmountPerLevel = 6
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 0,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(LcapeItem);

            CustomItem LpantItem = new CustomItem(LPantObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 6,
                        AmountPerLevel = 6
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 0,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(LpantItem);


            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chRH", "[CH]Ragged Hood" },
                    {"chRP", "[CH]Ragged Pants" },
                    {"chRT", "[CH]Ragged Tunic" },
                    {"chRH_D", "Well worn hood"},
                    {"chRP_D", "Hastily stiched together with leftovers from last nights hunt"},
                    {"chRT_D", "Smells faintly of potatos"},

                    {"chLH", "[CH]Leather Mask" },
                    {"chLC", "[CH]Leather Poncho" },
                    {"chLP", "[CH]Leather Pants" },
                    {"chLH_D", "A striking bone white mask"},
                    {"chLC_D", "An enccentric cape for dashing rogues"},
                    {"chLP_D", "Finely tailored pants just like mother used to make"},
            });
        }
    }
}