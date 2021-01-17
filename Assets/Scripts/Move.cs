using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Move : MonoBehaviour {

    private Rigidbody2D rb;

    private float dirX,dirY,moveSpeed;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
    }
    
    // Update is called once per frame
    void Update () {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        dirY = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
    }


    private void FixedUpdate(){
        rb.velocity = new Vector3(dirX,dirY, 0);
    }   

}