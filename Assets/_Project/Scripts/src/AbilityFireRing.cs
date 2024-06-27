namespace timeloop {
    public class AbilityFireRing : Ability {
        public override void OnUse(EntityDamager damager) {
            if (!canUse) return;
            
            
            PostAbilityUse();
        }
    }
}