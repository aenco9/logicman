using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controla el disparo de la torreta cada
 * determinado tiempo
 * Autor: Alejandro Enriquez Coronado
 */

public class DisparoTorreta : MonoBehaviour
{

    //Se determinan los objetos y las variables para la velocidad de la torreta
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
        //Se inicia el primer cañon
        activeCannon = firePoint;
    }

    // Update is called once per frame
    void Update()
    {
        //Cada que sucede el intervalo de tiempo, dispara y cambia de cañon
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Dispara();
            if (activeCannon == firePoint)
            {
                //Cambia de cañon y agrega el offset para no intervenir con el collider de la torreta
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
        //Dispara una bala cada que se llama el metodo
        Instantiate(bulletPrefab, activeCannon.position+offsetcollider, activeCannon.rotation);
    }
}
