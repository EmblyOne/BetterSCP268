using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Interactables;
using Interactables.Verification;
using UnityEngine;

namespace BetterSCP268
{
    [HarmonyPatch(typeof(StandardDistanceVerification), nameof(StandardDistanceVerification.ServerCanInteract))]
    internal class InteractSCP268Patch
    {
        public static bool Prefix(StandardDistanceVerification __instance, ReferenceHub hub, InteractableCollider collider, ref bool __result)
        { 
            if (!__instance._allowHandcuffed && !global::PlayerInteract.CanDisarmedInteract && hub.interCoordinator.Handcuffed)
            {
                __result = false;
                return false;
            }
            if (Vector3.Distance(hub.playerMovementSync.RealModelPosition, collider.transform.position + collider.transform.TransformDirection(collider.VerificationOffset)) < __instance._maxDistance * 1.4f)
            {
                __result = true;
                return false;
            }
            return false;
        }
    }
}
