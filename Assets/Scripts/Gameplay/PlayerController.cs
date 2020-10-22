using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TolsaMove(false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TolsaMove(true);
        }
    }

    private void TolsaMove(bool girarIzqDer)
    {
        if ((!girarIzqDer ? spriteRender.flipX : !spriteRender.flipX))
        { //para que el personaje gire al otro lado
            spriteRender.flipX = girarIzqDer;
        }
        transform.Translate(!girarIzqDer ? speed : -speed, 0, 0);
        //aqui se llamara al triger de la animacion
    }
}
