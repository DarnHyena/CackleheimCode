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

namespace Cackleheim
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class Cackleheim : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.Cackleheim";
        public const string PluginName = "Cackleheim";
        public const string PluginVersion = "0.0.1";

        private GameObject TanObj;
        private GameObject BroObj;
        private GameObject BloObj;

        private string CurrentHelmetItem;
        private string CurrentChestItem;
        private string CurrentLegitem;

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
        }

        private void CreateItems()
        {
            // Load assets
            AssetBundle gnollBundle = AssetUtils.LoadAssetBundleFromResources("itemgnoll", typeof(Cackleheim).Assembly);
            TanObj = gnollBundle.LoadAsset<GameObject>("CackleViking01");
            BroObj = gnollBundle.LoadAsset<GameObject>("CackleViking02");
            BloObj = gnollBundle.LoadAsset<GameObject>("CackleViking03");
            gnollBundle.Unload(false);

            // Create custom items
            CustomItem tanItem = new CustomItem(TanObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(tanItem);

            CustomItem broItem = new CustomItem(BroObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(broItem);

            CustomItem bloItem = new CustomItem(BloObj, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(bloItem);

            // Add localization
            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = {
                    {"ck01", "Totem dey Cackle Tan" },
                    {"ck01_desc", "A strange trinket covered in orange moss.  You hear a faint noise when held"},
                    {"ck02", "Totem dey Cackle Brown" },
                    {"ck02_desc", "A strange trinket covered in brown moss.  You hear a faint noise when held"},
                    {"ck03", "Totem dey Cackle Light" },
                    {"ck03_desc", "A strange trinket covered in yellow moss.  You hear a faint noise when held"}
                }
            });
        }

        private bool VisEquipment_SetChestEquiped(On.VisEquipment.orig_SetChestEquiped orig, VisEquipment self, int hash)
        {
            int oldHash = self.m_currentChestItemHash;
            int tanHash = TanObj.name.GetStableHashCode();

            bool ret = orig(self, hash);

            CurrentHelmetItem = self.m_helmetItem;
            CurrentChestItem = self.m_chestItem;
            CurrentLegitem = self.m_legItem;

            if (ret && self.m_bodyModel != null)
            {
                if (hash == tanHash)
                {
                    self.m_bodyModel.material = TransparentMaterial;
                    self.m_bodyModel.materials = new Material[] { TransparentMaterial, TransparentMaterial };
                    self.SetHelmetItem(null);
                    self.SetLegItem(null);
                }

                if (oldHash == tanHash)
                {
                    self.m_bodyModel.material = self.m_models[self.m_nview.GetZDO().GetInt("ModelIndex")].m_baseMaterial;
                    self.SetHelmetItem(CurrentHelmetItem);
                    self.SetChestItem(CurrentChestItem);
                    self.SetLegItem(CurrentLegitem);
                    CurrentHelmetItem = null;
                    CurrentChestItem = null;
                    CurrentLegitem = null;
                }
            }

            return ret;
        }
    }
}