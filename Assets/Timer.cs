using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent OnTick;
    public int seconds;

    void Start()
    {
        InvokeRepeating("MakeTick", 0, seconds);
    }

    private void MakeTick()
    {
        if (OnTick != null)
        {
            OnTick.Invoke();
        }
    }
}
