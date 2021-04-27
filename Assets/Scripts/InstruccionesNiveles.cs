using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Control para las instrucciones del primer nivel
 * Autor: Alejandro Enriquez Coronado
 */
public class InstruccionesNiveles : MonoBehaviour
{

    public GameObject UIIntro;
    // Start is called before the first frame update
    void Start()
    {

        UIIntro.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AceptarInstrucciones()
    {
        UIIntro.SetActive(false);
        Time.timeScale = 1;
    }

}
