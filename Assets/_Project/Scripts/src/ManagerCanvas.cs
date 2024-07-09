using System;
using System.Collections.Generic;
using solobranch.qLib;
using UnityEngine;

namespace timeloop {
    [DefaultExecutionOrder(-1)]
    public class ManagerCanvas : Singleton<ManagerCanvas> {
        public Canvas canvas { get; private set; }

        private List<GameObject> abilities = new();
        
        protected override void Awake() {
            base.Awake();

            canvas = GetComponent<Canvas>();
        }

        private void Update() {
            abilities.ForEach(ability => {
                // TODO: START HERE
            });
        }

        // destroy
        protected override void OnApplicationQuit() {
            canvas = null;
            base.OnApplicationQuit();
        }
    }
    
}