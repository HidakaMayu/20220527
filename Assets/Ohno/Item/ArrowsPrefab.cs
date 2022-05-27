using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject ArrowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ArrowPrefab, new Vector2(0.0f, 7.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
