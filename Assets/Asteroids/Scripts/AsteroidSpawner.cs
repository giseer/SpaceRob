using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[System.Serializable]
public class AsteroidProbability
{
    public GameObject asteroidPrefab;
    
    [Tooltip("All the probabilities have to sum to 100.")]
    [Range(0f, 100f)]
    public float probability;
}

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private List<AsteroidProbability> asteroidsProbabilities = new List<AsteroidProbability>();
    public float delay;
    public bool active;
    public int NumAsteroides;

    private int NumAstAct;

    private float time;

    private void Start()
    {
        time = delay;
        active = true;
        NumAstAct = 0;
    }

    private void Update()
    {
        if (active)
        {
            if (time > delay)
            {
                if (NumAstAct < NumAsteroides)
                {
                    var asteroid = Instantiate(ChooseRandomAsteroid(), transform.position, Quaternion.identity, this.transform);
                    
                    Vector3 dir;
                    if (Player != null)
                        dir = Player.transform.position - asteroid.transform.position;
                    else
                        dir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                            
                    Asteroid asteroidComponent = asteroid.GetComponent<Asteroid>();
                    asteroidComponent.SetDirection(dir);
                    asteroidComponent.OnAsteroidDestroyed.AddListener(OnAsteroidDestroyed);
                        
                    time = 0;
                    NumAstAct++;
                }
            }
            time += Time.deltaTime;
        }
    }

    private GameObject ChooseRandomAsteroid()
    {
        List<GameObject> asteroidsToChoose = new List<GameObject>();
        
        int randomNumber;
        
        do
        {
            randomNumber = Random.Range(0, 100);
        
            foreach (var asteroidProbability in asteroidsProbabilities)
            {
                if (randomNumber < asteroidProbability.probability)
                {
                    asteroidsToChoose.Add(asteroidProbability.asteroidPrefab);
                }
            }    
            
        } while (asteroidsToChoose.Count == 0);

        if (asteroidsToChoose.Count == 1) return asteroidsToChoose[0];
        
        randomNumber = Random.Range(0, asteroidsToChoose.Count);
        return asteroidsToChoose[randomNumber];

    }

    private void OnAsteroidDestroyed(Asteroid asteroid)
    {
        NumAstAct--;
        asteroid.OnAsteroidDestroyed.RemoveListener(OnAsteroidDestroyed);
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