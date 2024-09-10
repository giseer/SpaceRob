using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float rotationSpeed;
    private NewControls nc;    
    private MovementBehaviour mvb;

    private void OnEnable()
    {
        Vector3 postrans = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        postrans.z = 0;
        transform.position = postrans;
        
        PauseManager.Instance.ResumedGame.AddListener(LoadSavedValues);
    }

    public void Start()
    {
        rotationSpeed = 1f;
        nc = GetComponent<NewControls>();
        mvb = GetComponent<MovementBehaviour>();
        LoadSavedValues();
    }

    private void LoadSavedValues()
    {
        if (PlayerPrefs.HasKey("rotationSpeed"))
        {
            rotationSpeed = PlayerPrefs.GetFloat("rotationSpeed");   
        }
        else
        {
            PlayerPrefs.SetFloat("rotationSpeed", rotationSpeed);
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, nc.moveValue.x * -rotationSpeed);
        mvb.Move(nc.moveValue.y * transform.up);
    }

    private void OnDisable()
    {
        PauseManager.Instance.ResumedGame.RemoveListener(LoadSavedValues);
    }
}
