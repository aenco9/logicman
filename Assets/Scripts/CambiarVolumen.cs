using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/*
 * Modular volumen de elementos que forman parte del mixer con ayuda del slider.
 * Autor: Octavio Andrick Sánchez Perusquia
 */

public class CambiarVolumen : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    //Asignar un valor inicial al slider al pausar por primera vez.
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumenMusica", 0.9f);
    }

    //Detectar si el usuario está presionando el slider y modular el volumen de acuerdo a éste.
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Cambiando...");
            float valor = slider.value;
            mixer.SetFloat("VolumenMusica", Mathf.Log10(valor) * 20);
            PlayerPrefs.SetFloat("VolumenMusica", valor);
        }
        
    }
}
