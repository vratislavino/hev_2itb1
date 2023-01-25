using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohybKoule : MonoBehaviour
{
    [SerializeField]
    private Transform koule;

    [SerializeField]
    private float speed;


    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 center = new Vector2(Screen.width/2, Screen.height/2);
        var dir = mousePos - center;
        var dir3 = new Vector3(dir.x, 0, dir.y).normalized;

        koule.position += dir3 * speed * Time.deltaTime;

        if(Input.GetMouseButtonDown(0)) {
            koule.position = Vector3.up;
        }
    }
}
