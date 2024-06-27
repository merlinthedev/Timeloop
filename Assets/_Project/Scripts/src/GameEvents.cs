using solobranch.qLib;

namespace timeloop {
    public class DodgeUsedEvent : Event {
        public readonly float dodgeCooldown;

        public DodgeUsedEvent(float dodgeCooldown) {
            this.dodgeCooldown = dodgeCooldown;
        }
    }

    public class UIUpdateHealthBarEvent : Event {
        public readonly float fillAmount;

        public UIUpdateHealthBarEvent(float fillAmount) {
            this.fillAmount = fillAmount;
        }
    }

    public class UIUpdateBossBarEvent : Event {
        public readonly Boss boss;
        public readonly float fillAmount;

        public UIUpdateBossBarEvent(Boss boss, float fillAmount) {
            this.boss = boss;
            this.fillAmount = fillAmount;
        }
    }
}