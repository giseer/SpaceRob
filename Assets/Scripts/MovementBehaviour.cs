using System;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;

    private void OnEnable()
    {
        PauseManager.Instance.ResumedGame.AddListener(LoadSavedValues);
    }

    private void Start()
    {
        speed = 2f;
        LoadSavedValues();
    }
    
    private void LoadSavedValues()
    {
        if (PlayerPrefs.HasKey("movementSpeed"))
        {
            speed = PlayerPrefs.GetFloat("movementSpeed");   
        }
        else
        {
            PlayerPrefs.SetFloat("movementSpeed", speed);
        }
    }

    public void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnDisable()
    {
        PauseManager.Instance.ResumedGame.RemoveListener(LoadSavedValues);
    }
}