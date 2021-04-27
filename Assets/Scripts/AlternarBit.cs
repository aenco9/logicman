using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Cambia de 1 a 0 y visceversa en las casillas numericas
 * Autor: Alejandro Enriquez Coronado
 */
public class AlternarBit : MonoBehaviour
{

    private string valor;
    private Button btn;
    private string active;
    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        //Listeners para detectar los clicks
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Cambiar);
    }

    void Cambiar()
    {
        //Cada que se da click, se invierte el valor binario y cambia de color la guia de abajo
        valor = GetComponent<Text>().text;
        active = gameObject.name.Substring(gameObject.name.Length - 1);
        if (valor == "0")
        {
            GetComponent<Text>().text = "1";
            GameObject.Find("guia" + active).GetComponent<Text>().color = Color.green;
            GameObject.Find("guiaExp" + active).GetComponent<Text>().color = Color.green;
        }
        else
        {
            GetComponent<Text>().text = "0";
            GameObject.Find("guia" + active).GetComponent<Text>().color = Color.white;
            GameObject.Find("guiaExp" + active).GetComponent<Text>().color = Color.white;
        }
    }
}
