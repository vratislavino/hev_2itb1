using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    private float radius = 8f;
    private float density = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateWalls();
    }

    void GenerateWalls() {
        float x, y;
        GameObject wall;

        for(float i = 0; i <= 360 / density; i += density) {
            x = radius * Mathf.Cos(i);
            y = radius * Mathf.Sin(i);
            wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.transform.position = new Vector3(x, 0, y);
            wall.transform.rotation = Quaternion.Euler(0, i, 0);
        }
    }
}
