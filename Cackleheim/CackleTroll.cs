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

namespace CackleTroll
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleTroll : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleTroll";
        public const string PluginName = "CackleTroll";
        public const string PluginVersion = "0.0.1";

        private GameObject HatObj;
        private GameObject PantObj;
        private GameObject CapeObj;

        private Mesh OrigMesh;

        private void Awake()
        {
            // Load assets
            AssetBundle trollBundle = AssetUtils.LoadAssetBundleFromResources("itemtier02", typeof(CackleTroll).Assembly);
            HatObj = trollBundle.LoadAsset<GameObject>("CKTroll_Hat");
            PantObj = trollBundle.LoadAsset<GameObject>("CKTroll_Pants");
            CapeObj = trollBundle.LoadAsset<GameObject>("CKTroll_Scarf");
            trollBundle.Unload(false);


            // Create custom items
            CustomItem hatItem = new CustomItem(HatObj, true, new ItemConfig()
            {
                //Added into recipe section for now until translation section fixed
                Name = "[CH]Troll Hat",
                Description = "Great for keeping the sun out the eyes",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "TrollHide",
                        Amount = 5,
                        AmountPerLevel = 3
                    }
                }
            });
            ItemManager.Instance.AddItem(hatItem);

            CustomItem capeItem = new CustomItem(CapeObj, true, new ItemConfig()
            {
                //Added into recipe section for now until translation section fixed
                Name = "[CH]Troll Scarf",
                Description = "A simple scarf with a decorative chunk of some poor souls rib cage you found in the woods",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "TrollHide",
                        Amount = 5,
                        AmountPerLevel = 3
                    },
                    new RequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 3,
                        AmountPerLevel = 2
                    }
                }
            });
            ItemManager.Instance.AddItem(capeItem);

            CustomItem pantItem = new CustomItem(PantObj, true, new ItemConfig()
            {
                //Added into recipe section for now until translation section fixed
                Name = "[CH]Troll Pants",
                Description = "A hardy pair of overalls for sneaky farmers. Even comes with extra bones for snacking",
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "TrollHide",
                        Amount = 5,
                        AmountPerLevel = 3
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