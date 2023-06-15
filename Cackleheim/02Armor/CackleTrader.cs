using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Cackleheim
{   
    public class CackleTrader
    {

        private static GameObject GogObj;

        public static void AddCackleTrader()
        {
            //========ASSETBUNDLES========// 
            
            AssetBundle GogglesBundle = AssetUtils.LoadAssetBundleFromResources("itemgoggles", typeof(CackleTrader).Assembly);
            GogObj = GogglesBundle.LoadAsset<GameObject>("chGoggles");
            GogglesBundle.Unload(false);

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                    {"chgog", "[CH]Illuminated Visors" },
                    {"chgog_D", "Runic visors harnessing the power of cores to light the way"},
            });
			
			// Add the Prefab to Jötunn's ItemManager so the game "knows" about it.
			ItemManager.Instance.AddItem(new CustomItem(GogObj, fixReference: false));
			
			// Moved after bundle loading so the order is more clear
			// Included a component check so if you copy this and a GameObject 
			// has no ItemDrop it will show a warning
			if (GogObj.TryGetComponent<ItemDrop>(out var drop))
			{
				PrefabManager.OnPrefabsRegistered += () =>
				{
					var trader = PrefabManager.Instance.GetPrefab("Haldor").GetComponent<Trader>();
					trader.m_items.Add(new Trader.TradeItem
					{
						m_prefab = drop,
						m_price = 620,
						m_stack = 1
					});
				};
			}
			else
			{
				Jotunn.Logger.LogWarning("Tried to add an item to the Trader without ItemDrop");
			}
        }
    }
}