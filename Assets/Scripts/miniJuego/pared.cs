using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pared : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        print("enter");
        personajeMinijuego.detenerJug();
    }
    private void OnTriggerExit2D(Collider2D other){
        personajeMinijuego.reanudarJug();
    }
}
