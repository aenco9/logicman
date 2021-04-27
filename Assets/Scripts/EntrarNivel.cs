using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Se utiliza para cambiar de escena al cruzar la puerta
 * Autor: Alejandro Enriquez Coronado
 */

public class EntrarNivel : MonoBehaviour
{
    public bool entrando = false;
    public string nombreScrene;

    //Cuando se choca con un circle collider, se cambia de escena
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verifica que solo logicman pueda cambiar de escena
        if (collision.collider.name == "logicmanSprite")
        {
            entrando = true;
        }
            

    }



    // Update is called once per frame
    void Update()
    {
        //Cambia de escena si las condiciones son correctas
        if (entrando)
        {
            SceneManager.LoadScene(sceneName: nombreScrene);
        }
    }
}
