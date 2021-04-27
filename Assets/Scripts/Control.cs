using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

/*
 * Script que verifica las credenciales
 * de inicio de sesión 
 * Autor: Ariel Álvarez Cortés
 */
public class Control : MonoBehaviour
{
    public InputField textoNombre;
    public InputField textoContra;

    public static String nombre;
    public static String contra;
    public static DateTime[] Horas = new DateTime[6];
    public bool entrando = false;
    public string nombreScrene;
    public int nivel;


    public void RegistrarHora(int nivel)
    {
        Horas[nivel] = DateTime.Now;
        print(Horas[nivel]);
    }

    public void GuardarDatos()
    {
        nombre = textoNombre.text;
        contra = textoContra.text;

    }

    public void cambiar(string scenename, int nivel)
    {
        SceneManager.LoadScene(scenename);
        RegistrarHora(nivel);
    }

    public void cambiarLogin(string scenename)
    {
        SceneManager.LoadScene(scenename);

    }

    public void Verificar()
    {
        //Concurrente
        StartCoroutine(routine: verificarUsuario());
    }
    private IEnumerator verificarUsuario()
    {

        WWWForm forma = new WWWForm();

        forma.AddField("nombre", value: textoNombre.text);
        forma.AddField("contra", value: textoContra.text);

        UnityWebRequest request = UnityWebRequest.Post("http://3.22.165.183:8080/postVer", forma);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            string textoPlano = request.downloadHandler.text;
            if (textoPlano == "confirmado")
            {
                cambiar("nivelUno", 0);
            }
        }

    }


    public void RegistrarTiempoRutina()
    {
        //Concurrente
        StartCoroutine(routine: RegistrarTiempo());
    }
    private IEnumerator RegistrarTiempo()
    {
        var segundos1 = (Horas[1] - Horas[0]).TotalSeconds;
        var segundos2 = (Horas[4] - Horas[2]).TotalSeconds/2;
        var segundos3 = (Horas[5] - Horas[4]).TotalSeconds;
        //Se crea una forma con los datos que el usuario haya ingresados
        WWWForm forma = new WWWForm();

        forma.AddField("usuario", value: nombre);
        forma.AddField("contra", value: contra);
        forma.AddField("datos1", value: segundos1.ToString());
        forma.AddField("datos2", value: segundos2.ToString());
        forma.AddField("datos3", value: segundos3.ToString());
        //Se hace un post al server con los datos para que conecte con la base de datos
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.165.183:8080/postActualizarJugador", forma);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            print("a");
        }
        else
        {
            print("Error en la descarga: ");
        }
    }


    

    //Cuando se choca con un circle collider, se cambia de escena
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verifica que solo logicman pueda cambiar de escena
        if (collision.collider.name == "logicmanSprite" | collision.gameObject.CompareTag("Player"))
        {
            entrando = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Revisar que sea el jugador
        if (other.gameObject.CompareTag("Player"))
        {
           
            entrando = true;
        }
    }
    // Update is called once per frame
    void Update()
    {   
        //Cambia de escena si las condiciones son correctas
        if (entrando)
        {
                      
            Scene escenaActual = SceneManager.GetActiveScene();
            print(escenaActual.name);
            if (escenaActual.name == "miniGame 2")
            {
                print(escenaActual.name);
                RegistrarTiempoRutina();
            }
            cambiar(nombreScrene, nivel);
        }
    }




    

}