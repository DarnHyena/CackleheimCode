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
        public const string PluginVersion = "3.0.0";

        private GameObject Cak1Obj;
        private GameObject Cak2Obj;
        private GameObject Cak3Obj;
        private GameObject Cak4Obj;
        private GameObject ForObj;
        private GameObject WamObj;
        private GameObject CuaObj;
        private GameObject DraObj;

        //  private Mesh OrigMesh;

        private Material TransparentMaterial;

        private void Awake()
        {
            TransparentMaterial = new Material(Shader.Find("Standard"));
            TransparentMaterial.SetColor("_Color", Color.clear);
            TransparentMaterial.SetFloat("_Mode", 1);
            TransparentMaterial.SetInt("_SrcBlend", 1);
            TransparentMaterial.SetInt("_DstBlend", 0);
            TransparentMaterial.EnableKeyword("_ALPHATEST_ON");
            TransparentMaterial.renderQueue = 2450;
            
            CreateItems();

            On.VisEquipment.SetChestEquiped += VisEquipment_SetChestEquiped;
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
            "Cackle01","Cackle02","Cackle03","Cackle04","chForsaken","chWambui","chCuan","chDraca"
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
            CuaObj = CackleBundle.LoadAsset<GameObject>("chCuan");
            DraObj = CackleBundle.LoadAsset<GameObject>("chDraca");
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

            //============================//

            CustomItem Cak2Item = new CustomItem(Cak2Obj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(Cak2Item);

            //============================//

            CustomItem Cak3Item = new CustomItem(Cak3Obj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(Cak3Item);

            //============================//

            CustomItem Cak4Item = new CustomItem(Cak4Obj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(Cak4Item);

            //============================//

            CustomItem forItem = new CustomItem(ForObj, true, new ItemConfig()
            {
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

            //============================//

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

            //============================//

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

            //============================//

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


            //===Item Names, Description===//
            //========&Localization========//

            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = {
                    {"chB1", "dey Cackle Totem Tan" },
                    {"chB1_D", "A strange trinket covered in orange moss.  You hear a faint noise when held"},
                    {"chB2", "dey Cackle Totem Brown" },
                    {"chB2_D", "A strange trinket covered in brown moss.  You hear a faint noise when held"},
                    {"chB3", "dey Cackle Totem Blond" },
                    {"chB3_D", "A strange trinket covered in yellow moss.  You hear a faint noise when held"},
                    {"chB4", "dey Cackle Totem Red" },
                    {"chB4_D", "A strange trinket covered in red moss.  You hear a faint noise when held"},

                    //==========Frens==============//
                    {"chFor", "dey Forsaken Totem" },
                    {"chFor_D", "A strange trinket. Something's different about this one"},
                    {"chWam", "dey Wambui Totem" },
                    {"chWam_D", "Like Mama always said, you are what you eat"},
                    {"chCua", "dey Cuan Totem" },
                    {"chCua_D", "Once belonged to a strange creature that yells at the Moon"},
                    {"chDra", "dey Draca Totem" },
                    {"chDra_D", "Smells a bit Fishy"}
                }
            });
        }


        //=====PlayerBeGone-Inator5000=====//

        private bool VisEquipment_SetChestEquiped(On.VisEquipment.orig_SetChestEquiped orig, VisEquipment self, int hash)
        {
            int oldHash = self.m_currentChestItemHash;

            List<int> itemHashes = new List<int>();
            itemHashes.Add(Cak1Obj.name.GetStableHashCode());
            itemHashes.Add(Cak2Obj.name.GetStableHashCode());
            itemHashes.Add(Cak3Obj.name.GetStableHashCode());
            itemHashes.Add(Cak4Obj.name.GetStableHashCode());
            itemHashes.Add(ForObj.name.GetStableHashCode());
            itemHashes.Add(WamObj.name.GetStableHashCode());
            itemHashes.Add(CuaObj.name.GetStableHashCode());
            itemHashes.Add(DraObj.name.GetStableHashCode());


            if (orig(self, hash) && self.m_bodyModel != null)
            {
                if (itemHashes.Contains(hash))
                {
                    self.m_bodyModel.material = TransparentMaterial;
                    self.m_bodyModel.materials = new Material[] { TransparentMaterial, TransparentMaterial };
                }
                else
                {
                    if (itemHashes.Contains(oldHash))
                    {
                        self.m_bodyModel.material = self.m_models[self.m_nview.GetZDO().GetInt("ModelIndex")].m_baseMaterial;
                    }
                }
            }

            return true;
        }

    }
}