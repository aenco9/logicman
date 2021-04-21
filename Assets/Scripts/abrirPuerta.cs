using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuerta : MonoBehaviour
{

    private int enemigos;
    private Renderer rend;
    private BoxCollider2D caja;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        caja = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemigos = GameObject.FindGameObjectsWithTag("enemigo").Length;
        if (enemigos == 0)
        {
            rend.enabled = false;
            caja.enabled = false;
        }
        Debug.Log(enemigos);
    }
}
