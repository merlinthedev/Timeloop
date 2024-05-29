using solobranch.qLib;
using UnityEngine;
using UnityEngine.Serialization;

namespace timeloop {
    public class CameraFollowAgent : MonoBehaviour {
        [SerializeField] private Transform followTarget;
        private bool following = true;

        private void Start() {
            if (followTarget == null) {
                following = false;
            }
        }

        private void Update() {
            FollowTarget();
        }

        private void FollowTarget() {
            if (!following) return;

            // lerp after the target
        }
    }
}