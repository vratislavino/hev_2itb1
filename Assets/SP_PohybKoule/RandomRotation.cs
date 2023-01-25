using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    private Vector3 targetRotation;
    [SerializeField]
    private float wildness = 0.5f;
    [SerializeField]
    private float changeCooldown = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateRotation());
    }

    private IEnumerator GenerateRotation() {
        while(true) {
            targetRotation = new Vector3(
                Random.Range(-30,30),
                Random.Range(-30,30),
                Random.Range(-30,30)
                );
            yield return new WaitForSeconds(changeCooldown);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        Vector3 newRot = (currentRotation - targetRotation) * wildness;

        transform.rotation = Quaternion.Euler(currentRotation+newRot);
    }
}
