using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colormanager : IntEventInvoker
{
    private int SelectedcolorIndex;
    public GameObject color1;
    public GameObject color2;
    private string colortocompare;
    public GameObject estatua;
  
    [Header("List of second colors")]
    [SerializeField] private List<color_tobe> color_color = new List<color_tobe>();
    public Image colorimaTobe;

    private GameWonEvent gameWonEvent;

    // Start is called before the first frame update
    void Start()
    {

        gameWonEvent = new GameWonEvent();
        unityEvents.Add(EventName.GameWonEvent, gameWonEvent);
        EventManager.AddInvoker(EventName.GameWonEvent, this);
        ramdonColorToBe();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void mezclar_colores()
    {
        if(color1.name == "azul" && color2.name == "amarillo" || color1.name == "amarillo" && color2.name == "azul")
        {
          

            colortocompare = "verde";
            estatua.GetComponent<Renderer>().material.color = new Color32(46, 204, 113,255);

        }
        if (color1.name == "amarillo" && color2.name == "rojo" || color1.name == "rojo" && color2.name == "amarillo")
        {
          
            colortocompare = "naranja";
            estatua.GetComponent<Renderer>().material.color = new Color32(230, 126, 34, 255);
        }
        if (color1.name == "azul" && color2.name == "rojo" || color1.name == "rojo" && color2.name == "azul")
        {
            estatua.GetComponent<Renderer>().material.color = new Color32(165, 105, 189, 255);
            colortocompare = "violeta";
        }
        compararcolorer();
    }

    public void compararcolorer()
    {

        if (color_color[SelectedcolorIndex].colorName == colortocompare )
        {
            gameWonEvent.Invoke(0);
            //Debug.Log("exacto");

           
        }
        if(color_color[SelectedcolorIndex].colorName != colortocompare)
        {

            //Debug.Log("error");


        }
    }
    public void ramdonColorToBe()
    {

        SelectedcolorIndex = Random.Range(0, color_color.Count);
        colorimaTobe.sprite = color_color[SelectedcolorIndex].image;

        //Debug.Log("color" + color_color[ SelectedcolorIndex].colorName);

    }

  


    [System.Serializable]
    public class color_tobe
    {

        public Sprite image;
        public string colorName;

    }


}
