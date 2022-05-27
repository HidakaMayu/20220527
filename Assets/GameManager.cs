using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text _text = default;

    float _timer = default;

    bool _isStop = default;
    bool _phase1 = false;
    bool _phase2 = false;
    bool _phase3 = false;

    public static Action<float> OnChangeGenerateTime;
    void Start()
    {

    }

    void Update()
    {
        if (_isStop) { return; }

        _timer += Time.deltaTime;
        //_text.text = $"TIME : {_timer.ToString("f2")}";
        _text.text = _timer.ToString("f1");

        if(_timer >= 30 && !_phase1 )
        {
            OnChangeGenerateTime?.Invoke(2.0f);
            _phase1 = true;

        }
        else if (_timer >= 45 && !_phase2)
        {
            OnChangeGenerateTime?.Invoke(1.5f);
            _phase2 = true;

        }
        else if (_timer >= 60 && !_phase3)
        {
            OnChangeGenerateTime?.Invoke(0.5f);
            _phase3 = true;

        }


    }

    public void ControlTime()
    {
        _isStop ^= true;
    }

}
