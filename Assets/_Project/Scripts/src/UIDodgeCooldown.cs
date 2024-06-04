using System;
using solobranch.qLib;
using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    public class UIDodgeCooldown : MonoBehaviour {
        private Image cooldownSprite = null;
        private bool shouldTick = false;
        private float dodgeCooldown = 0f;
        
        private void OnEnable() {
            EventBus<DodgeUsedEvent>.Subscribe(OnDodgeUsed);
        }

        private void OnDisable() {
            EventBus<DodgeUsedEvent>.Unsubscribe(OnDodgeUsed);
        }

        private void Start() {
            cooldownSprite = GetComponent<Image>();
            cooldownSprite.fillAmount = 0f;
        }

        private void Update() {
            if (!shouldTick) return;
            
            cooldownSprite.fillAmount -= Time.deltaTime / dodgeCooldown;
            if (cooldownSprite.fillAmount <= 0f) {
                shouldTick = false;
                cooldownSprite.fillAmount = 0f;
            }
        }

        private void OnDodgeUsed(DodgeUsedEvent e) {
            dodgeCooldown = e.dodgeCooldown;
            cooldownSprite.fillAmount = 1f;
            shouldTick = true;
        }
    }
}