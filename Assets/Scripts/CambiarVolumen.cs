using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CambiarVolumen : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumenMusica", 0.5f);
    }

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
