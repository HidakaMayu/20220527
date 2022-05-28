using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    GameObject PlayerObject;
    Vector3 PlayeyPosition;
    Rigidbody rb;
    Vector3 EnemyPosotion;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerObject = GameObject.FindWithTag("Player");
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //x = Input.GetAxis("Horizontal");
        //rd.Addforce =
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        
        if(PlayeyPosition.x > EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x + 0.01f;
        }
        else if(PlayeyPosition.x < EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x - 0.01f;
        }

        transform.position = EnemyPosotion;
    }
}
