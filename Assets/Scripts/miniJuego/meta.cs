using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meta : MonoBehaviour
{
    public GameObject nextLevel;

    void transicion(personajeMinijuego jugador){
        jugador.detenerJug(); // detener jugador

        jugador.transform.position = nextLevel.transform.GetChild(3).transform.position + new Vector3(.4f,0f,0f); // desplazar jugador
        Camera.main.transform.position = nextLevel.transform.position; // desplazar camara       
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            transicion(other.gameObject.GetComponent<personajeMinijuego>());
       }
    }
}
