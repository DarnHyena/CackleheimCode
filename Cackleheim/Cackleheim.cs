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
        public const string PluginGUID = "es.localhyena.Cackleheim";
        public const string PluginName = "Cackleheim";
        public const string PluginVersion = "0.0.1";

        private GameObject TanObj;
        /*private GameObject BrownModel;
        private GameObject BlondeModel;*/

        private Mesh OrigMesh;

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
            /*BrownModel = gnollBundle.LoadAsset<GameObject>("CackleViking02");
            BlondeModel = gnollBundle.LoadAsset<GameObject>("CackleViking03");*/
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

            /*CustomItem brownItem = new CustomItem(BrownModel, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(brownItem);

            CustomItem blondeItem = new CustomItem(BlondeModel, true, new ItemConfig()
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
            ItemManager.Instance.AddItem(blondeItem);*/

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

            if (orig(self, hash) && self.m_bodyModel != null)
            {
                if (hash == tanHash)
                {
                    self.m_bodyModel.material = TransparentMaterial;
                    self.m_bodyModel.materials = new Material[] { TransparentMaterial, TransparentMaterial };
                }

                if (oldHash == tanHash)
                {
                    self.m_bodyModel.material = self.m_models[self.m_nview.GetZDO().GetInt("ModelIndex")].m_baseMaterial;
                }
            }

            return true;
        }
    }
}