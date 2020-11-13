using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DirtManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]private GameObject dirtSprite;
    [SerializeField]private Image currentDirtSprite;
    [SerializeField]private Vector3 mousePosTemp = Vector3.zero;
    [SerializeField]private float lastMouseMoveTime = 0;
    public bool hasDirt;
    private float quantityOfDirt = 1;
    private bool pressed = false;
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
        if(pressed && Input.GetMouseButton(0) && hasDirt && Input.mousePosition!=mousePosTemp)
        {
            if(lastMouseMoveTime>100){
                lastMouseMoveTime = 0;
                mousePosTemp=Input.mousePosition;
            }
            lastMouseMoveTime++;
            quantityOfDirt-=0.001f;

            Color temp = currentDirtSprite.color;
            temp.a=quantityOfDirt;
            currentDirtSprite.color = temp;
        }
                
        if(quantityOfDirt<=0)
        {
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
