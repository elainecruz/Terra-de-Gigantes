using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameobject : MonoBehaviour
{
    public GameObject canva;
  
    void OnCollisionEnter2D (Collision2D col){
     if (col.collider.tag == "Player")
     {
         canva.SetActive(true);
     }
    
    }
}
