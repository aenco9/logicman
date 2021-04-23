using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salida : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){ //Revisar que sea el jugador
            transform.parent.GetComponent<BoxCollider2D>().enabled = true;
            other.gameObject.GetComponent<PersonajeMinijuego>().bloquearInput = false;
        }
    }
}
