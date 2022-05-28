using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float Speed; //移動速度
    private float jumpForce = 2500f; //ジャンプ力
    private int jumpCount = 0;
    [SerializeField] Text HP;
    [SerializeField] int m_hp = 5;

    int _curentHp;

    Animator anim;


    float y = -5;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _curentHp = m_hp;
        HP.text = $"HP:{_curentHp}";　//最初のHPを表示
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //横移動
        float x = Input.GetAxisRaw("Horizontal");
        if (_rb.velocity.magnitude < 3)
        {
            _rb.AddForce(Vector2.right * x * Speed);
        }

        //ジャンプ移動　１回ジャンプしたらジャンプできない
        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 1)
        {
            _rb.AddForce(Vector2.up * jumpForce);
            jumpCount++;
        }

        if(x != 0)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }

        if(x < 0)
        {
            this.transform.eulerAngles = new Vector3(0,180,0);
        }
        else if(x > 0)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(jumpCount >= 1)
        {
            anim.SetBool("JumpUp", true);
            if(y > transform.position.y)
            {
                anim.SetBool("JumpDown", true);
            }
            y = transform.position.y;
        }
        else
        {
            anim.SetBool("JumpUp", false);
            anim.SetBool("JumpDown", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))　　//床に触れているときジャンプができる
        {
            jumpCount = 0;
        }

    }

    public void Damage(int damage) 　　//雨に当たった時のダメージ
    {
        _curentHp -= damage;
        HP.text = $"HP:{_curentHp}";   //減ったHPを表示
        if (_curentHp <= 0) 　　//HPが0になった時メソッドを呼び出す
        {
            ondes.allScore = GameManager.score * (int)GameManager._timer;
            ChangeSecene();
        }
    }

    void ChangeSecene()  //シーンの遷移
    {
        SceneManager.LoadScene("ResultScene");
    }


}