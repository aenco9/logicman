using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Autor: Rubén Sánchez Mayén
//Descripción: Script de la meta para cambiar de escena

public class End : MonoBehaviour
{
    public string siguienteEscena = "nivelDos";
    //Cambiar de nivel
    private IEnumerator WaitForSceneLoad()
    {
        //Espera 1 segundo y cargar la escena
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(siguienteEscena);
    }

    private void OnTriggerEnter2D(Collider2D other){
        //Revisar que sea el jugador
        if(other.gameObject.CompareTag("Player")){
            //Cambiar de escena
            StartCoroutine(WaitForSceneLoad());
            //Hacer sonido
            GetComponent<AudioSource>().Play();
        }
    }
}
