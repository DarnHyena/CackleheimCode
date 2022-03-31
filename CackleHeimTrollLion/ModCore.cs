using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using CreatureManager;
using HarmonyLib;
using UnityEngine;

namespace CackleHeimTrollLion
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class CackleHeimTrollMod : BaseUnityPlugin
    {
        internal const string ModName = "CackleHeimLionTroll";
        internal const string ModVersion = "0.0.1";
        private const string ModGUID = "come.cacklehieim.liontroll";
        private static Harmony? harmony = null!;
        private static Creature? LionTroll;
        internal static GameObject? RagDoll;

        public void Awake()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            harmony = new(ModGUID);
            harmony.PatchAll(assembly);

            LionTroll = new("liontroll", "Lion_Troll")
            {
                Biome = Heightmap.Biome.Meadows,
                GroupSize = new Range(1,3),
                CheckSpawnInterval = 600,
                RequiredWeather = Weather.Rain | Weather.Fog | Weather.None| Weather.ClearSkies,
                Maximum = 2
            };
            LionTroll.Localize().English("Lion Troll");
            LionTroll.Drops["Wood"].Amount = new Range(1, 10);
            LionTroll.Drops["Wood"].DropChance = 100f;
            LionTroll.Drops["Wood"].MultiplyDropByLevel = false;
            LionTroll.ConfigurationEnabled = true;

            RagDoll = LionTroll.Prefab.GetComponent<Humanoid>().m_deathEffects.m_effectPrefabs[1].m_prefab;
            Debug.LogWarning(RagDoll.name);

        }
        

        [HarmonyPatch(typeof(RandEventSystem), nameof(RandEventSystem.Start))]
        [HarmonyPriority(Priority.Last)]
        public static class RaidPatch
        {

            private static RandomEvent _event = new RandomEvent();
            public static void Postfix(RandEventSystem __instance)
            {
                _event.m_enabled = true;
                _event.m_biome = Heightmap.Biome.Meadows;
                _event.m_duration = 60;
                _event.m_name = "LionTroll";
                _event.m_random = true;
                _event.m_startMessage = "The Lion Trolls have stirred!";
                _event.m_spawn = new List<SpawnSystem.SpawnData>
                {
                    new SpawnSystem.SpawnData
                    {
                        m_biome = Heightmap.Biome.Plains,
                        m_enabled = true,
                        m_name = "villager",
                        m_prefab = ZNetScene.instance.GetPrefab("Lion_Troll"),
                        m_huntPlayer = true,
                        m_inForest = true,
                        m_outsideForest = true,
                        m_spawnAtDay = true,
                        m_spawnAtNight = true,
                        m_maxSpawned = 10,
                        m_minLevel = 0,
                        m_groupSizeMax = 10,
                        m_groupSizeMin = 1,
                        m_biomeArea = Heightmap.BiomeArea.Everything,
                    },
                    new SpawnSystem.SpawnData
                    {
                        m_biome = Heightmap.Biome.Meadows,
                        m_enabled = true,
                        m_name = "villager",
                        m_prefab = ZNetScene.instance.GetPrefab("Lion_Troll"),
                        m_huntPlayer = true,
                        m_inForest = true,
                        m_outsideForest = true,
                        m_spawnAtDay = true,
                        m_spawnAtNight = true,
                        m_maxSpawned = 10,
                        m_minLevel = 0,
                        m_groupSizeMax = 10,
                        m_groupSizeMin = 1,
                        m_biomeArea = Heightmap.BiomeArea.Everything,
                    },
                    new SpawnSystem.SpawnData
                    {
                        m_biome = Heightmap.Biome.None,
                        m_enabled = true,
                        m_name = "villager",
                        m_prefab = ZNetScene.instance.GetPrefab("Lion_Troll"),
                        m_huntPlayer = true,
                        m_inForest = true,
                        m_outsideForest = true,
                        m_spawnAtDay = true,
                        m_spawnAtNight = true,
                        m_maxSpawned = 10,
                        m_minLevel = 0,
                        m_groupSizeMax = 10,
                        m_groupSizeMin = 1,
                        m_biomeArea = Heightmap.BiomeArea.Everything,
                    },
                    new SpawnSystem.SpawnData
                    {
                        m_biome = Heightmap.Biome.Swamp,
                        m_enabled = true,
                        m_name = "villager",
                        m_prefab = ZNetScene.instance.GetPrefab("Lion_Troll"),
                        m_huntPlayer = true,
                        m_inForest = true,
                        m_outsideForest = true,
                        m_spawnAtDay = true,
                        m_spawnAtNight = true,
                        m_maxSpawned = 10,
                        m_minLevel = 0,
                        m_groupSizeMax = 10,
                        m_groupSizeMin = 1,
                        m_biomeArea = Heightmap.BiomeArea.Everything,
                    },
                    new SpawnSystem.SpawnData
                    {
                        m_biome = Heightmap.Biome.Mountain,
                        m_enabled = true,
                        m_name = "villager",
                        m_prefab = ZNetScene.instance.GetPrefab("Lion_Troll"),
                        m_huntPlayer = true,
                        m_inForest = true,
                        m_outsideForest = true,
                        m_spawnAtDay = true,
                        m_spawnAtNight = true,
                        m_maxSpawned = 10,
                        m_minLevel = 0,
                        m_groupSizeMax = 10,
                        m_groupSizeMin = 1,
                        m_biomeArea = Heightmap.BiomeArea.Everything,
                    },
                };
                __instance.m_events.Add(_event);
            }
        }

        [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
        public static class FixupFXpatch
        {
            public static void Postfix(ZNetScene __instance)
            {
                GameObject troll = __instance.GetPrefab("Troll");
                var hum = __instance.GetPrefab("Lion_Troll").GetComponent<Humanoid>();
                hum.m_hitEffects.m_effectPrefabs = troll.GetComponent<Humanoid>().m_hitEffects.m_effectPrefabs;
                hum.m_critHitEffects.m_effectPrefabs = troll.GetComponent<Humanoid>().m_critHitEffects.m_effectPrefabs;
                }
        }


        [HarmonyPatch(typeof(ZoneSystem), nameof(ZoneSystem.Start))]
        public class FixupmatsPatch
        {
            public static void Postfix()
            {
                MaterialReplacer.ReplaceAllMaterialsWithOriginal(LionTroll!.Prefab.GetComponent<Humanoid>().m_deathEffects.m_effectPrefabs[2].m_prefab);
                var mat = LionTroll.Prefab.transform.Find("Visual/Lion_Troll").gameObject.GetComponent<SkinnedMeshRenderer>();
                mat.sharedMaterial.shader = ZNetScene.instance.GetPrefab("Troll").transform.Find("Visual/Body").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial.shader;
                mat.material.shader =ZNetScene.instance.GetPrefab("Troll").transform.Find("Visual/Body").gameObject.GetComponent<SkinnedMeshRenderer>().material.shader;
                var ragmatshared = RagDoll.transform.Find("Lion_Troll/Visual/Lion_Troll").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial;
                var ragmat = RagDoll.transform.Find("Lion_Troll/Visual/Lion_Troll").gameObject.GetComponent<SkinnedMeshRenderer>().material;
                ragmatshared.shader = ZNetScene.instance.GetPrefab("Troll").transform.Find("Visual/Body").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial.shader;
                ragmat.shader = ZNetScene.instance.GetPrefab("Troll").transform.Find("Visual/Body").gameObject.GetComponent<SkinnedMeshRenderer>().material.shader;
            }
        }
    }
}