using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Ruben Sanchez Mayen
//Descripcion: Collider de trigger que reactiva la compuerta or cuando sale el jugador.

public class SalidaOr : MonoBehaviour
{
    //Objetos a cambiar
    public GameObject or;
    public GameObject mitad;

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){ //Revisar que sea el jugador
            //Activar colliders
            transform.parent.GetComponent<BoxCollider2D>().enabled = true;
            other.gameObject.GetComponent<PersonajeMinijuego>().bloquearInput = false;
            or.GetComponent<Or>().AdministrarColliders(true);
            mitad.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
