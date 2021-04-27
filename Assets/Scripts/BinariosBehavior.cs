using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class BinariosBehavior : MonoBehaviour
{
    public GameObject UIIntro;
    private GameObject[] bits;
    private GameObject resultado;
    private GameObject numTemporal;
    private GameObject excelente;
    private int rondas;
    private int[] numeros;
    private bool saliendo;
    private AudioSource sonido;
    public String escena;

    // Start is called before the first frame update
    void Start()
    {
        saliendo = false;
        numeros = new int[] { 8, 16, 24, 120, 184, 255 };
        bits = new GameObject[8];
        resultado = GameObject.Find("Resultado");
        excelente = GameObject.Find("excelente");
        excelente.SetActive(false);
        numTemporal = GameObject.Find("Resultado (1)");
        sonido = GetComponent<AudioSource>();
        rondas = 0;
        for (int i = 0; i < bits.Length; i++)
        {
            bits[i] = GameObject.Find("Bit" + i.ToString());
        }
        resultado.GetComponent<Text>().text = numeros[0].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (rondas < 6)
        {
            if (resultado.GetComponent<Text>().text == ConvertirADec(bits).ToString())
            {
                
                rondas += 1;
                sonido.Play();
                StartCoroutine(Flasher());
                if (rondas <= 5)
                {
                    resultado.GetComponent<Text>().text = numeros[rondas].ToString();
                }
                
            }
        }
        else
        {
            if (!saliendo)
            {
                StartCoroutine(Flasher2());
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
            yield return new WaitForSeconds(0.05f);
            resultado.GetComponent<Text>().color = Color.white;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator Flasher2()
    {
        //Hace al sprite cambiar de color rapidamente dos veces
        saliendo = true;
        excelente.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            resultado.GetComponent<Text>().color = Color.blue;
            yield return new WaitForSeconds(.5f);
            resultado.GetComponent<Text>().color = Color.white;
            yield return new WaitForSeconds(.5f);
        }
        SceneManager.LoadScene(sceneName: escena);
    }

    public void Reanudar()
    {
        UIIntro.SetActive(false);
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
