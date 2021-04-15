using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Dispara();
        }
    }

    void Dispara()
    {
        Vector3 offsetcollider;
        if (firePoint.rotation.y >= 1)
        {
            offsetcollider = new Vector3(-0.5F, 0, 0);
        }
        else
        {
            offsetcollider = new Vector3(0.5F, 0, 0);
        }

        
        Instantiate(bulletPrefab, firePoint.position+offsetcollider , firePoint.rotation);
        //Debug.Log(firePoint.rotation.y);
    }
}
