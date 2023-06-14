using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Runner : MonoBehaviour
{
    protected float currentAngle;

    [SerializeField]
    protected float speed;

    public void Clicked() {
        Highlight();
        Hit();
    }

    protected void GenerateAngle() {
        currentAngle = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0, currentAngle, 0);
    }

    private void Highlight() { 
        MeshRenderer mesh = GetComponentInChildren<MeshRenderer>();
        mesh.material.color = Color.blue;
    }

    protected abstract void Move();

    protected abstract void Hit();

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GenerateAngle();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
