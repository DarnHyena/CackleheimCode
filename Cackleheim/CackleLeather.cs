﻿// Cackleheim
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

namespace CackleLeather
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleLeather : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleLeather";
        public const string PluginName = "CackleLeather";
        public const string PluginVersion = "0.0.1";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;

        private Mesh OrigMesh;

        private void Awake()
        {
            // Load assets
            AssetBundle leatherBundle = AssetUtils.LoadAssetBundleFromResources("itemtier01", typeof(CackleLeather).Assembly);
            HatObj = leatherBundle.LoadAsset<GameObject>("CKLeather_Mask");
            PantObj = leatherBundle.LoadAsset<GameObject>("CKLeather_Pants");
            CapeObj = leatherBundle.LoadAsset<GameObject>("CKLeather_Poncho");
            leatherBundle.Unload(false);


            // Create custom items
            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                //Added into recipe section for now until translation section fixed
                Name = "[CH]Leather Mask",
                Description = "A striking bone white mask",
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
            ItemManager.Instance.AddItem(hatItem);

            CustomItem capeItem = new CustomItem(CapeObj, true, new ItemConfig()
            {
                //Added into recipe section for now until translation section fixed
                Name = "[CH]Leather Poncho",
                Description = "An enccentric cape for dashing rogues",
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
            ItemManager.Instance.AddItem(capeItem);

            CustomItem pantItem = new CustomItem(PantObj, true, new ItemConfig()
            {
                //Added into recipe section for now until translation section fixed
                Name = "[CH]Leather Pants",
                Description = "Finely tailored pants just like mother used to make",
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
            ItemManager.Instance.AddItem(pantItem);

            // Add localization
            // Armor in-game doesn't seem to be connecting this section and I'm not sure why.

            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = {
                    {"$ckragshat", "[CK]Ragged Hood" },
                    {"$ckragshat_desc", "Smells faintly of potatos."},
                    {"$ckragspant", "[CK]Ragged Pants" },
                    {"$ckragspant_desc", "Hastily stiched together with leftovers from last nights hunt"},
                }
            });
        }
    }
}