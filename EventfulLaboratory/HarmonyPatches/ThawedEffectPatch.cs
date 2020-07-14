﻿using System.Reflection;
using System.Runtime.CompilerServices;
using EventfulLaboratory.Effects;
using Harmony;
using YamlDotNet.Core;

namespace EventfulLaboratory.HarmonyPatches
{
    [HarmonyPatch(typeof(PlayerEffectsController), "Awake")]
    public class ThawedEffectPatch
    {
        public static void Postfix(PlayerEffectsController controller)
        {
            PlayerEffect pe = controller.GetAllEffects()[0];
            controller.GetAllEffects().Add(new Thawed(controller.GetComponent<PlayerStats>(), Constant.THAWED_EFFECT_API_NAME));
        }
    }
}