using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palomino : MonoBehaviour
{
    public float speed = 5.0f;
    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical";
    private bool walking = false;
  
    private Animator _animator;
    private Rigidbody2D _Playerrigibody;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _Playerrigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {

            //Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H) * speed *Time.deltaTime,0,0);
            // this.transform.Translate(translation);

            _Playerrigibody.velocity = new Vector2(Input.GetAxisRaw(AXIS_H) * this.speed, _Playerrigibody.velocity.y);
            walking = true;
           
        }
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {

            //Vector3 translation = new Vector3(0,Input.GetAxisRaw(AXIS_V) * speed * Time.deltaTime, 0);  
            //this.transform.Translate(translation);
            _Playerrigibody.velocity = new Vector2(_Playerrigibody.velocity.x, Input.GetAxisRaw(AXIS_V) * this.speed);
            walking = true;
       
        }
    }

    private void LateUpdate()
    {
        if (!walking)
        {
            _Playerrigibody.velocity = Vector2.zero;

        }
        _animator.SetFloat("Horizontal", Input.GetAxisRaw(AXIS_H));
        _animator.SetFloat("Vertical", Input.GetAxisRaw(AXIS_V));
        _animator.SetBool("Walking", walking);
        
    }
}
