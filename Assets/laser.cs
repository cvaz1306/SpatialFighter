using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public Transform Laser;
    RaycastHit hit;
    public float speed;
    float age;
    public float maxAge;
    public Vector3 initialVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (age > maxAge)
        {
            Destroy(gameObject);
        }
        age += speed;
        transform.position -= transform.forward * Time.deltaTime*speed;
        transform.position += initialVelocity;
        if(Laser != null)
        {
            if(Physics.Raycast(new Ray(Laser.position, Laser.forward), out hit, 1)){
                Destroy(gameObject);
            }
        }
    }
}
