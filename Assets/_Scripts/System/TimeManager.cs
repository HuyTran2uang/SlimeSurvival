using UnityEngine;

public class TimeManager : MonoBehaviourSingleton<TimeManager>
{
    [field: SerializeField] public int Second { get; private set; }
    [field: SerializeField] public int Minute { get; private set; }
    [field: SerializeField] public int Hour { get; private set; }
    private float _timer;

    private void SetTimer()
    {
        if (_timer > 0) _timer -= Time.deltaTime;
    }

    private void SetSecond()
    {
        if (_timer > 0) return;
        _timer = 1;
        Second++;
    }

    private void SetMinute()
    {
        if (Second < 60) return;
        Minute++;
        Second = 0;
    }

    private void SetHour()
    {
        if (Minute < 60) return;
        Hour++;
        Minute = 0;
    }

    public void Timer(ref float time)
    {
        if (time > 0) time -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        SetTimer();
        SetSecond();
        SetMinute();
        SetHour();
    }
}
