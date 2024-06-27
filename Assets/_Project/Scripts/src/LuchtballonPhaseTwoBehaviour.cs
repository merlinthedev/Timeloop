using System.Collections.Generic;
using UnityEngine;

namespace timeloop {
    public class LuchtballonPhaseTwoBehaviour : IBossBehaviour {
        private readonly BossLuchtballon boss;
        private BossState currentState = BossState.COOLDOWN;

        private const float cooldownTime = 1.2f;
        private float cooldownTimer = 0f;

        private List<Ability> bossAbilities;
        
        public LuchtballonPhaseTwoBehaviour(BossLuchtballon boss) {
            this.boss = boss;
        }

        public void Enter() {
            boss.SetMovementSpeed(20f);
            boss.SetInvulnerable(false);
        }

        public void Tick() {
            HandleState();
        }

        public void Exit() { }

        private void HandleState() {
            switch (currentState) {
                case BossState.COOLDOWN:
                    TickCooldownTimer();
                    break;
                case BossState.EVALUATE:
                    int r = Random.Range(0, 2);
                    currentState = r == 0 ? BossState.MOVING : BossState.CASTING;
                    break;
                case BossState.MOVING:
                    break;
                case BossState.CASTING:
                    break;
            }
        }
        
        private void Move() {}
        private void Cast() {}

        private void TickCooldownTimer() {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0) {
                currentState = BossState.EVALUATE;
            }
        }

        enum BossState {
            COOLDOWN,
            EVALUATE, // state to evaluate whether to move or to cast an ability
            MOVING,
            CASTING
        }
    }
}