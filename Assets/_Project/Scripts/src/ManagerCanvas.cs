using System;
using solobranch.qLib;
using UnityEngine;

namespace timeloop {
    [DefaultExecutionOrder(-1)]
    public class ManagerCanvas : Singleton<Canvas> {
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
            instance = this.GetComponent<Canvas>();
        }

        private void OnDestroy() {
            _instance = null;
        }
    }
}