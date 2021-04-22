using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Deshabilita el sprite de la puerta y su box
 * collider cuando ya no hay enemigos
 * Autor: Alejandro Enriquez Coronado
 */

public class AbrirPuerta : MonoBehaviour
{

    private int enemigos;
    private Renderer rend;
    private BoxCollider2D caja;
    // Start is called before the first frame update
    void Start()
    { 
        // Determina los GameObjects utilizados
        rend = GetComponent<Renderer>();
        caja = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Determina el numero de objetos en la escena con el tag enemigo
        enemigos = GameObject.FindGameObjectsWithTag("enemigo").Length;
        if (enemigos == 0)
        {
            rend.enabled = false;
            caja.enabled = false;
        }
    }
}
