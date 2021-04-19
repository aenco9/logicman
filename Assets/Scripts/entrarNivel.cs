using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class entrarNivel : MonoBehaviour
{
    public bool entrando = false;
    public string nombreScrene;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "logicmanSprite")
        {
            entrando = true;
        }
            

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
            SceneManager.LoadScene(sceneName: nombreScrene);
        }
    }
}
