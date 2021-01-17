using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
      public GameObject player;
      public float cameraHeight = 20.0f;
  
      void Update() {
          Vector3 pos = player.transform.position;
          pos.z += cameraHeight;
          pos.x = transform.position.x;
          transform.position = pos;
      }

    // public Transform target;
    //  public float speed = 1.0f;
     
    //  void LateUpdate () {
    //      Vector3 v3 = transform.position;
    //      v3.y = Mathf.Lerp (v3.y, target.position.y, Time.deltaTime * speed);
    //      transform.position = v3;
    //  }
  }
