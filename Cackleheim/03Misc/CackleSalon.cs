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
        public const string PluginVersion = "1.0.0";

        private GameObject SalObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle SalonBundle = AssetUtils.LoadAssetBundleFromResources("buildsalon", typeof(CackleSalon).Assembly);
            SalObj = SalonBundle.LoadAsset<GameObject>("chSalon");
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
                        Amount = 4,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(SalPiece);


            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chSalon", "Cackle dey Salon"},
                    {"chSalonD", "Got to look your best when charging into battle!" },
                    {"tutorial_salon_topic", " "},
                    {"$tutorial_salon_label", "Salon" },
                    {"$tutorial_salon_text", "You can craft new looks for yourself here!"}
            });
        }
    }
}