using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Autor: Rubén Sánchez Mayén
//Descripción: Resta la salud de la nave cada que recibe un disparo. Se refleja en el canvas.

public class SaludNave : MonoBehaviour
{
    public PersonajeMinijuego nave;
    public Text textoSalud;
    
    void Update()
    {
        int puntosSalud = nave.GetVidas() * 10;
        //Lo convierte a string y dependiendo de su valor, cambia el color del texto
        textoSalud.text = puntosSalud.ToString();
        if (float.Parse(textoSalud.text) >= 80) {
            textoSalud.color = Color.green;
        }
        else if (float.Parse(textoSalud.text) >= 40)
        {
            textoSalud.color = Color.yellow;
        }
        else
        {
            textoSalud.color = Color.red;
        }
    }
}
