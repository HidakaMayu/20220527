using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float Speed; //移動速度
    [SerializeField] float jumpForce = 30f; //ジャンプ力
    bool jumpCount = false;
    [SerializeField] Text HP;
    [SerializeField] int m_hp = 5;

    int _curentHp;

    Animator anim;

    [SerializeField] AudioClip a;
    AudioSource audioSource;

    float y = -5;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        _curentHp = m_hp;
        HP.text = $"HP:{_curentHp}";　//最初のHPを表示
        anim = GetComponent<Animator>();
        ondes.allScore = 0;
        GameManager.score = 0;
        GameManager._timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        if (jumpCount)
        {
            //横移動
            if (_rb.velocity.magnitude < 4)
            {
                _rb.AddForce(Vector2.right * x * Speed);
            }
        }
        else
        {
            _rb.velocity = new Vector2(x * 3, _rb.velocity.y);
        }


        if (x != 0)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }

        if (x < 0)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (x > 0)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (!jumpCount)
        {
            anim.SetBool("JumpUp", true);
            if (y > transform.position.y)
            {
                anim.SetBool("JumpDown", true);
            }
            y = transform.position.y;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpCount)
            {
                jumpCount = false;
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Floor"))　　//床に触れているときジャンプができる
    //    {
    //        jumpCount = true;
    //    }
    //    anim.SetBool("JumpUp", false);
    //    anim.SetBool("JumpDown", false);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!jumpCount)
        {
            audioSource.PlayOneShot(a);
        }
        if (collision.gameObject.CompareTag("Floor"))　　//床に触れているときジャンプができる
        {
            jumpCount = true;
        }
        else if(collision.gameObject.CompareTag("DethObj"))
        {
            Destroy(this.gameObject);
        }

        anim.SetBool("JumpUp", false);
        anim.SetBool("JumpDown", false);


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