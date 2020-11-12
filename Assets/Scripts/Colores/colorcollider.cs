using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorcollider : MonoBehaviour
{

    public GameObject _color;

    [SerializeField] private string colorname;
    // Start is called before the first frame update
    void Update()
    {
        setname();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("color"))
        {
            colorname = collision.gameObject.name;

            collision.gameObject.SetActive(false);
        }
    }


    public void setname()
    {

        _color.name = colorname;

        //Debug.Log(_color.name);
    }

}
