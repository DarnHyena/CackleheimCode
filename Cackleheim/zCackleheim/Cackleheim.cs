// Cackleheim
// a Valheim mod using Jötunn
// 
// File:    Cackleheim.cs
// Project: Cackleheim

using BepInEx;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Cackleheim
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class Cackleheim : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.Cackleheim";
        public const string PluginName = "Cackleheim";
        public const string PluginVersion = "2.0.0";

        private string CackleItemToken;
        private int CackleItemHash;
        private readonly List<Material> CackleMaterials = new List<Material>();
        private Material TransparentMaterial;
        private int LastCackleVariant = -1;
        private int CurrentCackleVariant = -1;

        private void Awake()
        {
            TransparentMaterial = new Material(Shader.Find("Standard"));
            TransparentMaterial.name = "HidePlayerMaterial";
            TransparentMaterial.SetColor("_Color", Color.clear);
            TransparentMaterial.SetFloat("_Mode", 1);
            TransparentMaterial.SetInt("_SrcBlend", 1);
            TransparentMaterial.SetInt("_DstBlend", 0);
            TransparentMaterial.EnableKeyword("_ALPHATEST_ON");
            TransparentMaterial.renderQueue = 2450;

            CreateItems();

            On.Humanoid.EquipItem += Humanoid_EquipItem;
            On.Humanoid.UnequipItem += Humanoid_UnequipItem;
            On.VisEquipment.SetChestEquiped += VisEquipment_SetChestEquiped;
        }

        private void CreateItems()
        {
            //========ASSETBUNDLES========//

            AssetBundle gnollBundle = AssetUtils.LoadAssetBundleFromResources("itemgnoll", typeof(Cackleheim).Assembly);
            GameObject cackleObject = gnollBundle.LoadAsset<GameObject>("CackleViking");
            CackleMaterials.Add(gnollBundle.LoadAsset<Material>("Gnoll_01"));
            CackleMaterials.Add(gnollBundle.LoadAsset<Material>("Gnoll_02"));
            CackleMaterials.Add(gnollBundle.LoadAsset<Material>("Gnoll_03"));
            gnollBundle.Unload(false);

            //==========ITEMS & RECIPES==========//

            CustomItem cackleItem = new CustomItem(cackleObject, true, new ItemConfig()
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
                    },
                    new RequirementConfig()
                    {
                        Item = "TrollHide",
                        Amount = 0,
                        AmountPerLevel = 5
                    }
                }
            });
            ItemManager.Instance.AddItem(cackleItem);


            CackleItemHash = cackleObject.name.GetStableHashCode();
            CackleItemToken = cackleItem.ItemDrop.m_itemData.TokenName();

            //===Item Names, Description===//
            //========&Localization========//

            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = {
                    {"chB", "Totem dey Cackle" },
                    {"chB_D", "A strange trinket covered in moss.  You hear a faint noise when held"}
                }
            });
        }

        private bool Humanoid_EquipItem(On.Humanoid.orig_EquipItem orig, Humanoid self, ItemDrop.ItemData item, bool triggerEquipEffects)
        {
            bool ret = orig(self, item, triggerEquipEffects);

            // Save current equipped cackle variant
            if (ret && item.TokenName().Equals(CackleItemToken))
            {
                CurrentCackleVariant = item.m_variant;
            }

            return ret;
        }

        private void Humanoid_UnequipItem(On.Humanoid.orig_UnequipItem orig, Humanoid self, ItemDrop.ItemData item, bool triggerEquipEffects)
        {
            orig(self, item, triggerEquipEffects);

            // Reset last and current equipped cackle variant
            if (item != null && item.TokenName().Equals(CackleItemToken))
            {
                LastCackleVariant = -1;
                CurrentCackleVariant = -1;
            }
        }

        //=====PlayerBeGone-Inator6000=====//
        private bool VisEquipment_SetChestEquiped(On.VisEquipment.orig_SetChestEquiped orig, VisEquipment self, int hash)
        {
            int oldHash = self.m_currentChestItemHash;
            bool ret = orig(self, hash);

            if (self.m_bodyModel != null)
            {
                // Set variant material
                if (hash == CackleItemHash && CurrentCackleVariant != LastCackleVariant)
                {
                    SkinnedMeshRenderer randy = self.m_chestItemInstances[0]
                        .GetComponentInChildren<SkinnedMeshRenderer>();
                    randy.material = CackleMaterials[CurrentCackleVariant];
                    randy.materials = new Material[] { CackleMaterials[CurrentCackleVariant] };

                    LastCackleVariant = CurrentCackleVariant;
                }

                // Set body material to "transparent"
                if (hash == CackleItemHash && !self.m_bodyModel.material.name.StartsWith(TransparentMaterial.name))
                {
                    self.m_bodyModel.material = TransparentMaterial;
                    self.m_bodyModel.materials = new Material[] { TransparentMaterial, TransparentMaterial };
                }

                // Reset body material to the base model
                if (oldHash == CackleItemHash && oldHash != hash && self.m_bodyModel.material.name.StartsWith(TransparentMaterial.name))
                {
                    Material baseMaterial = self.m_models[self.m_nview.GetZDO().GetInt("ModelIndex")].m_baseMaterial;
                    self.m_bodyModel.material = baseMaterial;
                    self.m_bodyModel.materials = new Material[] { baseMaterial, baseMaterial };

                    LastCackleVariant = -1;
                }
            }

            return ret;
        }

    }
}