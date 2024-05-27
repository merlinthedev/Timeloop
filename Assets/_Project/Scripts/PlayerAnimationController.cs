using UnityEngine;
using UnityEngine.EventSystems;

namespace timeloop {
    public class PlayerAnimationController {
        private Animator animator;
        private static readonly int Dir = Animator.StringToHash("Dir");
        private static readonly int Move = Animator.StringToHash("Move");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private bool isMoving;

        public PlayerAnimationController(Player player) {
            animator = player.GetComponent<Animator>();

#if UNITY_EDITOR
            if (animator == null) {
                Debug.LogError("PlayerAnimationController: Animator component not found on Player GameObject.");
                Object.Destroy(player.gameObject);

                UnityEditor.EditorApplication.isPlaying = false;
            }
#endif
        }

        public void SetDirection(int dir) {
            if (animator.GetInteger(Dir) == dir) {
                return;
            }

            animator.SetInteger(Dir, dir);
        }

        public void UpdateMove(bool isPlayerMoving) {
            if (isPlayerMoving && !isMoving) {
                isMoving = true;
                animator.SetTrigger(Move);
                animator.SetBool(IsMoving, true);
            }
            else if (!isPlayerMoving) {
                isMoving = false;
                animator.SetBool(IsMoving, false);
            }
        }
    }
}