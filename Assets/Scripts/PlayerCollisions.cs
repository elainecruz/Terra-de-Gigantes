using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
      void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("grow"))
        {
            GetComponent<ShrinkOrGrow>().grow();
        }
        if (col.gameObject.CompareTag("shrink"))
        {
            GetComponent<ShrinkOrGrow>().shrink();
        }
        if (col.gameObject.CompareTag("normal_size"))
        {
            GetComponent<ShrinkOrGrow>().originalSize();
        }
    }
}
