using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransitionFade : MonoBehaviour
{
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex +1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(){
       
    }

    IEnumerator LoadScene (int buildIndex){
        yield return new WaitForSeconds (7);

        transition.SetTrigger("Start");
        yield return new WaitForSeconds (1);
    
        SceneManager.LoadScene("Game");  

    }
}
