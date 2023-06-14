using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerCatcher : MonoBehaviour
{
    Camera cam;

    private void Awake() {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo, 100f)) {
                var runner = hitInfo.collider.GetComponentInParent<Runner>();
                if(runner != null) {
                    runner.Clicked();
                }
            }
        }
    }
}
