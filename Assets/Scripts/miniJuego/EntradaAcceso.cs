using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Ruben Sanchez Mayen
//Descripcion: Trigger de la entrada de un Acceso. Dispara la autenticacion en el codigo del padre.

public class EntradaAcceso : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        //Revisar que sea el jugador
        if(other.gameObject.CompareTag("Player")){
            //Enviar valor del jugador a la clase Acceso
            transform.parent.GetComponent<Acceso>().evaluar(other.gameObject.GetComponent<PersonajeMinijuego>().valorJug);
        }
    }
}
