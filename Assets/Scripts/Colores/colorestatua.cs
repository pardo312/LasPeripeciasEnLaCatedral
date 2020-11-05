using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorestatua : MonoBehaviour
{

    private Renderer _renderer;
    public GameObject color1;
    public GameObject color2;
    public GameObject color3;
    public int selectedColor;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();


        coloresEstatua();


    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    public void clean()
    {

        coloresEstatua();

        
        color1.transform.position = new Vector3(3.61f, 3.9f, 0); 
        
      
        color2.transform.position = new Vector3(4.57f, 3.9f, 0); 
        
       
        color3.transform.position = new Vector3(2.71f, 3.9f, 0);
        color1.SetActive(true);
        color2.SetActive(true);
        color3.SetActive(true);
    }

    public void coloresEstatua() {

        selectedColor = Random.Range(0, 2);

        if (selectedColor == 0) {

            _renderer.material.color = Color.black;
        }
        if(selectedColor == 1)
        {

            _renderer.material.color = Color.grey;
        }
        if (selectedColor == 2)
        {

            _renderer.material.color = Color.cyan;
        }
       
    }
   
   
}
