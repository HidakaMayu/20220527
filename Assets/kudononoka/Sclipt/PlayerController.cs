using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float Speed; //移動速度
    private float jumpForce = 1100f; //ジャンプ力
    private int jumpCount = 0;　
    [SerializeField] Text HP;
    [SerializeField] int m_hp = 5;

    int _curentHp;
 

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _curentHp = m_hp;
        HP.text = $"HP:{_curentHp}";　//最初のHPを表示

    }

    // Update is called once per frame
    void Update()
    {
        //横移動
        Debug.Log(_rb.velocity.magnitude);
        float x = Input.GetAxisRaw("Horizontal"); 
        if( _rb.velocity.magnitude < 10)
        {
            _rb.AddForce(Vector2.right * x * Speed);
        }

        //ジャンプ移動　１回ジャンプしたらジャンプできない
        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 1)  
        {
            _rb.AddForce(Vector2.up * jumpForce);
            jumpCount++;
        }
    }
    
     void OnCollisionEnter2D(Collision2D other)　
     {
        if(other.gameObject.CompareTag("Floor"))　　//床に触れているときジャンプができる
        {
            jumpCount = 0;
        }
     }

    public void Damage(int damage) 　　//雨に当たった時ダメージを受ける
    {
        _curentHp -= damage;
        HP.text = $"HP:{_curentHp}";   //減ったHPを表示
        if (_curentHp <= 0) 　　//HPが0になった時メソッドを呼び出す
        {
            ChangeSecene();  
        }
    }

     void ChangeSecene()  //シーンの遷移
     {
         SceneManager.LoadScene(/*シーン名*/);
     }
}
