using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterItems : MonoBehaviour
{
	private GameObject corazon;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {

    }
	
	private void OnTriggerEnter2D(Collider2D collider){
		  //collider.gameObject.tag == "piedra" //si tiene tag
		if (collider.gameObject.name == "piedra") 
        {
			for(int i=1;i<4;i++){
				corazon = GameObject.Find("corazon_" + i);
				if(corazon!=null){
					Debug.Log(corazon.name);
					corazon.SetActive(false);
					break;
				}
					
			}
		}
	}
}
