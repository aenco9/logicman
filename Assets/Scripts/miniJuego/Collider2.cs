using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Ruben Sanchez Mayen
//Descripcion: Collider de la puerta not que detecta al jugador, cambia su nave y da la señal a al script Not
//para organizar los colliders

public class Collider2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            //Cambiar Nave del jugador
            other.gameObject.GetComponent<PersonajeMinijuego>().Not();
            //Apagar este collider y prender el collider1
            transform.parent.gameObject.GetComponent<Not>().ActualizarColliders(true,false);
        }
    }
}
