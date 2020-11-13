using UnityEngine;
using System.Collections;

public class DirtManager : MonoBehaviour
{
    [SerializeField]private bool hasDirt;
    [SerializeField]private GameObject dirtSprite;
    private int quantityOfDirt = 100;
    // Start is called before the first frame update
    void Start()
    {
        hasDirt = Random.value < 0.5f;
        if(hasDirt){
            Instantiate(dirtSprite,this.transform);
        }
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        Debug.Log(quantityOfDirt);  
        if(Input.GetMouseButtonDown(0)){
            if(hasDirt){
                quantityOfDirt--;
            }
        }
    }
}
