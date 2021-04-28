using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Controlador para pausar el juego y administrar elementos del canvas
 * Autor: Octavio Andrick Sánchez Perusquia
 */

public class MenuPausa : MonoBehaviour
{
    public static bool estaPausado = false;
    public GameObject UIMenuPausa;

    void Update()
    {
        //Pausar y reanudar al presionar ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }
    public void Reanudar()
    {
        UIMenuPausa.SetActive(false);
        Time.timeScale = 1;
        estaPausado = false;
    }

    void Pausar()
    {
        UIMenuPausa.SetActive(true);
        Time.timeScale = 0;
        estaPausado = true;
    }

    //Cambiar al splashcreen al seleccionar la opcion
    public void CargarMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SplashScreen");
    }

    //Cerrar la aplicación al seleccionar la opción
    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}


