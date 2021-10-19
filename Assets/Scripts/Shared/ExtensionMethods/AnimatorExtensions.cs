using System.Collections;
using UnityEngine;

namespace Infinity.Shared.ExtensionMethods {
    public static class AnimatorExtensions {

        public static IEnumerator PlayAnimationAndWait(this Animator animator, string stateName, int layer = 0) {

            int stateHash = Animator.StringToHash(stateName);
            animator.Play(stateHash, layer);
            yield return new WaitForEndOfFrame();

            float length = animator.GetCurrentAnimatorStateInfo(layer).length;
            yield return new WaitForSeconds(length);

            yield return new WaitForEndOfFrame();
        }
    }
}
