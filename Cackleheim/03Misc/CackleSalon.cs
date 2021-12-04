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
using System.Collections.Generic;
using UnityEngine;

namespace CackleSalon
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleSalon : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleSalon";
        public const string PluginName = "CackleSalon";
        public const string PluginVersion = "2.0.0";

        private GameObject SalObj;
        private GameObject SalSObj;
        private GameObject SalVObj;
        private GameObject SalBObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle SalonBundle = AssetUtils.LoadAssetBundleFromResources("buildsalon", typeof(CackleSalon).Assembly);
            SalObj = SalonBundle.LoadAsset<GameObject>("chSalon");
            SalSObj = SalonBundle.LoadAsset<GameObject>("chSalShelf");
            SalVObj = SalonBundle.LoadAsset<GameObject>("chSalVase");
            SalBObj = SalonBundle.LoadAsset<GameObject>("chSalStorageBox");

            SalonBundle.Unload(false);


            //==========RECIPES==========//

            CustomPiece SalPiece = new CustomPiece(SalObj,true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "Crafting",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 5,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(SalPiece);

            //============================//

            CustomPiece SalSPiece = new CustomPiece(SalSObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "Crafting",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 5,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Flint",
                        Amount = 5,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(SalSPiece);

            //============================//

            CustomPiece SalVPiece = new CustomPiece(SalVObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "Crafting",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 5,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Flint",
                        Amount = 5,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 2,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(SalVPiece);

            //============================//

            CustomPiece SalBPiece = new CustomPiece(SalBObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "Crafting",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "FineWood",
                        Amount = 5,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Flint",
                        Amount = 10,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 10,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(SalBPiece);

            //============================//



            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chSalon", "Cackle dey Salon"},
                    {"chSalonD", "Got to look your best when charging into battle!" },
                    {"tutorial_salon_topic", " "},
                    {"$tutorial_salon_label", "Salon" },
                    {"$tutorial_salon_text", "You can craft new looks for yourself here!"},

                    {"chSBox", "Salon Box" },
                    {"chSBoxD", "Handy storage for all your faces" },
                    {"chSVase", "Salon Vase" },
                    {"chSVaseD", "A decorative vase" },
                    {"chSShelf", "Salon Shelf" },
                    {"chSShelfD", "Spot to quickly stash extra knicknacks" },
            });
        }
    }
}