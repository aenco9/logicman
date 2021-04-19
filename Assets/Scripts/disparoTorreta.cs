using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoTorreta : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    private Transform activeCannon;
    private float nextActionTime = 0.0f;
    public float period = 4f;
    private Vector3 offsetcollider;
    // Start is called before the first frame update
    void Start()
    {
        activeCannon = firePoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Dispara();
            if (activeCannon == firePoint)
            {
                activeCannon = firePoint2;
                offsetcollider = new Vector3(0.5F, 0, 0);
            }
            else
            {
                activeCannon= firePoint;
                offsetcollider = new Vector3(-0.5F, 0, 0);
            }
        }
    }

    void Dispara()
    {
       

        Instantiate(bulletPrefab, activeCannon.position+offsetcollider, activeCannon.rotation);
        //Instantiate(bulletPrefab, firePoint2.position + offsetcollider, firePoint2.rotation);
        //Debug.Log(firePoint.rotation.y);
    }
}
