using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Rubén Sánchez Mayén
//Descripción: Controlador de la compuerta and. Hace la operación lógica y envía los resultados a PersonajeMinijuego. Actualiza la imagen cuando se necesita.

public class And : MonoBehaviour
{
    //Entradas del and
    public bool entrada1,entrada2;

    //Actualizar los letreros del and
    void ActualizarLetreros(){
        //Entrada1
        if(entrada1){
            transform.GetChild(4).GetComponent<Renderer>().enabled = false;
            transform.GetChild(5).GetComponent<Renderer>().enabled = true;
        }else{
            transform.GetChild(4).GetComponent<Renderer>().enabled = true;
            transform.GetChild(5).GetComponent<Renderer>().enabled = false;
        }
        //Entrada2
        if(entrada2){
            transform.GetChild(6).GetComponent<Renderer>().enabled = false;
            transform.GetChild(7).GetComponent<Renderer>().enabled = true;
        }else{
            transform.GetChild(6).GetComponent<Renderer>().enabled = true;
            transform.GetChild(7).GetComponent<Renderer>().enabled = false;
        }
    }
    //Desactivar o Activar colliders dependiendo la entrada
    public void AdministrarColliders(bool activar){
        if(activar){
            transform.GetChild(2).transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            transform.GetChild(3).transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
        }else{
            transform.GetChild(2).transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(3).transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    //Operación lógica
    void CalcularAnd(PersonajeMinijuego jugador){
        //Quitar colliders
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
        AdministrarColliders(false);
        //Controlador and en PersonajeMinijuego
        jugador.And(entrada1 && entrada2, transform.position.y);
        ActualizarLetreros(); 
    }   

    //Recepción y procesamiento de los colliders
    public void RecibirCollider(PersonajeMinijuego jugador, int numCollider){
        if(numCollider == 0)
            entrada1 = jugador.valorJug;
        else if(numCollider == 1)
            entrada2 = jugador.valorJug;
        CalcularAnd(jugador);
    }

    void Start(){
        ActualizarLetreros();
    }

}
