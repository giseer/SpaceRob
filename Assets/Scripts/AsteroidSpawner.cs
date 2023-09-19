using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject Player;
    public GameObject AsteroidPrefab;
    public float delay;
    public bool active;
    public int NumAsteroides;
    
    private int NumAstAct;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        active = true;
        NumAstAct = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {            
            Vector3 dir;
            time += Time.deltaTime;
            if (time > delay)
            {
                if (NumAstAct < NumAsteroides)
                {
                    GameObject asteroid = Instantiate(AsteroidPrefab, transform.position, Quaternion.identity);
                    Destroy(asteroid, 12f);
                    if (Player != null)
                        dir = Player.transform.position - asteroid.transform.position;
                    else
                    {
                        dir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                    }
                    asteroid.GetComponent<Asteroid>().SetDirection(dir);
                    time = 0;
                    NumAstAct ++;
                }
            }
        }
    }

    public void StopSpawner()
    {
        active = false;
        NumAstAct = 0;
    }

    public void StartSpawner()
    {
        active = true;
    }
}
