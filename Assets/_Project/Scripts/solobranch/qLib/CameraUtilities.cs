using System;
using UnityEngine;

namespace solobranch.qLib {
    public static class CameraUtilities {
        public static Vector3 GetMouseWorldPosition() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //int layerMask = LayerMask.GetMask("ExcludeFromMovementClicks");
            //layerMask = ~layerMask;
            //if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                var mousePos = hit.point;
                mousePos.y = 1;
                
                return mousePos;
            }
            
            throw new Exception("Our raycast did not find something... check where we are hovering [Utilities]");
        }

        public static bool should_camera_follow_target(float horizontal_viewport_percentage, float vertical_viewport_percentage, Vector3 target_position, Camera camera = null) {
            if (camera == null) camera = Camera.main;
            var camera_viewport_position = camera.WorldToViewportPoint(target_position);

            return true;

        }
    }
}