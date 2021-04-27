using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Cambiar);
        
    }

    void Cambiar()
    {
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
