using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float Speed; //�ړ����x
    private float jumpForce = 1100f; //�W�����v��
    private int jumpCount = 0;�@
    [SerializeField] Text HP;
    [SerializeField] int m_hp = 5;

    int _curentHp;
 

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _curentHp = m_hp;
        HP.text = $"HP:{_curentHp}";�@//�ŏ���HP��\��

    }

    // Update is called once per frame
    void Update()
    {
        //���ړ�
        Debug.Log(_rb.velocity.magnitude);
        float x = Input.GetAxisRaw("Horizontal"); 
        if( _rb.velocity.magnitude < 10)
        {
            _rb.AddForce(Vector2.right * x * Speed);
        }

        //�W�����v�ړ��@�P��W�����v������W�����v�ł��Ȃ�
        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 1)  
        {
            _rb.AddForce(Vector2.up * jumpForce);
            jumpCount++;
        }
    }
    
     void OnCollisionEnter2D(Collision2D other)�@
     {
        if(other.gameObject.CompareTag("Floor"))�@�@//���ɐG��Ă���Ƃ��W�����v���ł���
        {
            jumpCount = 0;
        }
     }

    public void Damage(int damage) �@�@//�J�ɓ����������_���[�W���󂯂�
    {
        _curentHp -= damage;
        HP.text = $"HP:{_curentHp}";   //������HP��\��
        if (_curentHp <= 0) �@�@//HP��0�ɂȂ��������\�b�h���Ăяo��
        {
            ChangeSecene();  
        }
    }

     void ChangeSecene()  //�V�[���̑J��
     {
         SceneManager.LoadScene(/*�V�[����*/);
     }
}
