using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Cackleheim
{   
    public class CacklePlains
    {

        private static GameObject PHatObj;
        private static GameObject PPantObj;
        private static GameObject PCapeObj;

        private static Texture2D PadTex;
        private static List<Sprite> Padcons = new List<Sprite>();


        public static void AddCacklePlains()
        {
            //========ASSETBUNDLES========// 

            AssetBundle PlainsBundle = AssetUtils.LoadAssetBundleFromResources("itemplains", typeof(CacklePlains).Assembly);

            PHatObj = PlainsBundle.LoadAsset<GameObject>("chPaHelm");
            PPantObj = PlainsBundle.LoadAsset<GameObject>("chPaSuit");
            PCapeObj = PlainsBundle.LoadAsset<GameObject>("chPaCoat");
            PadTex = PlainsBundle.LoadAsset<Texture2D>("PadStyles");
            
            for (int i = 1; i <= 12; i++)
            {
                string assetName = $"PadCoatIcon{i:00}";
                Padcons.Add(PlainsBundle.LoadAsset<Sprite>(assetName));
            }
            
            PlainsBundle.Unload(false);


            //==========PADDED==========//

            CustomItem PhatItem = new CustomItem(PHatObj, true, new ItemConfig()
            {
                CraftingStation = "forge", //Note: These look for the name of the crafting table prefabs. 
                MinStationLevel = 1,  //Level crafting table needs to be in order to make the item. Aka, those things you place around it
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 10,
                        AmountPerLevel = 3
                    },
                    new RequirementConfig()
                    {
                        Item = "LinenThread",
                        Amount = 20,
                        AmountPerLevel = 10
                    }
                }
            });
            ItemManager.Instance.AddItem(PhatItem);

            CustomItem PpantItem = new CustomItem(PPantObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                MinStationLevel = 2,
                Requirements = new RequirementConfig[]
    {
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 10,
                        AmountPerLevel = 3
                    },
                    new RequirementConfig()
                    {
                        Item = "LinenThread",
                        Amount = 20,
                        AmountPerLevel = 10
                    }
                }
            });
            ItemManager.Instance.AddItem(PpantItem);

            CustomItem PcapeItem = new CustomItem(PCapeObj, true, new ItemConfig()
            {
                CraftingStation = "forge",
                MinStationLevel = 2,
                StyleTex = PadTex,
                Icons = Padcons.ToArray(),

                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 10,
                        AmountPerLevel = 3
                    },
                    new RequirementConfig()
                    {
                        Item = "LinenThread",
                        Amount = 20,
                        AmountPerLevel = 10
                    }
                }
            });
            ItemManager.Instance.AddItem(PcapeItem);

            //===Item Names, Description===//
            //========&Localization========//

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {

                    {"chPH", "[CH]Padded Helm" },
                    {"chPH_D", "The perfect helmet for charging into glorious battle!"},
                    {"chPC", "[CH]Padded Coat" },
                    {"chPC_D", "Lined with chain, this padded coat is perfect for thwarting the dreaded stings of deathsquitos"},
                    {"chPS", "[CH]Padded Suit" },
                    {"chPS_D", "Sturdy linen pants and top for life in the plains"},

            });
        }
    }
}