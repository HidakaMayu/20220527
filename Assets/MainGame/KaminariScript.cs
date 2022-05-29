using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaminariScript : MonoBehaviour
{
    [SerializeField] GameObject Thunder = default;

    [SerializeField] AudioClip a;
    AudioSource audioSource;

    GameObject player;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(a);
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeThunder()
    {
        Instantiate(Thunder,this.transform.position,Quaternion.identity);
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }

}
