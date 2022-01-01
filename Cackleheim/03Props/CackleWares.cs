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

namespace CackleWares
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleWares : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleWares";
        public const string PluginName = "CackleWares";
        public const string PluginVersion = "1.0.0";

        private GameObject CraObj;
        private GameObject CraCObj;
        private GameObject TabObj;
        //Rugs
        private GameObject RugAObj;
        private GameObject RugBObj;
        private GameObject RugCObj;
        private GameObject RugDObj;
        private GameObject RugEObj;
        //Rolled
        private GameObject RRugAObj;
        private GameObject RRugBObj;
        private GameObject RRugCObj;
        private GameObject RRugDObj;
        private GameObject RRugEObj;
        //Banner
        private GameObject BanAObj;
        private GameObject BanBObj;


        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle WaresBundle = AssetUtils.LoadAssetBundleFromResources("buildwares", typeof(CackleWares).Assembly);
            CraObj = WaresBundle.LoadAsset<GameObject>("chCrate");
            CraCObj = WaresBundle.LoadAsset<GameObject>("chCrateClosed");
            TabObj = WaresBundle.LoadAsset<GameObject>("chTable");
            //Rugs
            RugAObj = WaresBundle.LoadAsset<GameObject>("chRugA");
            RugBObj = WaresBundle.LoadAsset<GameObject>("chRugB");
            RugCObj = WaresBundle.LoadAsset<GameObject>("chRugC");
            RugDObj = WaresBundle.LoadAsset<GameObject>("chRugD");
            RugEObj = WaresBundle.LoadAsset<GameObject>("chRugE");
            //Rolled
            RRugAObj = WaresBundle.LoadAsset<GameObject>("chRugRollA");
            RRugBObj = WaresBundle.LoadAsset<GameObject>("chRugRollB");
            RRugCObj = WaresBundle.LoadAsset<GameObject>("chRugRollC");
            RRugDObj = WaresBundle.LoadAsset<GameObject>("chRugRollD");
            RRugEObj = WaresBundle.LoadAsset<GameObject>("chRugRollE");
            //Banner
            BanAObj = WaresBundle.LoadAsset<GameObject>("chBannerA");
            BanBObj = WaresBundle.LoadAsset<GameObject>("chBannerB");

            WaresBundle.Unload(false);


            //==========RECIPES==========//

            CustomPiece CraPiece = new CustomPiece(CraObj, true, new PieceConfig()
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
            PieceManager.Instance.AddPiece(CraPiece);
            //============================//
            CustomPiece CraCPiece = new CustomPiece(CraCObj, true, new PieceConfig()
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
            PieceManager.Instance.AddPiece(CraCPiece);

            //===========Table============//

            CustomPiece TabPiece = new CustomPiece(TabObj, true, new PieceConfig()
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
            PieceManager.Instance.AddPiece(TabPiece);

            //==========Rugs============//

            CustomPiece RugAPiece = new CustomPiece(RugAObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Raspberry",
                        Amount = 1,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RugAPiece);
            //============================//
            CustomPiece RugBPiece = new CustomPiece(RugBObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Dandelion",
                        Amount = 1,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RugBPiece);
            //============================//
            CustomPiece RugCPiece = new CustomPiece(RugCObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Guck",
                        Amount = 1,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RugCPiece);
            //============================//
            CustomPiece RugDPiece = new CustomPiece(RugDObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Blueberries",
                        Amount = 1,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RugDPiece);
            //============================//
            CustomPiece RugEPiece = new CustomPiece(RugEObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RugEPiece);
            //============================//
            //==========Rolled============//

            CustomPiece RRugAPiece = new CustomPiece(RRugAObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Raspberry",
                        Amount = 1,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RRugAPiece);
            //============================//
            CustomPiece RRugBPiece = new CustomPiece(RRugBObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Dandelion",
                        Amount = 1,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RRugBPiece);
            //============================//
            CustomPiece RRugCPiece = new CustomPiece(RRugCObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Guck",
                        Amount = 1,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RRugCPiece);
            //============================//
            CustomPiece RRugDPiece = new CustomPiece(RRugDObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Blueberries",
                        Amount = 1,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RRugDPiece);
            //============================//
            CustomPiece RRugEPiece = new CustomPiece(RRugEObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 2,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RRugEPiece);
            //============================//
            //==========Banner============//

            CustomPiece BanAPiece = new CustomPiece(BanAObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 6,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Dandelion",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "FineWood",
                        Amount = 2,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(BanAPiece);
            //============================//
            CustomPiece BanBPiece = new CustomPiece(BanBObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 6,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Raspberry",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "FineWood",
                        Amount = 2,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(BanBPiece);

            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chCrat", "Small Crate" },
                    {"chCratD", "Compact box for stashing items" },
                    {"chCratC", "Small Crate Lidded" },
                    {"chCratCD", " " },
                    {"chTab", "Sturdy Table" },
                    {"chTabD", " " },
                    //Rugs
                    {"$chRug", "Rug Plain" },
                    {"$chRugD", "Cozy rug found in a knocked over wagon" },
                    {"$chRugR", "Rug Red" },
                    {"$chRugY", "Rug Yellow" },
                    {"$chRugG", "Rug Green" },
                    {"$chRugB", "Rug Blue" },
                    //Rolled
                    {"$chRugRoll", "Rolled Rug Plain" },
                    {"$chRugRollR", "Rolled Rug Red" },
                    {"$chRugRollY", "Rolled Rug Yellow" },
                    {"$chRugRollG", "Rolled Rug Green" },
                    {"$chRugRollB", "Rolled Rug Blue" },
                    //Banner
                    {"$chBanA", "Rolled Rug Plain" },
                    {"$chBan", "Rolled Rug Red" },
                    {"$chBanAD", " " },

            });
        }
    }
}