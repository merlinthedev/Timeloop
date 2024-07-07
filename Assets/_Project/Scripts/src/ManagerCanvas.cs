using System;
using solobranch.qLib;
using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    [DefaultExecutionOrder(-1)]
    public class ManagerCanvas : Singleton<ManagerCanvas> {
        public Canvas canvas { get; private set; }
        private UIPlayerAbilityCooldowns uiPlayerAbilityCooldowns = new();

        protected override void Awake() {
            base.Awake();

            canvas = GetComponent<Canvas>();
        }
        
        public void HookAbility(float cooldown, Image image) {
            uiPlayerAbilityCooldowns.AddAbilityCooldown(cooldown, image);
        }

        private void Update() {
            uiPlayerAbilityCooldowns.Tick();
        }

        // destroy
        protected override void OnApplicationQuit() {
            base.OnApplicationQuit();
            canvas = null;
        }
    }
    
}