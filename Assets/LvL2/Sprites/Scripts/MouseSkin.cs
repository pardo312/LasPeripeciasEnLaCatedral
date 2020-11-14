using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MouseSkin : MonoBehaviour
{
    private Canvas myCanvas;
 
    // Use this for initialization
    void Start () {
        myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
   
    // Update is called once per frame
    void Update () {
        CanvasScaler scaler = GetComponentInParent<CanvasScaler>();
        GetComponent<RectTransform>().anchoredPosition = new Vector2((Input.mousePosition.x * scaler.referenceResolution.x / Screen.width)-960, (Input.mousePosition.y * scaler.referenceResolution.y / Screen.height)-550);
    }
}
