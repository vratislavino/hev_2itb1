using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Runner : MonoBehaviour
{
    protected float currentAngle;

    [SerializeField]
    protected float speed;

    MeshRenderer meshRenderer;
    Color originColor;

    public void Clicked() {
        Highlight();
        Hit();
    }

    protected void GenerateAngle() {
        currentAngle = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0, currentAngle, 0);
    }

    private void Highlight() { 
        meshRenderer.material.color = Color.red;
        LeanTween.color(meshRenderer.gameObject, originColor, 0.25f);
    }

    protected void ResetRunner() {
        transform.position = Vector3.zero;
        GenerateAngle();
    }

    protected abstract void Move();

    protected abstract void Hit();

    // Start is called before the first frame update
    protected virtual void Start() {
        
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        originColor = meshRenderer.material.color;
        GenerateAngle();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
