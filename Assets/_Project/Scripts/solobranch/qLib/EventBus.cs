using System;

namespace solobranch.qLib {
    public abstract class EventBus<T> where T : Event {
        private static event Action<T> onEventRaised;
        
        public static void Subscribe(Action<T> action) {
            onEventRaised += action;
        }
        
        public static void Unsubscribe(Action<T> action) {
            onEventRaised -= action;
        }
        
        public static void Raise(T eventToRaise) {
            onEventRaised?.Invoke(eventToRaise);
        }
    }
    
    public abstract class Event {}
}