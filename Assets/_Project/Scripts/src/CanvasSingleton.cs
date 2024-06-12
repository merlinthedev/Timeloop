using System;
using UnityEngine;

namespace timeloop {
    [DefaultExecutionOrder(-1)]
    public class CanvasSingleton : MonoBehaviour {
        private static Canvas _instance;

        public static Canvas instance {
            get {
                if (_instance == null) {
                    _instance = FindObjectOfType<Canvas>();
                }

                return _instance;
            }

            private set { _instance = value; }
        }

        private void Awake() {
            DontDestroyOnLoad(gameObject);
            instance = this.GetComponent<Canvas>();
        }

        private void OnDestroy() {
            _instance = null;
        }
    }
}