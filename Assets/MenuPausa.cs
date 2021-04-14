using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool estaPausado = false;
    public GameObject UIMenuPausa;

    // Update is called once per frame
    void Update()
    {
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

    public void CargarMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SplashScreen");
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}


