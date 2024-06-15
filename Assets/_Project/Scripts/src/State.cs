namespace timeloop {
    public abstract class State {
        protected BossLuchtballon.BossData bossData;
        protected State(BossLuchtballon.BossData bossData) {
            this.bossData = bossData;
        }
        
        public virtual void Enter() {}
        public virtual void Tick() {}
        public virtual void Exit() {}
    }
}