using UnityEngine;
using System.Collections;

namespace timeloop {
    public static class Utils {
        public static void DelayedForLoop(int iterations, float delay, System.Action<int> action,
            MonoBehaviour context) {
            for (int i = 0; i < iterations; i++) {
                var i1 = i;
                InvokeDelayed(() => {
                    action.Invoke(i1);
                }, delay * i, context);
            }
        }

        public static Coroutine InvokeDelayed(System.Action action, float delay, MonoBehaviour context) {
            return context.StartCoroutine(InvokeDelayedCoroutine(action, delay));
        }

        private static IEnumerator InvokeDelayedCoroutine(System.Action action, float delay) {
            yield return new WaitForSeconds(delay);
            action.Invoke();
        }
    }
}