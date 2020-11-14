using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DirtManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]private GameObject dirtSprite;
    [SerializeField]private GameObject smoke;
    private Image currentDirtSprite;
    private Vector3 mousePosTemp = Vector3.zero;
    private float lastMouseMoveTime = 101;
    [HideInInspector]public bool hasDirt;
    private float quantityOfDirt = 1;
    private bool pressed = false;
    private GameObject smokeObject;
    // Start is called before the first frame update
    void Start()
    {
        if(hasDirt){
            currentDirtSprite= Instantiate(dirtSprite,this.transform).GetComponent<Image>();
            
            Color temp = GetComponent<Image>().color;
            temp.a=0.5f;
            GetComponent<Image>().color = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {        
        if(pressed && hasDirt && Input.mousePosition!=mousePosTemp)
        {
            if(Input.GetMouseButton(0)){
                if(lastMouseMoveTime>100){
                    Destroy(smokeObject);
                    smokeObject= Instantiate(smoke,this.transform);
                    smokeObject.transform.localScale = new Vector3(0.7f, 0.7f,1);
                    lastMouseMoveTime = 0;
                    mousePosTemp=Input.mousePosition;
                }
                else
                {
                    smokeObject.transform.localScale +=new Vector3(0.001f, 0.001f,0);
                    lastMouseMoveTime++;
                    quantityOfDirt-= Time.deltaTime;

                    Color temp = currentDirtSprite.color;
                    temp.a=quantityOfDirt;
                    currentDirtSprite.color = temp;
                }
            }
            else{
                lastMouseMoveTime = 101;
                Destroy(smokeObject);
            }
        }
        
                
        if(quantityOfDirt<=0)
        {
            Destroy(smokeObject);
            Color temp = GetComponent<Image>().color;
            temp.a=1f;
            GetComponent<Image>().color = temp;

            quantityOfDirt=1;
            hasDirt=false;
            GameObject.Destroy(currentDirtSprite.gameObject);
        }
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        pressed=true;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        pressed=false;
    }
}
