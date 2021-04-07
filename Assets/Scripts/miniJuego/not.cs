using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class not : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        other.gameObject.GetComponent<personajeMinijuego>().not();
    }

}
