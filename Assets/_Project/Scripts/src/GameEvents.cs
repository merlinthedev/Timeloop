using solobranch.qLib;

namespace timeloop {
    public class DodgeUsedEvent : Event {
        public readonly float dodgeCooldown;

        public DodgeUsedEvent(float dodgeCooldown) {
            this.dodgeCooldown = dodgeCooldown;
        }
    }
}