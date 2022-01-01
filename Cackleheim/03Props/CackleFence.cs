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

namespace CackleFence
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleFence : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleFence";
        public const string PluginName = "CackleFence";
        public const string PluginVersion = "1.0.0";

        private GameObject LLObj;
        private GameObject LSObj;
        private GameObject LEObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle FenceBundle = AssetUtils.LoadAssetBundleFromResources("buildfence", typeof(CackleFence).Assembly);
            LLObj = FenceBundle.LoadAsset<GameObject>("chLogLong");
            LSObj = FenceBundle.LoadAsset<GameObject>("chLogShort");
            LEObj = FenceBundle.LoadAsset<GameObject>("chLogEnd");

            FenceBundle.Unload(false);


            //==========RECIPES==========//
            
            CustomPiece LLPiece = new CustomPiece(LLObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
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
            PieceManager.Instance.AddPiece(LLPiece);
            
            //============================//

            CustomPiece LSPiece = new CustomPiece(LSObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 2,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(LSPiece);

            //============================//

            CustomPiece LEPiece = new CustomPiece(LEObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(LEPiece);

            //============================//


            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chLogL", "Tree Wall" },
                    {"chLogLD", "Small fence made of tree stumps" },
                    {"chLogS", "Tree Wall Short" },
                    {"chLogSD", " " },
                    {"chLogE", "Tree Wall End" },
                    {"chLogED", " " },
            });
        }
    }
}