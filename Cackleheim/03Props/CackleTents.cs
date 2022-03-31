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

namespace CackleTent
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleTent : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleTent";
        public const string PluginName = "CackleTent";
        public const string PluginVersion = "1.0.0";

        //Plain
        private GameObject walObj;
        private GameObject walbObj;
        private GameObject sqrObj;
        private GameObject sltObj;
        private GameObject triObj;
        private GameObject corObj;
        private GameObject towObj;
        //Red
        private GameObject RwalObj;
        private GameObject RwalbObj;
        private GameObject RsqrObj;
        private GameObject RsltObj;
        private GameObject RtriObj;
        private GameObject RcorObj;
        private GameObject RtowObj;
        //Yellow
        private GameObject YwalObj;
        private GameObject YwalbObj;
        private GameObject YsqrObj;
        private GameObject YsltObj;
        private GameObject YtriObj;
        private GameObject YcorObj;
        private GameObject YtowObj;
        //Green
        private GameObject GwalObj;
        private GameObject GwalbObj;
        private GameObject GsqrObj;
        private GameObject GsltObj;
        private GameObject GtriObj;
        private GameObject GcorObj;
        private GameObject GtowObj;
        //Blue
        private GameObject BwalObj;
        private GameObject BwalbObj;
        private GameObject BsqrObj;
        private GameObject BsltObj;
        private GameObject BtriObj;
        private GameObject BcorObj;
        private GameObject BtowObj;



        private void Awake()
        {
            //========ASSETBUNDLES========// 

            AssetBundle TentBundle = AssetUtils.LoadAssetBundleFromResources("buildtent", typeof(CackleTent).Assembly);
            walObj = TentBundle.LoadAsset<GameObject>("chTentWalA");
            walbObj = TentBundle.LoadAsset<GameObject>("chTentWalB");
            sqrObj = TentBundle.LoadAsset<GameObject>("chTentSqr");
            sltObj = TentBundle.LoadAsset<GameObject>("chTentSlt");
            triObj = TentBundle.LoadAsset<GameObject>("chTentTri");
            corObj = TentBundle.LoadAsset<GameObject>("chTentCorn");
            towObj = TentBundle.LoadAsset<GameObject>("chTentTow");
            //Red
            RwalObj = TentBundle.LoadAsset<GameObject>("chTent01WalA");
            RwalbObj = TentBundle.LoadAsset<GameObject>("chTent01WalB");
            RsqrObj = TentBundle.LoadAsset<GameObject>("chTent01Sqr");
            RsltObj = TentBundle.LoadAsset<GameObject>("chTent01Slt");
            RtriObj = TentBundle.LoadAsset<GameObject>("chTent01Tri");
            RcorObj = TentBundle.LoadAsset<GameObject>("chTent01Corn");
            RtowObj = TentBundle.LoadAsset<GameObject>("chTent01Tow");
            //Yellow
            YwalObj = TentBundle.LoadAsset<GameObject>("chTent02WalA");
            YwalbObj = TentBundle.LoadAsset<GameObject>("chTent02WalB");
            YsqrObj = TentBundle.LoadAsset<GameObject>("chTent02Sqr");
            YsltObj = TentBundle.LoadAsset<GameObject>("chTent02Slt");
            YtriObj = TentBundle.LoadAsset<GameObject>("chTent02Tri");
            YcorObj = TentBundle.LoadAsset<GameObject>("chTent02Corn");
            YtowObj = TentBundle.LoadAsset<GameObject>("chTent02Tow");
            //Green
            GwalObj = TentBundle.LoadAsset<GameObject>("chTent03WalA");
            GwalbObj = TentBundle.LoadAsset<GameObject>("chTent03WalB");
            GsqrObj = TentBundle.LoadAsset<GameObject>("chTent03Sqr");
            GsltObj = TentBundle.LoadAsset<GameObject>("chTent03Slt");
            GtriObj = TentBundle.LoadAsset<GameObject>("chTent03Tri");
            GcorObj = TentBundle.LoadAsset<GameObject>("chTent03Corn");
            GtowObj = TentBundle.LoadAsset<GameObject>("chTent03Tow");
            //Blue
            BwalObj = TentBundle.LoadAsset<GameObject>("chTent04WalA");
            BwalbObj = TentBundle.LoadAsset<GameObject>("chTent04WalB");
            BsqrObj = TentBundle.LoadAsset<GameObject>("chTent04Sqr");
            BsltObj = TentBundle.LoadAsset<GameObject>("chTent04Slt");
            BtriObj = TentBundle.LoadAsset<GameObject>("chTent04Tri");
            BcorObj = TentBundle.LoadAsset<GameObject>("chTent04Corn");
            BtowObj = TentBundle.LoadAsset<GameObject>("chTent04Tow");
            TentBundle.Unload(false);


            //==========RECIPES==========//

            CustomPiece sqrPiece = new CustomPiece(sqrObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
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
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(sqrPiece);
            //============================//
            CustomPiece sltPiece = new CustomPiece(sltObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
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
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(sltPiece);
            //============================//
            CustomPiece triPiece = new CustomPiece(triObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(triPiece);
            //============================//
            CustomPiece walPiece = new CustomPiece(walObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 1,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(walPiece);
            //============================//
            CustomPiece walbPiece = new CustomPiece(walbObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 1,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 1,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(walbPiece);
            //============================//
            CustomPiece corPiece = new CustomPiece(corObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(corPiece);
            //============================//
            CustomPiece towPiece = new CustomPiece(towObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 6,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 4,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(towPiece);

            //============================//
            //============Red=============//

            CustomPiece RsqrPiece = new CustomPiece(RsqrObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
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
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Raspberry",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RsqrPiece);
            //============================//
            CustomPiece RsltPiece = new CustomPiece(RsltObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
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
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Raspberry",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RsltPiece);
            //============================//
            CustomPiece RtriPiece = new CustomPiece(RtriObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Raspberry",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RtriPiece);
            //============================//
            CustomPiece RwalPiece = new CustomPiece(RwalObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 1,
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
            PieceManager.Instance.AddPiece(RwalPiece);
            //============================//
            CustomPiece RwalbPiece = new CustomPiece(RwalbObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 1,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 1,
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
            PieceManager.Instance.AddPiece(RwalbPiece);
            //============================//
            CustomPiece RcorPiece = new CustomPiece(RcorObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Raspberry",
                        Amount = 2,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RcorPiece);
            //============================//
            CustomPiece RtowPiece = new CustomPiece(RtowObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 6,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Raspberry",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(RtowPiece);

            //============================//
            //===========Yellow===========//

            CustomPiece YsqrPiece = new CustomPiece(YsqrObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
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
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Dandelion",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(YsqrPiece);
            //============================//
            CustomPiece YsltPiece = new CustomPiece(YsltObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
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
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Dandelion",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(YsltPiece);
            //============================//
            CustomPiece YtriPiece = new CustomPiece(YtriObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Dandelion",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(YtriPiece);
            //============================//
            CustomPiece YwalPiece = new CustomPiece(YwalObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 1,
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
            PieceManager.Instance.AddPiece(YwalPiece);
            //============================//
            CustomPiece YwalbPiece = new CustomPiece(YwalbObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 1,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 1,
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
            PieceManager.Instance.AddPiece(YwalbPiece);
            //============================//
            CustomPiece YcorPiece = new CustomPiece(YcorObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Dandelion",
                        Amount = 2,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(YcorPiece);
            //============================//
            CustomPiece YtowPiece = new CustomPiece(YtowObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 6,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Dandelion",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(YtowPiece);

            //============================//
            //============Green===========//

            CustomPiece GsqrPiece = new CustomPiece(GsqrObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
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
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Guck",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(GsqrPiece);
            //============================//
            CustomPiece GsltPiece = new CustomPiece(GsltObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
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
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Guck",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(GsltPiece);
            //============================//
            CustomPiece GtriPiece = new CustomPiece(GtriObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Guck",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(GtriPiece);
            //============================//
            CustomPiece GwalPiece = new CustomPiece(GwalObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 1,
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
            PieceManager.Instance.AddPiece(GwalPiece);
            //============================//
            CustomPiece GwalbPiece = new CustomPiece(GwalbObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 1,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 1,
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
            PieceManager.Instance.AddPiece(GwalbPiece);
            //============================//
            CustomPiece GcorPiece = new CustomPiece(GcorObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Guck",
                        Amount = 2,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(GcorPiece);
            //============================//
            CustomPiece GtowPiece = new CustomPiece(GtowObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 6,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Guck",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(GtowPiece);

            //============================//
            //============Blue===========//

            CustomPiece BsqrPiece = new CustomPiece(BsqrObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
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
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Blueberries",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(BsqrPiece);
            //============================//
            CustomPiece BsltPiece = new CustomPiece(BsltObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
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
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Blueberries",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(BsltPiece);
            //============================//
            CustomPiece BtriPiece = new CustomPiece(BtriObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Blueberries",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(BtriPiece);
            //============================//
            CustomPiece BwalPiece = new CustomPiece(BwalObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 2,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 1,
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
            PieceManager.Instance.AddPiece(BwalPiece);
            //============================//
            CustomPiece BwalbPiece = new CustomPiece(BwalbObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 1,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 1,
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
            PieceManager.Instance.AddPiece(BwalbPiece);
            //============================//
            CustomPiece BcorPiece = new CustomPiece(BcorObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 3,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Blueberries",
                        Amount = 2,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(BcorPiece);
            //============================//
            CustomPiece BtowPiece = new CustomPiece(BtowObj, true, new PieceConfig()
            {
                PieceTable = "Hammer",
                Category = "chDecor",
                //CraftingStation = "piece_workbench",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 6,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Resin",
                        Amount = 4,
                        Recover = true,
                    },
                    new RequirementConfig()
                    {
                        Item = "Blueberries",
                        Amount = 3,
                        Recover = true,
                    }
                }
            });
            PieceManager.Instance.AddPiece(BtowPiece);

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
                    {"chWala", "Tent Wall" },
                    {"chWalb", "Tent Wall Half" },
                    {"chCorn", "Tent Corner" },
                    {"chTow", "Tent Tower" },
                    //Descriptions//
                    {"chSqrD", "Sturdy tent to make a quick shelter" },
                    {"chTriD", "Handy for shading those tight nooks" },
                    {"chWalaD", "Left over cloth fashioned into a makeshift wall" },
                    {"chTowD", "Central piece, good for covering firepits" },

                    //Red Tent//

                    {"chRSqr", "Red Squared Tent" },
                    {"chRSlt", "Red Slanted Tent" },
                    {"chRTri", "Red Half Tent" },
                    {"chRWala", "Red Tent Wall" },
                    {"chRWalb", "Red Tent Wall Half" },
                    {"chRCorn", "Red Tent Corner" },
                    {"chTowR", "Red Tent Tower" },

                    //Yellow Tent//

                    {"chYSqr", "Yellow Squared Tent" },
                    {"chYSlt", "Yellow Slanted Tent" },
                    {"chYTri", "Yellow Half Tent" },
                    {"chYWala", "Yellow Tent Wall" },
                    {"chYWalb", "Yellow Tent Wall Half" },
                    {"chYCorn", "Yellow Tent Corner" },
                    {"chTowY", "Yellow Tent Tower" },

                    //Green Tent//

                    {"chGSqr", "Green Squared Tent" },
                    {"chGSlt", "Green Slanted Tent" },
                    {"chGTri", "Green Half Tent" },
                    {"chGWala", "Green Tent Wall" },
                    {"chGWalb", "Green Tent Wall Half" },
                    {"chGCorn", "Green Tent Corner" },
                    {"chTowG", "Green Tent Tower" },

                    //Blue Tent//

                    {"chBSqr", "Blue Squared Tent" },
                    {"chBSlt", "Blue Slanted Tent" },
                    {"chBTri", "Blue Half Tent" },
                    {"chBWala", "Blue Tent Wall" },
                    {"chBWalb", "Blue Tent Wall Half" },
                    {"chBCorn", "Blue Tent Corner" },
                    {"chTowB", "Blue Tent Tower" },
            });
        }
    }
}