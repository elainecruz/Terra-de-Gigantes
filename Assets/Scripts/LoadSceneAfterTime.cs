using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadScene");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     IEnumerator LoadScene(){
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Game");

     
     }

}
