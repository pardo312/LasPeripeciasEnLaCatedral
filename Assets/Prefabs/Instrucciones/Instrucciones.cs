using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instrucciones : MonoBehaviour
{
    [SerializeField]private GameObject[] instruccionesPages;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(0.1f));
    }
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject a = GameObject.Find("Restorer");
        if (a)
        {
            a.GetComponent<StairClimber>().canMove = false;
        }
        GameObject b = GameObject.Find("BackgroundChanger");
        if (b)
        {
            b.GetComponent<LapseTimer>().isRunning = false;
        }

        for(int i=0;i<instruccionesPages.Length;i++){

            GameObject page = Instantiate(instruccionesPages[i],this.transform);
            if(i!=0){
                page.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { 
                    page.SetActive(false);
                });
            }
            else{
                page.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { 
                    this.gameObject.SetActive(false);
                    GameObject c = GameObject.Find("Restorer");
                    if (c)
                    {
                        c.GetComponent<StairClimber>().canMove = true;
                    }
                    GameObject d = GameObject.Find("Restorer");
                    if (d)
                    {
                        GameObject.Find("BackgroundChanger").GetComponent<LapseTimer>().isRunning = true;
                    }
                   
                });
            }
        }
    }

}
