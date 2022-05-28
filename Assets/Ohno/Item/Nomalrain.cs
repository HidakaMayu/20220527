using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomalrain : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    PlayerController playerController;


    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.Damage(1);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Floor")
        {

            Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(_enemy, position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
