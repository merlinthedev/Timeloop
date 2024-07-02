using UnityEngine;

namespace timeloop {
    public class AbilityJoostCigarette : Ability {
        [SerializeField] private GameObject cigarettePrefab;
        [SerializeField] private float entityMovementSpeed = 20f;

        public override void OnUse(EntityDamager damager) {
            if (!canUse) return; // on cooldown or smth

            // get the direction vector between the damager and the player
            Vector2 direction = ((BossLuchtballon)damager).GetPlayerEntity().transform.position - damager.transform.position;
            float angleOfDirection = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            // instantiate the cigarette prefab and rotate the cigarette to face the player
            GameObject cigaretteGameObject = Instantiate(cigarettePrefab, damager.transform.position, Quaternion.Euler(0, 0, angleOfDirection));
            EntityJoostCigarette cigarette = cigaretteGameObject.GetComponent<EntityJoostCigarette>();
            cigarette.Initialize(damager, entityMovementSpeed);
            
            PostAbilityUse();
        }
    }
}