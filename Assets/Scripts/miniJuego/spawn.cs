using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject collider;

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            collider.GetComponent<BoxCollider2D>().enabled = true;
       }
    }
}
