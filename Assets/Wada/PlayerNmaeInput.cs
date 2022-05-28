using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNmaeInput : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text text;

    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        text = text.GetComponent<Text>();
        //inputField.onEndEdit.AddListener(s => Debug.Log(s));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputUpdate()
    {
        text.text = inputField.text;
    }
}
