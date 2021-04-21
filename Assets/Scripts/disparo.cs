using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Código para crear el Prefab del bullet cada que
 * el usaurio presiona el Fire 1 (click)
 * Autor: Alejandro Enriquez Coronado
 */

public class Disparo : MonoBehaviour
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
        //Se ejecuta el método dispara cada que se presiona
        if (Input.GetButtonDown("Fire1"))
        {
            Dispara();
        }
    }

    void Dispara()
    {
        //Se le agrega un vector para que la bala no choque
        //con el box collider y desaparezca
        Vector3 offsetcollider;
        if (firePoint.rotation.y >= 1)
        {
            offsetcollider = new Vector3(-0.5F, 0, 0);
        }
        else
        {
            offsetcollider = new Vector3(0.5F, 0, 0);
        }

        //Se crea el objeto de bala
        Instantiate(bulletPrefab, firePoint.position+offsetcollider , firePoint.rotation);
    }
}
