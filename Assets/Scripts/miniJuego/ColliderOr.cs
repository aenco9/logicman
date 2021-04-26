using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOr : MonoBehaviour
{
    public int numCollider;

    //Activar/Desactivar collider
    public void EstadoCollider(bool estado){
        GetComponent<BoxCollider2D>().enabled = estado;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){ //Revisar que sea el jugador
            //Mandar señal al padre
            GetComponent<BoxCollider2D>().enabled = false;
            transform.parent.transform.parent.GetComponent<Or>().RecibirCollider(other.gameObject.GetComponent<PersonajeMinijuego>(),numCollider);
            
        }
    }
}
