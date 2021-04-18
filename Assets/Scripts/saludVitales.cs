using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saludVitales : MonoBehaviour
{

    public string salud;
    public Text t;
    public GameObject logicman;
    public Transform child;
    // Start is called before the first frame update

    void Start()
    {
        child = transform.Find("Salud");
        t = child.GetComponent<Text>();
        //Debug.Log(logicman.GetComponent<moverPersonake>().salud);
    }

    // Update is called once per frame
    void Update()
    {
        t.text = logicman.GetComponent<moverPersonake>().salud.ToString();
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
