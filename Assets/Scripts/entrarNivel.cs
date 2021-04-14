using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class entrarNivel : MonoBehaviour
{
    public bool entrando = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        entrando = true;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entrando)
        {
            SceneManager.LoadScene(sceneName: "miniGame");
        }
    }
}
