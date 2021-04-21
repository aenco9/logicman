using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverCamara : MonoBehaviour
{
    // Start is called before the first frame update
    public float xSize;
    public float ySize;

    public GameObject spriteLogicman;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(spriteLogicman.transform.position.x, 0, xSize);
        float y = Mathf.Clamp(spriteLogicman.transform.position.y, 0, ySize);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
