using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControls : MonoBehaviour
{
    public Transform leftGun;
    public Transform rightGun;
    public GameObject laserPrefab;
    public int countdown;
    public int countdownDefault = 10;
    // Start is called before the first frame update
    void Start()
    {
        countdown = countdownDefault;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countdown--;
        if(countdown < 1)
        {
            countdown = countdownDefault;
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.E))
            {
                GameObject i = Instantiate(laserPrefab, leftGun.position, leftGun.rotation);
                i.GetComponent<laser>().initialVelocity=GetComponent<Rigidbody>().velocity * Time.deltaTime;
                GameObject j = Instantiate(laserPrefab, rightGun.position, rightGun.rotation);
                j.GetComponent<laser>().initialVelocity = GetComponent<Rigidbody>().velocity * Time.deltaTime;
                Debug.Log("Firing");
            }
        }
        
        Debug.Log("S");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(leftGun.transform.position, leftGun.transform.position + leftGun.transform.forward);
        Gizmos.DrawLine(rightGun.transform.position, rightGun.transform.position + rightGun.transform.forward);
    }
}
