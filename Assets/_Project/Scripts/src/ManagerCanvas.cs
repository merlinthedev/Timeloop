using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    [DefaultExecutionOrder(-1)]
    public class ManagerCanvas : solobranch.qLib.Singleton<ManagerCanvas> {
        public Canvas canvas { get; private set; }

        [SerializeField] private Image ability1Image = null;
        [SerializeField] private Image ability2Image = null;

        private KeyValuePair<Ability, Image> one;
        private KeyValuePair<Ability, Image> two;

        protected override void Awake() {
            base.Awake();

            canvas = GetComponent<Canvas>();
        }

        private void Update() {
            if (one.Key != null)
                ability1Image.fillAmount = one.Key.Tick();
            if (two.Key != null)
                ability2Image.fillAmount = two.Key.Tick();
        }

        // destroy
        protected override void OnApplicationQuit() {
            canvas = null;
            base.OnApplicationQuit();
        }

        public void Hook(Ability ability) {
            if (one.Key != null) {
                two = new KeyValuePair<Ability, Image>(ability, ability2Image);
            }
            else if (one.Key == null) {
                one = new KeyValuePair<Ability, Image>(ability, ability1Image);
            }
            else {
                Debug.Log("Can not.", this);
                return;
            }
        }
    }
}