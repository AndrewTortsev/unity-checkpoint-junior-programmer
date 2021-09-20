using System;
using UnityEngine;
using RunnerApi;

public class BlinkImpl : MonoBehaviour, Blink
{
    public float blinkPeriod = 0.5f;
    private delegate void BlinkMethod();
    private BlinkMethod blinkTask;

    private void InvertActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void BeginBlink(float period)
    {
        if (IsBlinked())
        {
            StopBlink();
        }
        InvokeRepeating(blinkTask.Method.Name, 0f, period);
    }

    public void StopBlink()
    {
        CancelInvoke(blinkTask.Method.Name);
    }

    // Start is called before the first frame update
    void Start()
    {
        blinkTask = InvertActive;
        BeginBlink(blinkPeriod);
    }

    void Update()
    {
    }

    public bool IsBlinked()
    {
        return IsInvoking(blinkTask.Method.Name);
    }
}
