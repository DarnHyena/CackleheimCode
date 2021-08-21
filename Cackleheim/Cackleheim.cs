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

        private void Awake()
        {
            // Load assets
            AssetBundle gnollBundle = AssetUtils.LoadAssetBundleFromResources("itemgnoll", typeof(Cackleheim).Assembly);
            GameObject tanModel = gnollBundle.LoadAsset<GameObject>("CackleViking01");
            /*GameObject brownModel = gnollBundle.LoadAsset<GameObject>("CackleViking02");
            GameObject blondeModel = gnollBundle.LoadAsset<GameObject>("CackleViking03");*/
            gnollBundle.Unload(false);

            // Create custom items
            CustomItem tanItem = new CustomItem(tanModel, true, new ItemConfig()
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

            /*CustomItem brownItem = new CustomItem(brownModel, true, new ItemConfig()
            {
                Name = "CackleViking02",
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

            CustomItem blondeItem = new CustomItem(blondeModel, true, new ItemConfig()
            {
                Name = "CackleViking03",
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
    }
}