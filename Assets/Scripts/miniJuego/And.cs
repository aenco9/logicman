using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Rubén Sánchez Mayén
//Descripción: Controlador de la compuerta and. Hace la operación lógica y envía los resultados a PersonajeMinijuego.

public class And : MonoBehaviour
{
    //Entradas del and
    public bool entrada1,entrada2;

    //Operación lógica
    void CalcularAnd(PersonajeMinijuego jugador){
        //Quitar colliders
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
        //Controlador and en PersonajeMinijuego
        jugador.And(entrada1 && entrada2, transform.position.y); 
    }   

    //Recepción y procesamiento de los colliders
    public void RecibirCollider(PersonajeMinijuego jugador, int numCollider){
        if(numCollider == 1)
            entrada1 = jugador.valorJug;
        else if(numCollider == 2)
            entrada2 = jugador.valorJug;
        CalcularAnd(jugador);
    }

}
