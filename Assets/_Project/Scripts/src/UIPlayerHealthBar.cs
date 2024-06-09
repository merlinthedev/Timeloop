using solobranch.qLib;
using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    public class UIPlayerHealthBar : MonoBehaviour {
        [SerializeField] private Image healthBarImage;

        private void OnEnable() {
            EventBus<UIUpdateHealthBarEvent>.Subscribe(UpdatePlayerHealthBar);
        }

        private void OnDisable() {
            EventBus<UIUpdateHealthBarEvent>.Unsubscribe(UpdatePlayerHealthBar);
        }


        private void UpdatePlayerHealthBar(UIUpdateHealthBarEvent e) {
            Debug.Log("Handling healthbar event.");
            Debug.Log(e.fillAmount + " fill amount.");
            healthBarImage.fillAmount = e.fillAmount;
        }
    }
}