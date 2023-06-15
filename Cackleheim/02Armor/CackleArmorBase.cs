using BepInEx;
using Cackleheim;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Cackleheim
{   
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class CackleArmor : BaseUnityPlugin
    {
        public const string PluginGUID = "DarnHyena.CackleArmor";
        public const string PluginName = "CackleArmor";
        public const string PluginVersion = "3.0.0";

        //===============================================//
        //Root Plugin for cackleheim armor and equiptment//
        //===============================================//

        private void Awake()
        {
            CackleMeadow.AddCackleMeadow();
            CackleForest.AddCackleForest();
            CackleSwamp.AddCackleSwamp();
            CackleMountain.AddCackleMountain();
            CacklePlains.AddCacklePlains();
            CackleMistlands.AddCackleMistlands();

            CackleSalon.AddCackleSalon();
            CackleTrader.AddCackleTrader();
            CackleMane.AddCackleMane();

        }
    }
}