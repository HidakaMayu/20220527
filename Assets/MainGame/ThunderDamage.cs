using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderDamage : MonoBehaviour
{
    PlayerController playerController;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        ArrowsPrefab.Sound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log(1);
            playerController.Damage(1);
        }
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
