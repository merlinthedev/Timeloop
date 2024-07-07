using System.Collections.Generic;


namespace timeloop {
    public class UIPlayerAbilityCooldowns {
        private List<AbilityCooldown> abilityCooldowns = new();

        public void AddAbilityCooldown(float cooldown, UnityEngine.UI.Image image) {
            abilityCooldowns.Add(new AbilityCooldown(cooldown, image));
        }

        public void Tick() {
            for(int i = 0 ; i < abilityCooldowns.Count; i++) {
                abilityCooldowns[i].Tick();
            }
        }
    }

    class AbilityCooldown {
        private float cooldown;
        private float tick;
        private UnityEngine.UI.Image image;

        public AbilityCooldown(float cooldown, UnityEngine.UI.Image image) {
            this.cooldown = cooldown;
            this.tick = cooldown;
            this.image = image;
        }

        public void Tick() {
            if (tick > 0) {
                image.fillAmount = tick / cooldown;
            }
        }
    }
}