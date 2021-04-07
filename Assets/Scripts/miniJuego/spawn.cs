using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            GetComponent<BoxCollider2D>().enabled = true;
       }
    }
}
