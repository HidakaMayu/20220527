using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSclipt : MonoBehaviour
{

    GameObject player;
    [SerializeField] GameObject blood;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSecene();

        if(!player)
        {
            blood.SetActive(true);
        }
    }

    void ChangeSecene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainGameScene");
            
        }
    }
}
