using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PhaseType
{
    Phase1,
    Phase2,
    Phase3,
    Phase4,
}

public class ArrowsPrefab : MonoBehaviour
{
    public GameObject ArrowPrefab;

    float time = 0;
    float longtime = 0;
    float overTime = 1;
    public float height;
    //public float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.deltaTime % 2 == 0)
        //{
        //    float x = Random.Range(-8.0f, 8.0f);
        //    Vector3 position = new Vector3(x, height, 0f);
        //    GameObject arrow = Instantiate(ArrowPrefab, position, Quaternion.identity);
        //}

        time += Time.deltaTime;
        longtime += time;
        if(time >= overTime)
        {
            float x = Random.Range(-8.0f, 8.0f);
            Vector3 position = new Vector3(x, height, 0f);
            GameObject arrow = Instantiate(ArrowPrefab, position, Quaternion.identity);
            time = 0;
        }

        if(longtime >= 50)
        {
            if (overTime >= -500)
            {

                //if (overTime <= 0.5)
                //{
                    overTime -= 0.0001f;
                //}
                //if (overTime <= 0.4)
                //{
                //    overTime -= 0.00001f;
                //}
                //if (overTime <= 0.3)
                //{
                //    overTime -= 0.000001f;
                //}
                //if (overTime <= 0.2)
                //{
                //    overTime -= 0.000001f;
                //}
                //if (overTime <= 0.1)
                //{
                //    overTime -= 0.0000001f;
                //}
                Debug.Log(overTime);
            }

            
        }

    }

    void reset()
    {
        overTime = 1;
    }

    void ChangeGenerateTime(PhaseType type)
    {
        switch (type)
        {
            case PhaseType.Phase1:
                overTime = 3;
                break;
            case PhaseType.Phase2:
                overTime = 2;
                break;
            case PhaseType.Phase3:
                overTime = 1;
                break;
            case PhaseType.Phase4:
                overTime = 0;
                break;
            default:
                break;
        }
    }
}
