// Cackleheim
// a Valheim mod using Jötunn
// 
// File:    Cackleheim.cs
// Project: Cackleheim
// New recipe system

using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System;
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
        public const string PluginVersion = "2.0.0";


        private GameObject TravObj;

        private static PieceConfig SetPieceConfigRequirements(PieceConfig baseConfig, string prefab1 = "", int amount1 = 0, string prefab2 = "", int amount2 = 0, string prefab3 = "", int amount3 = 0, string prefab4 = "", int amount4 = 0)
        {
            baseConfig.Requirements = Array.Empty<RequirementConfig>();

            if (amount1 > 0)
            {
                baseConfig.AddRequirement(new RequirementConfig(prefab1, amount1, 0, true));
            }

            if (amount2 > 0)
            {
                baseConfig.AddRequirement(new RequirementConfig(prefab2, amount2, 0, true));
            }

            if (amount3 > 0)
            {
                baseConfig.AddRequirement(new RequirementConfig(prefab3, amount3, 0, true));
            }

            if (amount4 > 0)
            {
                baseConfig.AddRequirement(new RequirementConfig(prefab4, amount4, 0, true));
            }

            return baseConfig;
        }

        private void Awake()
        {
            //========ASSETBUNDLES========// 

           AssetBundle WaresBundle = AssetUtils.LoadAssetBundleFromResources("buildwares", typeof(CackleWares).Assembly);
            TravObj = WaresBundle.LoadAsset<GameObject>("chTravelPack");

            //==========RECIPES==========//

            {
                PieceConfig tentConfig = new PieceConfig();
                tentConfig.PieceTable = "Hammer";
                tentConfig.Category = "chDecor";
                
                #region Plain
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentSqr", true, SetPieceConfigRequirements(tentConfig, "Wood", 5, "Resin", 3)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentSlt", true, SetPieceConfigRequirements(tentConfig, "Wood", 5, "Resin", 3)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentTri", true, SetPieceConfigRequirements(tentConfig, "Wood", 3, "Resin", 3)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentCorn", true, SetPieceConfigRequirements(tentConfig, "Wood", 4, "Resin", 3)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentTow", true, SetPieceConfigRequirements(tentConfig, "Wood", 6, "Resin", 4)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentWalA", true, SetPieceConfigRequirements(tentConfig, "Wood", 2, "Resin", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentWalB", true, SetPieceConfigRequirements(tentConfig, "Wood", 1, "Resin", 1)));
                #endregion

                #region Red
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent01Sqr", true, SetPieceConfigRequirements(tentConfig, "Wood", 5, "Resin", 3, "Raspberry", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent01Slt", true, SetPieceConfigRequirements(tentConfig, "Wood", 5, "Resin", 3, "Raspberry", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent01Tri", true, SetPieceConfigRequirements(tentConfig, "Wood", 3, "Resin", 3, "Raspberry", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent01Corn", true, SetPieceConfigRequirements(tentConfig, "Wood", 4, "Resin", 3, "Raspberry", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent01Tow", true, SetPieceConfigRequirements(tentConfig, "Wood", 6, "Resin", 4, "Raspberry", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent01WalA", true, SetPieceConfigRequirements(tentConfig, "Wood", 2, "Resin", 1, "Raspberry", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent01WalB", true, SetPieceConfigRequirements(tentConfig, "Wood", 1, "Resin", 1, "Raspberry", 1)));

                #endregion

                #region Yellow
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent02Sqr", true, SetPieceConfigRequirements(tentConfig, "Wood", 5, "Resin", 3, "Dandelion", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent02Slt", true, SetPieceConfigRequirements(tentConfig, "Wood", 5, "Resin", 3, "Dandelion", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent02Tri", true, SetPieceConfigRequirements(tentConfig, "Wood", 3, "Resin", 3, "Dandelion", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent02WalA", true, SetPieceConfigRequirements(tentConfig, "Wood", 2, "Resin", 1, "Dandelion", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent02WalB", true, SetPieceConfigRequirements(tentConfig, "Wood", 1, "Resin", 1, "Dandelion", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent02Corn", true, SetPieceConfigRequirements(tentConfig, "Wood", 4, "Resin", 3, "Dandelion", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent02Tow", true, SetPieceConfigRequirements(tentConfig, "Wood", 6, "Resin", 4, "Dandelion", 1)));

                #endregion

                #region Green
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent03Sqr", true, SetPieceConfigRequirements(tentConfig, "Wood", 5, "Resin", 3, "Guck", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent03Slt", true, SetPieceConfigRequirements(tentConfig, "Wood", 5, "Resin", 3, "Guck", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent03Tri", true, SetPieceConfigRequirements(tentConfig, "Wood", 3, "Resin", 3, "Guck", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent03WalA", true, SetPieceConfigRequirements(tentConfig, "Wood", 2, "Resin", 1, "Guck", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent03WalB", true, SetPieceConfigRequirements(tentConfig, "Wood", 1, "Resin", 1, "Guck", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent03Corn", true, SetPieceConfigRequirements(tentConfig, "Wood", 4, "Resin", 3, "Guck", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent03Tow", true, SetPieceConfigRequirements(tentConfig, "Wood", 6, "Resin", 4, "Guck", 1)));

                #endregion

                #region Blue
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent04Sqr", true, SetPieceConfigRequirements(tentConfig, "Wood", 5, "Resin", 3, "Blueberries", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent04Slt", true, SetPieceConfigRequirements(tentConfig, "Wood", 5, "Resin", 3, "Blueberries", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent04Tri", true, SetPieceConfigRequirements(tentConfig, "Wood", 3, "Resin", 3, "Blueberries", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent04WalA", true, SetPieceConfigRequirements(tentConfig, "Wood", 2, "Resin", 1, "Blueberries", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent04WalB", true, SetPieceConfigRequirements(tentConfig, "Wood", 1, "Resin", 1, "Blueberries", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent04Corn", true, SetPieceConfigRequirements(tentConfig, "Wood", 4, "Resin", 3, "Blueberries", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTent04Tow", true, SetPieceConfigRequirements(tentConfig, "Wood", 6, "Resin", 4, "Blueberries", 1)));

                #endregion

                #region Walls
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentFenceA01", true, SetPieceConfigRequirements(tentConfig, "Wood", 3, "Resin", 1, "Raspberry", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentFenceB01", true, SetPieceConfigRequirements(tentConfig, "Wood", 2, "Resin", 1, "Raspberry", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentFenceA02", true, SetPieceConfigRequirements(tentConfig, "Wood", 3, "Resin", 1, "Dandelion", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentFenceB02", true, SetPieceConfigRequirements(tentConfig, "Wood", 2, "Resin", 1, "Dandelion", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentFenceA03", true, SetPieceConfigRequirements(tentConfig, "Wood", 3, "Resin", 1, "Guck", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentFenceB03", true, SetPieceConfigRequirements(tentConfig, "Wood", 2, "Resin", 1, "Guck", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentFenceA04", true, SetPieceConfigRequirements(tentConfig, "Wood", 3, "Resin", 1, "Blueberries", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentFenceB04", true, SetPieceConfigRequirements(tentConfig, "Wood", 2, "Resin", 1, "Blueberries", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentFenceA05", true, SetPieceConfigRequirements(tentConfig, "Wood", 3, "Resin", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTentFenceB05", true, SetPieceConfigRequirements(tentConfig, "Wood", 2, "Resin", 1)));
                #endregion

                PieceConfig decorConfig = new PieceConfig();
                decorConfig.PieceTable = "Hammer";
                decorConfig.Category = "chDecor";
                decorConfig.CraftingStation = "piece_workbench";

                #region Rugs
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chRugE", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 2)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chRugRollE", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 1)));
                //
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chRugA", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 2, "Raspberry", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chRugRollA", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 1, "Raspberry", 1)));
                //
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chRugB", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 2, "Dandelion", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chRugRollB", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 1, "Dandelion", 1)));
                //
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chRugC", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 2, "Guck", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chRugRollC", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 1, "Guck", 1)));
                //
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chRugD", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 2, "Blueberries", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chRugRollD", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 1, "Blueberries", 1)));

                #endregion

                #region Merchant
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chCrate", true, SetPieceConfigRequirements(decorConfig, "Wood", 5, "Resin", 3)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chCrateClosed", true, SetPieceConfigRequirements(decorConfig, "Wood", 5, "Resin", 3)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chTable", true, SetPieceConfigRequirements(decorConfig, "Wood", 5, "Resin", 3)));
                #endregion

                #region Banner
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chBannerA", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 6, "FineWood", 2, "Dandelion", 4)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chBannerB", true, SetPieceConfigRequirements(decorConfig, "LeatherScraps", 6, "FineWood", 2, "Raspberry", 4)));
                #endregion

                #region Fence
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chLogLong", true, SetPieceConfigRequirements(decorConfig, "Wood", 3)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chLogShort", true, SetPieceConfigRequirements(decorConfig, "Wood", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chLogEnd", true, SetPieceConfigRequirements(decorConfig, "Wood", 2)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chLattice", true, SetPieceConfigRequirements(decorConfig, "Wood", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chLatShort", true, SetPieceConfigRequirements(decorConfig, "Wood", 1)));
                #endregion

                #region Bed
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chScrapBedA", true, SetPieceConfigRequirements(decorConfig, "FineWood", 5, "LeatherScraps", 5, "Raspberry", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chScrapBedB", true, SetPieceConfigRequirements(decorConfig, "FineWood", 5, "LeatherScraps", 5, "Dandelion", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chScrapBedC", true, SetPieceConfigRequirements(decorConfig, "FineWood", 5, "LeatherScraps", 5, "Guck", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chScrapBedD", true, SetPieceConfigRequirements(decorConfig, "FineWood", 5, "LeatherScraps", 5, "Blueberries", 1)));
                PieceManager.Instance.AddPiece(new CustomPiece(WaresBundle, "chScrapBedE", true, SetPieceConfigRequirements(decorConfig, "FineWood", 5, "LeatherScraps", 5)));
                #endregion
            }


            //=========Travel Pack=========//

            CustomItem TravItem = new CustomItem(TravObj, true, new ItemConfig()
            {
                CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 30
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 15
                    },
                    new RequirementConfig()
                    {
                        Item = "DeerHide",
                        Amount = 20
                    },
                    new RequirementConfig()
                    {
                        Item = "CookedMeat",
                        Amount = 1
                    },
                }
            });
            ItemManager.Instance.AddItem(TravItem);
            //============================//

            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    //Plain Tent//

                    {"chSqr", "Squared Tent" },
                    {"chSlt", "Slanted Tent" },
                    {"chTri", "Half Tent" },
                    {"chCorn", "Tent Corner" },
                    {"chTow", "Tent Tower" },
                    {"chWala", "Tent Curtain" },
                    {"chWalb", "Tent Curtain Half" },
                    {"chFenca", "Tent Wall" },
                    {"chFencb", "Tent Wall Half" },

                    {"chSqrD", "Sturdy tent to make a quick shelter" },
                    {"chTriD", "Handy for shading those tight nooks" },
                    {"chWalaD", "Left over cloth fashioned into a makeshift wall" },
                    {"chTowD", "Central piece, good for covering firepits" },

                    //Merchant//
                    {"chCrat", "Small Crate" },
                    {"chCratC", "Small Crate Lidded" },
                    {"chTab", "Sturdy Table" },

                    {"chCratD", "Compact box for stashing items" },
                    {"chCratCD", "Now it has a lid!" },
                    {"chTabD", "A sturdy table that sturdedly stands sturdy" },

                    //Rugs//
                    {"$chRug", "Rug" },
                    {"$chRugRoll", "Rolled Rug" },
                    {"$chRugD", "Cozy rug found in a knocked over wagon" },

                    //Banners//
                    {"$chBanA", "Cackle Banner Sun" },
                    {"$chBanB", "Cackle Banner Plains" },
                    {"$chBanD", " " },

                    //Fences//
                    {"chLogL", "Tree Wall" },
                    {"chLogS", "Tree Wall Short" },
                    {"chLogE", "Tree Wall End" },
                    {"chLat", "Lattice Fence" },
                    {"chLatS", "Short Lattic Fence" },

                    {"chLatD", "I just think they're neat" },
                    {"chLogD", "Small fence made of tree stumps" },

                    //Bed//
                    {"chBed", "Soft Cozy Bed" },
                    {"chBedD", "Much more comfortable than the grass" },

                    //Travel
                    {"chTrav", "[CH]Travel Pack" },
                    {"chTravD", "Bulky pack to transport your stash of meat in"},
            });
        }
    }
}