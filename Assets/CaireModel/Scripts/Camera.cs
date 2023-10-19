using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public int angle = 3;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + target.position;
        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.up * Input.GetAxis("Mouse X"));
        offset = angleAxis * offset;
        transform.LookAt(target);
    }
}
