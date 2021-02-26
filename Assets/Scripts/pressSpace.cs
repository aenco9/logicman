using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressSpace : MonoBehaviour
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
        //Debug.Log(espacio);
        if (espacio > 0)
        {
            sound.Play();
            SceneManager.LoadScene("Login");
        }

    }
}
