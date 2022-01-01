// Cackleheim
// a Valheim mod using Jötunn
// 
// File:    Cackleheim.cs
// Project: Cackleheim
// Wooowee this one is getting quite long!

using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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

        private GameObject Cak1Obj;
        private GameObject Cak2Obj;
        private GameObject Cak3Obj;
        private GameObject Cak4Obj;
        private GameObject ForObj;
        private GameObject WamObj;
        private GameObject WamAObj;
        private GameObject WamBObj;
        private GameObject CuaObj;
        private GameObject CuaAObj;
        private GameObject CuaBObj;
        private GameObject DraObj;
        private GameObject DraAObj;
        private GameObject DraBObj;

        //  private Mesh OrigMesh;


        private void Awake()
        {
            CreateItems();

            On.Player.OnDeath += Player_OnDeath; 
            On.Player.OnSpawned += Player_OnSpawned;
        }

        private void Player_OnSpawned(On.Player.orig_OnSpawned orig, Player player)
        {
            orig(player);
            if (holdoverItems.Any())
            {
                Inventory inventory = player.GetInventory();
                foreach (ItemDrop.ItemData item in holdoverItems)
                {
#if DEBUG
                    Jotunn.Logger.LogInfo($"Re-adding {item.m_shared.m_name}");
#endif
                    if (inventory.AddItem(item))
                    {
                        ItemDrop.ItemData addedItem = inventory.GetItem(item.m_shared.m_name);
                        player.EquipItem(addedItem);
                    }
                }
                holdoverItems.Clear();
            }
        }
          
        private HashSet<string> holdoverItemsSet = new HashSet<string>
        {
          "Cackle01","Cackle02","Cackle03","Cackle04","chForsaken","chWambui",
            "chWambuiA","chWambuiB","chCuan","chCuanA","chCuanB","chDraca","chDracaA","chDracaB"
        }; 
        private readonly List<ItemDrop.ItemData> holdoverItems = new List<ItemDrop.ItemData>();

        private void Player_OnDeath(On.Player.orig_OnDeath orig, Player player)
        {
            
            foreach (ItemDrop.ItemData item in new List<ItemDrop.ItemData>(player.m_inventory.GetAllItems()))
            {
                if(item.m_equiped && holdoverItemsSet.Contains(item.m_dropPrefab.name))
                {
                    item.m_equiped = false;
                    holdoverItems.Add(item);
                    player.m_inventory.RemoveOneItem(item);
                }
            }

            orig(player); 
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                        Item = "Cackle01",
                        Amount = 1,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "TrophyDraugr",
                        Amount = 1,
                        AmountPerLevel = 0
                    },
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 1,
                        AmountPerLevel = 10
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 0,
                        AmountPerLevel = 5
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
                {"chB1_D", "A strange trinket covered in orange moss.  You hear a faint noise when held"},
                {"chB2", "dey Cackle Totem Brown" },
                {"chB2_D", "A strange trinket covered in brown moss.  You hear a faint noise when held"},
                {"chB3", "dey Cackle Totem Blond" },
                {"chB3_D", "A strange trinket covered in yellow moss.  You hear a faint noise when held"},
                {"chB4", "dey Cackle Totem Red" },
                {"chB4_D", "A strange trinket covered in red moss.  You hear a faint noise when held"},

                //=============Forsaken==============//
                {"chFor", "dey Forsaken Totem" },
                {"chFor_D", "A strange trinket. Something's different about this one"},
                
                //=============Wambui==============//
                {"chWam", "dey Wambui Totem Wheat" },
                {"chWam_D", "Like Mama always said, you are what you eat"},
                {"chWamA", "dey Wambui Totem Mud" },
                {"chWamA_D", "Like Mama always said, you are what you eat"},
                {"chWamB", "dey Wambui Totem Donk" },
                {"chWamB_D", "Like Mama always said, you are what you eat"},
                
                //=============Cuan==============//
                {"chCua", "dey Cuan Totem Silver" },
                {"chCua_D", "Once belonged to a strange creature that yells at the Moon"},
                {"chCuaA", "dey Cuan Totem Cream" },
                {"chCuaA_D", "Once belonged to a strange creature that yells at the Moon"},
                {"chCuaB", "dey Cuan Totem Cherry" },
                {"chCuaB_D", "Once belonged to a strange creature that yells at the Moon"},
                
                //=============Draca==============//
                {"chDra", "dey Draca Totem Dirt" },
                {"chDra_D", "Smells a bit Fishy"},
                {"chDraA", "dey Draca Totem Sand" },
                {"chDraA_D", "Smells a bit Fishy"},
                {"chDraB", "dey Draca Totem Clay" },
                {"chDraB_D", "Smells a bit Fishy"},
            });
        }

    }
}