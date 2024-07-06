using System;
using solobranch.qLib;
using UnityEngine;

namespace timeloop {
    [DefaultExecutionOrder(-1)]
    public class ManagerCanvas : Singleton<ManagerCanvas> {
        public Canvas canvas { get; private set; }

        protected override void Awake() {
            base.Awake();

            canvas = GetComponent<Canvas>();
        }

        // destroy
        protected override void OnApplicationQuit() {
            base.OnApplicationQuit();
            canvas = null;
        }
    }
}