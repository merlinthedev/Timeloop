using solobranch.qLib;
using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    public class UIBossBar : MonoBehaviour {
        private Image image = null;
        private bool shouldCheck = true;
        
        private void OnEnable() {
            EventBus<UIUpdateBossBarEvent>.Subscribe(HandleUIBossBarUpdate);
        }

        private void OnDisable() {
            EventBus<UIUpdateBossBarEvent>.Unsubscribe(HandleUIBossBarUpdate);
        }

        private void HandleUIBossBarUpdate(UIUpdateBossBarEvent e) {
            Boss boss = e.boss; // use for later maybe? XD
            if (shouldCheck) {
                image = boss.GetFillImage();
                shouldCheck = false;
            }
            
            image.fillAmount = e.fillAmount;
        }
        
    }
}