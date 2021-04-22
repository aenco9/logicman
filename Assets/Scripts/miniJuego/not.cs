using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Ruben Sanchez Mayen
//Descripcion: Controlador de la compuerta not. Administra colliders para detectar al jugador y cambiar su nave.

public class Not : MonoBehaviour
{
    public bool collider1,collider2;

    public void ActualizarColliders(bool col1, bool col2){
        //Activar los colliders correspondientes
        if(col1)
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
        else
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        //Collider 2
        if(col2)
            transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
        else
            transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
    }

    void Start(){
        //Inicializar compuerta segun las especificaciones marcadas en unity
        ActualizarColliders(collider1,collider2); 
    }

}
