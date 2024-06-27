using UnityEngine;

namespace solobranch.qLib {
    public static class MathUtilities {
        public static Vector2 GetDirectionFromMouseToOrigin(Vector2 origin) {
            return ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - origin).normalized;
        }
    }
}