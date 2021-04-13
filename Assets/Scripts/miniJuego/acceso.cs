using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acceso : MonoBehaviour
{
    public GameObject barrera;
    public bool tipo;
    

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        if(tipo){
            rend.material.color = colors.color1;
        }
        else
            rend.material.color = colors.color0;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.GetComponent<personajeMinijuego>().getValorJug() == tipo){
            barrera.GetComponent<BoxCollider2D>().enabled = false;
        }else{
            barrera.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
