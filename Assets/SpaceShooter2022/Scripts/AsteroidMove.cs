using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    public float maxSpeed;
    public float minSpeed;

    public float maxRot;
    public float minRot;

    public GameObject target;

    private float astSpeed;
    private float rotSpeed;

    private float xAngle, yAngle, zAngle;

    // Start is called before the first frame update
    void Start()
    {
        astSpeed = UnityEngine.Random.Range(minSpeed,maxSpeed);
        rotSpeed = UnityEngine.Random.Range(minRot,maxRot);

        xAngle = UnityEngine.Random.Range(0, 360);
        yAngle = UnityEngine.Random.Range(0, 360);
        zAngle = UnityEngine.Random.Range(0, 360);

        transform.Rotate(xAngle, yAngle, zAngle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, astSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
    }
}
