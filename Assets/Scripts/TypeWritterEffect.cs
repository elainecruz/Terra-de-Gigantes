using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;



public class TypeWritterEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    private Text componente;
    private bool stopEffect = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void startAnimation(){
         fullText = Regex.Replace(fullText, ";", "\n");
         componente = this.GetComponent<Text>();
         StartCoroutine(ShowText());
    }
   IEnumerator ShowText(){
       for (int i=0; i< fullText.Length; i++){
            if(stopEffect){
                //i = fullText.Length;
                break;
            }
           currentText = fullText.Substring(0,i);
           componente.text = currentText;
           yield return new WaitForSeconds(delay);
       }
   }

    void Update(){
         if (Input.GetMouseButtonDown(0)){
            componente.text = fullText;
            stopEffect = true;
         }
    }
}
