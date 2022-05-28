using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(1);
        if (other.gameObject.CompareTag("Slime"))
        {
            Debug.Log("a");
            Destroy(other.gameObject);
        }

    }
}
