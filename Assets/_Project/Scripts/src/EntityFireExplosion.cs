using System;
using solobranch.qLib;
using UnityEngine;

namespace timeloop {
    public class EntityFireExplosion : Entity {
        private Collider2D collider2d;
        private float damage;

        private void Start() {
            collider2d.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            throw new NotImplementedException();
        }
    }
}