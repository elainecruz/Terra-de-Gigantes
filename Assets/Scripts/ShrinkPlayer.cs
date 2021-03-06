﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPlayer : MonoBehaviour
{
    public Vector3 downSize;
    public Vector3 regularSize;
    public Vector3 bigSize;

    public bool finishShrink= false;
    public bool finishGrow = false;


    void Start(){
        regularSize = transform.localScale;
    }

    void OnCollisionEnter2D (Collision2D col){
        if (col.collider.tag == "shrink"){
            StartCoroutine("Shrink");
        }

        if (col.collider.tag == "grow"){
            Destroy(col.gameObject);  
            StartCoroutine("Grow");
        }

    }
    
    IEnumerator Shrink(){

        while(!finishShrink){
            transform.localScale = new Vector3(transform.localScale.x-5, transform.localScale.y-5,1);

            if(transform.localScale.x <= downSize.x){
                finishShrink = true;
            }

            yield return new WaitForSeconds(1.5f);
        }

    }

    IEnumerator Grow(){

        while(!finishGrow){
            transform.localScale = new Vector3(transform.localScale.x+5, transform.localScale.y+5,1);

            if(transform.localScale.x >= bigSize.x){
                finishGrow = true;
            }

            yield return new WaitForSeconds(0.5f);
        }

    }
}
