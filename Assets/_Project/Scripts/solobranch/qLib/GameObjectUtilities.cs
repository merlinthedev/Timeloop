using UnityEngine;

namespace solobranch.qLib {
    public static class GameObjectUtilities {

        public static bool HasComponentInHierarchy<T>(GameObject gameObject) where T : Component {
            Transform topLevelParent = FindTopLevelParent(gameObject.transform);
            T component = topLevelParent.GetComponentInChildren<T>();
            
            return component != null;
        }

        public static Transform FindTopLevelParent(Transform transform) {
            Transform parent = transform.parent;
            while (parent != null) {
                transform = parent;
                parent = transform.parent;
            }
            
            return transform;
        }
        
    }
}