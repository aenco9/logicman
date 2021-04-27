using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BinariosBehavior : MonoBehaviour
{

    private GameObject[] bits;
    private GameObject resultado;
    private GameObject numTemporal;
    private int rondas;
    private int[] numeros;

    // Start is called before the first frame update
    void Start()
    {
        numeros = new int[] { 8, 16, 24, 120, 184, 255 };
        bits = new GameObject[8];
        resultado = GameObject.Find("Resultado");
        numTemporal = GameObject.Find("Resultado (1)");
        rondas = 0;
        for (int i = 0; i < bits.Length; i++)
        {
            bits[i] = GameObject.Find("Bit" + i.ToString());
            //Debug.Log(bits[i].GetComponent<Text>().text);
            //Debug.Log(i);
        }
        resultado.GetComponent<Text>().text = numeros[0].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (rondas < 5)
        {
            if (resultado.GetComponent<Text>().text == ConvertirADec(bits).ToString())
            {
                rondas += 1;
                StartCoroutine(Flasher());
                resultado.GetComponent<Text>().text = numeros[rondas].ToString();
            }
        }
        numTemporal.GetComponent<Text>().text = ConvertirADec(bits).ToString();

    }

    IEnumerator Flasher()
    {
        //Hace al sprite cambiar de color rapidamente dos veces
        for (int i = 0; i < 2; i++)
        {
            resultado.GetComponent<Text>().color = Color.green;
            yield return new WaitForSeconds(.1f);
            resultado.GetComponent<Text>().color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }

    int ConvertirADec(GameObject[] bits)
    {
        string bitConcat = "";
        for (int i = 0; i < bits.Length; i++)
        {
            bitConcat = bits[i].GetComponent<Text>().text + bitConcat;
        }
        return Convert.ToInt32(bitConcat, 2);
    }

}
