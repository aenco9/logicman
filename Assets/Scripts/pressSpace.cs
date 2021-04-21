using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Detecta la tecla espacio en el SplashScreen y avanza a la siguiente escena
 * Autor: Alejandro Enriquez Coronado
 */

public class PressSpace : MonoBehaviour
{
    public AudioSource sound;
    // METODOS
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float espacio = Input.GetAxis("Jump");
        if (espacio > 0)
        {
            sound.Play();
            SceneManager.LoadScene("Login");
        }
    }
}
