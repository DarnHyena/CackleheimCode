// Cackleheim
// a Valheim mod using Jötunn
// 
// File:    Cackleheim.cs
// Project: Cackleheim
// Altered for Compatibility with Blacksmith Tools!

using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using HarmonyLib;
using HarmonyXInterop;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;


namespace Cackleheim
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class Cackleheim : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.Cackleheim";
        public const string PluginName = "Cackleheim";
        public const string PluginVersion = "3.1.0";


        private static GameObject Cak1Obj;
        private static GameObject Cak2Obj;
        private static GameObject Cak3Obj;
        private static GameObject Cak4Obj;
        private static GameObject ForObj;
        private static GameObject WamObj;
        private static GameObject WamAObj;
        private static GameObject WamBObj;
        private static GameObject CuaObj;
        private static GameObject CuaAObj;
        private static GameObject CuaBObj;
        private static GameObject DraObj;
        private static GameObject DraAObj;
        private static GameObject DraBObj;

        //  private Mesh OrigMesh;


        private void Awake()
        {

            CreateItems();

            new Harmony("Cackleheim").PatchAll();
        }

        [HarmonyPatch(typeof(Player), nameof(Player.OnSpawned))] // Type and method to patch. Equivalent to Player_OnSpawned
        private static class PlayerSpawnPatch

        {
            private static void Postfix(Player __instance) // __instance is HarmonyX way of getting the object that the patched method is being run on.
            {
                var player = __instance;

                if (holdoverItems.Any())
                {
                    Inventory inventory = player.GetInventory();
                    foreach (ItemDrop.ItemData item in holdoverItems)
                    {
#if DEBUG
                        Jotunn.Logger.LogInfo($"Re-adding {item.m_shared.m_name}");
#endif
                        if(inventory.AddItem(item))
                        {
                            ItemDrop.ItemData addedItem = inventory.GetItem(item.m_shared.m_name);
                            player.EquipItem(addedItem);
                        }
                    }
                    holdoverItems.Clear();
                }
            }

        }


    private static HashSet<string> holdoverItemsSet = new HashSet<string>
        {
            "Cackle01","Cackle02","Cackle03","Cackle04","chForsaken","chWambui",
            "chWambuiA","chWambuiB","chCuan","chCuanA","chCuanB","chDraca","chDracaA","chDracaB"
        };
        private static readonly List<ItemDrop.ItemData> holdoverItems = new List<ItemDrop.ItemData>();

        [HarmonyPatch(typeof(Player), nameof(Player.OnDeath))]
        private static class PlayerOnDeathPatch
        {
            private static void Prefix(Player __instance)
            {
                var player = __instance;

                foreach (ItemDrop.ItemData item in new List<ItemDrop.ItemData>(player.m_inventory.GetAllItems()))
                {
                    if (item.m_equipped && holdoverItemsSet.Contains(item.m_dropPrefab.name))
                    {
                        item.m_equipped = false;
                        holdoverItems.Add(item);
                        player.m_inventory.RemoveOneItem(item);
                    }
                }
            }
        }

        private void CreateItems()
        {
            //========ASSETBUNDLES========//

            AssetBundle CackleBundle = AssetUtils.LoadAssetBundleFromResources("itemcackle", typeof(Cackleheim).Assembly);
            Cak1Obj = CackleBundle.LoadAsset<GameObject>("Cackle01");
            Cak2Obj = CackleBundle.LoadAsset<GameObject>("Cackle02");
            Cak3Obj = CackleBundle.LoadAsset<GameObject>("Cackle03");
            Cak4Obj = CackleBundle.LoadAsset<GameObject>("Cackle04");
            ForObj = CackleBundle.LoadAsset<GameObject>("chForsaken");
            WamObj = CackleBundle.LoadAsset<GameObject>("chWambui");
            WamAObj = CackleBundle.LoadAsset<GameObject>("chWambuiA");
            WamBObj = CackleBundle.LoadAsset<GameObject>("chWambuiB");
            CuaObj = CackleBundle.LoadAsset<GameObject>("chCuan");
            CuaAObj = CackleBundle.LoadAsset<GameObject>("chCuanA");
            CuaBObj = CackleBundle.LoadAsset<GameObject>("chCuanB");
            DraObj = CackleBundle.LoadAsset<GameObject>("chDraca");
            DraAObj = CackleBundle.LoadAsset<GameObject>("chDracaA");
            DraBObj = CackleBundle.LoadAsset<GameObject>("chDracaB");
            CackleBundle.Unload(false);


            //==========RECIPES==========//

            CustomItem Cak1Item = new CustomItem(Cak1Obj, true, new ItemConfig()
            {
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(Cak1Item);

            CustomItem Cak2Item = new CustomItem(Cak2Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(Cak2Item);

            CustomItem Cak3Item = new CustomItem(Cak3Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(Cak3Item);

            CustomItem Cak4Item = new CustomItem(Cak4Obj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(Cak4Item);

            //=============================================================//
            //==========================WAMBUI=============================//

            CustomItem wamItem = new CustomItem(WamObj, true, new ItemConfig()
            {
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(wamItem);

            CustomItem wamAItem = new CustomItem(WamAObj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(wamAItem);

            CustomItem wamBItem = new CustomItem(WamBObj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(wamBItem);

            //=============================================================//
            //===========================CUAN==============================//

            CustomItem CuaItem = new CustomItem(CuaObj, true, new ItemConfig()
            {
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(CuaItem);

            CustomItem CuaAItem = new CustomItem(CuaAObj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(CuaAItem);

            CustomItem CuaBItem = new CustomItem(CuaBObj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(CuaBItem);

            //=============================================================//
            //==========================DRACA==============================//

            CustomItem DraItem = new CustomItem(DraObj, true, new ItemConfig()
            {
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(DraItem);

            CustomItem DraAItem = new CustomItem(DraAObj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(DraAItem);

            CustomItem DraBItem = new CustomItem(DraBObj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(DraBItem);

            //=============================================================//
            //=============================================================//

            CustomItem forItem = new CustomItem(ForObj, true, new ItemConfig()
            {
                CraftingStation = "chSalon",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Cackle01", Amount = 1, AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "TrophyDraugr", Amount = 1, AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Wood", Amount = 1, AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide", Amount = 0, AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(forItem);


            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                {"chB1", "dey Cackle Totem Tan" },
                {"chB2", "dey Cackle Totem Brown" },
                {"chB3", "dey Cackle Totem Blond" },
                {"chB4", "dey Cackle Totem Red" },
                {"chB_D", "A strange trinket covered in moss.  You hear a faint noise when held"},

                //=============Forsaken==============//
                {"chFor", "dey Forsaken Totem" },
                {"chFor_D", "A strange trinket. Something's different about this one"},
                
                //=============Wambui==============//
                {"chWam", "dey Wambui Totem Wheat" },
                {"chWamA", "dey Wambui Totem Mud" },
                {"chWamB", "dey Wambui Totem Donk" },
                {"chWam_D", "Like Mama always said, you are what you eat"},
                
                //=============Cuan==============//
                {"chCua", "dey Cuan Totem Silver" },
                {"chCuaA", "dey Cuan Totem Cream" },
                {"chCuaB", "dey Cuan Totem Cherry" },
                {"chCua_D", "Once belonged to a strange creature that yells at the Moon"},
                
                //=============Draca==============//
                {"chDra", "dey Draca Totem Dirt" },
                {"chDraA", "dey Draca Totem Sand" },
                {"chDraB", "dey Draca Totem Clay" },
                {"chDra_D", "Smells a bit Fishy"},
            });
        }

      
    }

}