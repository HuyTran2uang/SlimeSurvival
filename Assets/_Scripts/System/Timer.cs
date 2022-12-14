using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviourSingleton<Timer>
{
    [SerializeField] private int _second;
    [SerializeField] private int _minute;
    [SerializeField] private int _hour;
    private float _timer;

    public int Second => _second;
    public int Minute => _minute;
    public int Hour => _hour;

    private void SetTimer()
    {
        if (_timer > 0) _timer -= Time.deltaTime;
    }

    private void SetSecond()
    {
        if (_timer > 0) return;
        _timer = 1;
        _second++;
    }

    private void SetMinute()
    {
        if (_second < 60) return;
        _minute++;
        _second = 0;
    }

    private void SetHour()
    {
        if (_minute < 60) return;
        _hour++;
        _minute = 0;
    }

    private void FixedUpdate()
    {
        SetTimer();
        SetSecond();
        SetMinute();
        SetHour();
    }
}
