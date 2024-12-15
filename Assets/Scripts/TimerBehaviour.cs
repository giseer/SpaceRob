using UnityEngine;
using UnityEngine.Events;

public class TimerBehaviour : MonoBehaviour
{
    public float initialTime;
    public bool countDown;
    public UnityEvent<float> OnTime;
    public UnityEvent OnTimeOut;
    private bool isStopped;

    [HideInInspector] public float time;
    
    private void Start()
    {
        RestartTime();
    }
    
    private void Update()
    {
        if (!isStopped)
        {
            if (countDown)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                    OnTimeOut.Invoke();
            }
            else
            {
                time += Time.deltaTime;
            }
        }

        OnTime.Invoke(time);
    }

    public void RestartTime()
    {
        time = initialTime;
        OnTime.Invoke(time);
        isStopped = false;
    }

    public void StopTime()
    {
        isStopped = true;
    }
}