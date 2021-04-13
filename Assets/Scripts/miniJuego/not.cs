using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class not : MonoBehaviour
{
    void Start()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.color = colors.color3;
    }

    private void OnTriggerEnter2D(Collider2D other){
        other.gameObject.GetComponent<personajeMinijuego>().not();
    }

}
