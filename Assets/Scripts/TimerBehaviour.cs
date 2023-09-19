using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerBehaviour : MonoBehaviour
{
    private float time;
    private bool isStopped;
    public float initialTime;
    public bool countDown;
    public UnityEvent<float> OnTime;
    public UnityEvent OnTimeOut;
    // Start is called before the first frame update
    void Start()
    {
        RestartTime();
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

    // Update is called once per frame
    void Update()
    {
        if(!isStopped)
        {
            //time += Time.deltaTime;
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
}
