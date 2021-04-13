using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meta : MonoBehaviour
{
    public GameObject nextLevel;

    void transicion(personajeMinijuego jugador){
        jugador.detenerJug(); // detener jugador

        jugador.transform.position = nextLevel.transform.GetChild(3).transform.position + new Vector3(.4f,0f,0f); // desplazar jugador

        if(jugador.getValorJug()) // El jugador tiene el trail 1
            jugador.trailRend.Clear(); // Apagar trail
        else // El jugador tiene el trail 0
            jugador.fantasma.GetComponent<TrailRenderer>().Clear(); // Apagar trail

        Camera.main.transform.position = nextLevel.transform.position; // desplazar camara       
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            transicion(other.gameObject.GetComponent<personajeMinijuego>());
       }
    }
}
