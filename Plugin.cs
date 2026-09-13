using AlwaysonCampfire.Classes;
using AlwaysonCampfire.Utilities;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace AlwaysonCampfire;

[BepInPlugin(Constants.Guid, Constants.Name, Constants.Version)]
public class Plugin : BaseUnityPlugin
{
    public GorillaLog Log = new();

    private Harmony harmony;

    private void Awake()
    {
        harmony = new Harmony(Constants.Guid);
        harmony.PatchAll();
    }

    private void OnDestroy()
    {
        harmony?.UnpatchSelf();
    }

    [HarmonyPatch(typeof(Campfire), nameof(Campfire.SliceUpdate))]
    internal class CampfireAlwaysOn
    {
        static void Prefix(Campfire __instance) => __instance.overrideDayNight = 1;
    }
}
