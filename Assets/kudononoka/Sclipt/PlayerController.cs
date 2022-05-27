using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float Speed;
    [SerializeField] float JumpSpeed;
    private float jumpForce = 1100f;
    private int jumpCount = 0;




    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_rb.velocity.magnitude);
        float x = Input.GetAxisRaw("Horizontal"); //‰¡ˆÚ“®
        if( _rb.velocity.magnitude < 10)
        {
            _rb.AddForce(Vector2.right * x * Speed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 1)  //ƒWƒƒƒ“ƒvˆÚ“®
        {
            _rb.AddForce(Vector2.up * jumpForce);
            jumpCount++;
        }
    }
    
     void OnCollisionEnter2D(Collision2D other)
     {
        if(other.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
     }

}
