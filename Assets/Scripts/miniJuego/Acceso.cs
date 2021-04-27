using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Ruben Sanchez Mayen
//Descripcion: Permite o no pasar al jugador por un tunel dependiendo de su valorJug. El letrero del acceso muestra la condicion

public class Acceso : MonoBehaviour
{
    public bool valorPermitido;
    //Efectos de audio
    public AudioSource permitido;
    public AudioSource bloqueado;

    void ActualizarLetrero(){
        //Activar/Desactivar figuras de las naves en el letrero
        if(valorPermitido){
            transform.GetChild(2).GetComponent<Renderer>().enabled = false;
            transform.GetChild(3).GetComponent<Renderer>().enabled = true;
        }else{
            transform.GetChild(2).GetComponent<Renderer>().enabled = true;
            transform.GetChild(3).GetComponent<Renderer>().enabled = false;
        }
    }

    //Verificar si el jugador puede pasar
    public void evaluar(bool valorJug){
        if(valorJug == valorPermitido){
            GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(4).GetComponent<Renderer>().enabled = false;
            permitido.Play();
        }
        else{
            GetComponent<BoxCollider2D>().enabled = true;
            transform.GetChild(4).GetComponent<Renderer>().enabled = true;
            bloqueado.Play();
        }
        
    }

    void Start(){
        ActualizarLetrero();
    }

}
