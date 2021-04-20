using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public Text textoNombre;
    public Text textoContra;
    public void cambiar(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


    public void Verificar2()
    {
        //Concurrente
        StartCoroutine(routine: verificarUsuario2());
    }
    private IEnumerator verificarUsuario2()
    {   

        WWWForm forma = new WWWForm();

        forma.AddField("nombre", value: textoNombre.text);
        forma.AddField("contra", value: textoContra.text);


        //UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/postVer", forma);
        UnityWebRequest request = UnityWebRequest.Post("http://logicman.educationhost.cloud/postVer", forma);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            string textoPlano = request.downloadHandler.text;
            if(textoPlano == "confirmado")
            {
                cambiar("nivelUno");
            }
        }

    }
}

