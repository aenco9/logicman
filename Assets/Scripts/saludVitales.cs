using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Script utilizado para mostrar la salud de personaje en un canvas
 * Autor: Alejandro Enriquez Coronado
 */

public class SaludVitales : MonoBehaviour
{

    public string salud;
    public Text t;
    public GameObject logicman;
    public Transform child;
    // Start is called before the first frame update

    void Start()
    {
        //Encuentra algun objeto de transform llamado Salud
        child = transform.Find("Salud");
        t = child.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Lo convierte a string y dependiendo de su valor, cambia el color del texto
        t.text = logicman.GetComponent<MoverPersonaje>().salud.ToString();
        if (float.Parse(t.text) >= 80) {
            t.color = Color.green;
        }
        else if (float.Parse(t.text) >= 40)
        {
            t.color = Color.yellow;
        }
        else
        {
            t.color = Color.red;
        }
    }
}
