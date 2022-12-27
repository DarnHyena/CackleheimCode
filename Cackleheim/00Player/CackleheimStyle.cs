// Cackleheim
// a Valheim mod using Jötunn
// 
// File:    Cackleheim.cs
// Project: Cackleheim
// -Styles Testing-

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
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.Logging;

namespace Cackleheim
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class Cackleheim : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.Cackleheim";
        public const string PluginName = "Cackleheim";
        public const string PluginVersion = "3.4.0";


        private static GameObject Cak1Obj;
        private static GameObject WamObj;
        private static GameObject CuaObj;
        private static GameObject DraObj;

        private static GameObject ForObj;

        private Texture2D YeeTex;
        private Texture2D WamTex;
        private Texture2D DraTex;
        private Texture2D CuaTex;

        List<Sprite> Yeecons = new List<Sprite>();
        List<Sprite> Wamcons = new List<Sprite>();
        List<Sprite> Dracons = new List<Sprite>();
        List<Sprite> Cuacons = new List<Sprite>();


        //========Transparent Material========//
        //Used to hide the vanilla playermodel//

        private static Material TransparentMaterial;

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

            new Harmony("Cackleheim").PatchAll();
        }


        //==============Keep on Death==============//
        //Keeps skins attached to player upon death//

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
            "Cackle01","chForsaken","chWambui","chCuan","chDraca"
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
                    if (item.m_equiped && holdoverItemsSet.Contains(item.m_dropPrefab.name))
                    {
                        item.m_equiped = false;
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
            WamObj = CackleBundle.LoadAsset<GameObject>("chWambui");
            CuaObj = CackleBundle.LoadAsset<GameObject>("chCuan");
            DraObj = CackleBundle.LoadAsset<GameObject>("chDraca");
            ForObj = CackleBundle.LoadAsset<GameObject>("chForsaken");

            YeeTex = CackleBundle.LoadAsset<Texture2D>("CackleStyles");
            WamTex = CackleBundle.LoadAsset<Texture2D>("WambuiStyles");
            DraTex = CackleBundle.LoadAsset<Texture2D>("DracaStyles");
            CuaTex = CackleBundle.LoadAsset<Texture2D>("CuanStyles");

            for (int i = 1; i <= 4; i++)
            {
                string assetName = $"CackleIcon{i:00}";
                Yeecons.Add(CackleBundle.LoadAsset<Sprite>(assetName));
            }
            for (int i = 1; i <= 3; i++)
            {
                string assetName = $"WamIcon{i:00}";
                Wamcons.Add(CackleBundle.LoadAsset<Sprite>(assetName));
            }
            for (int i = 1; i <= 3; i++)
            {
                string assetName = $"DraIcon{i:00}";
                Dracons.Add(CackleBundle.LoadAsset<Sprite>(assetName));
            }
            for (int i = 1; i <= 3; i++)
            {
                string assetName = $"CuaIcon{i:00}";
                Cuacons.Add(CackleBundle.LoadAsset<Sprite>(assetName));
            }

            CackleBundle.Unload(false);



            //==========RECIPES==========//

            CustomItem Cak1Item = new CustomItem(Cak1Obj, true, new ItemConfig()
            {
                StyleTex = YeeTex,
                Icons = Yeecons.ToArray(),

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

            //==========================WAMBUI=============================//

            CustomItem wamItem = new CustomItem(WamObj, true, new ItemConfig()
            {
                StyleTex = WamTex,
                Icons = Wamcons.ToArray(),

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

            //===========================CUAN==============================//

            CustomItem CuaItem = new CustomItem(CuaObj, true, new ItemConfig()
            {
                StyleTex = CuaTex,
                Icons = Cuacons.ToArray(),

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

            //==========================DRACA==============================//

            CustomItem DraItem = new CustomItem(DraObj, true, new ItemConfig()
            {
                StyleTex = DraTex,
                Icons = Dracons.ToArray(),

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
                {"chB1", "dey Cackle Totem" },
                {"chB_D", "A strange trinket covered in moss.  You hear a faint noise when held"},

                //=============Forsaken==============//
                {"chFor", "dey Forsaken Totem" },
                {"chFor_D", "A strange trinket. Something's different about this one"},
                
                //=============Wambui==============//
                {"chWam", "dey Wambui Totem" },
                {"chWam_D", "Like Mama always said, you are what you eat"},
                
                //=============Cuan==============//
                {"chCua", "dey Cuan Totem" },
                {"chCua_D", "Once belonged to a strange creature that yells at the Moon"},
                
                //=============Draca==============//
                {"chDra", "dey Draca Totem" },
                {"chDra_D", "Smells a bit Fishy"},
            });
        }


        //=====PlayerBeGone-Inator5000=====//

        private static int oldHash;

        [HarmonyPatch(typeof(VisEquipment), "SetChestEquiped")] // Writing the method name manually can be used for if you are not using publicized valheim dlls.
        private static class VisEquipChestPatch
        {
            private static void Prefix(VisEquipment __instance) // As before, we use __instance when getting the object instance.
            {
                oldHash = __instance.m_currentChestItemHash;
            }
        }

    

        [HarmonyPatch(typeof(VisEquipment), "SetChestEquiped")] // Writing the method name manually can be used for if you are not using publicized valheim dlls.
        private static class VisEquipPatch
        {
            private static void Postfix(VisEquipment __instance, int hash, ref bool __result) // Method parameters like "hash" can just be listed here. The result of the method patched can be received by adding "result". We set the result with "ref" because it looks like you want to enforce the result as "true".
            {
                var self = __instance;

                List<int> itemHashes = new List<int>();
                itemHashes.Add(Cak1Obj.name.GetStableHashCode());
                itemHashes.Add(WamObj.name.GetStableHashCode());
                itemHashes.Add(CuaObj.name.GetStableHashCode());
                itemHashes.Add(DraObj.name.GetStableHashCode());
                itemHashes.Add(ForObj.name.GetStableHashCode());


                if (__result && self.m_bodyModel != null)
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

                __result = true;
            }
 
        }
      
    }

}