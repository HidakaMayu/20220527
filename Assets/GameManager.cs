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
    bool _phase4 = false;
    bool _phase5 = false;
    bool _phase6 = false;
    bool _phase7 = false;

    public static Action<PhaseType> OnChangeGenerateTime;
    void Start()
    {
        OnChangeGenerateTime?.Invoke(PhaseType.Phase1);
    }

    void Update()
    {
        if (_isStop) { return; }

        _timer += Time.deltaTime;
        //_text.text = $"TIME : {_timer.ToString("f2")}";
        _text.text = _timer.ToString("f1");

        if(_timer >= 30 && !_phase1 )
        {
            OnChangeGenerateTime?.Invoke(PhaseType.Phase2);
            _phase1 = true;

        }
        else if (_timer >= 45 && !_phase2)
        {
            OnChangeGenerateTime?.Invoke(PhaseType.Phase3);
            _phase2 = true;

        }
        else if (_timer >= 60 && !_phase3)
        {
            OnChangeGenerateTime?.Invoke(PhaseType.Phase4);
            _phase3 = true;

        }
        else if (_timer >= 70 && !_phase4)
        {
            OnChangeGenerateTime?.Invoke(PhaseType.Phase5);
            _phase4 = true;
        }
        else if (_timer >= 80 && !_phase5)
        {
            OnChangeGenerateTime?.Invoke(PhaseType.Phase6);
            _phase5 = true;
        }
        else if (_timer >= 90 && !_phase6)
        {
            OnChangeGenerateTime?.Invoke(PhaseType.Phase7);
            _phase6 = true;
        }
        else if (_timer >= 100 && !_phase7)
        {
            OnChangeGenerateTime?.Invoke(PhaseType.Phase8);
            _phase7 = true;
        }



    }

    public void ControlTime()
    {
        _isStop ^= true;
    }


}
