using UnityEngine;

public class OvniSpawner : MonoBehaviour
{
    public GameObject OvniPrefab;
    public float delay;
    public bool active;

    private int numSpawner;
    private OvniBehaviour ovr;

    private float time;

    // Start is called before the first frame update
    private void Start()
    {
        time = 0;
        active = true;
        ovr = GameObject.Find("OvniSpawnerManager").GetComponent<OvniBehaviour>();
    }

    // Update is called once per frame
    private void Update()
    {
        numSpawner = ovr.numSpawner;
        if (numSpawner == 1)
        {
            if (active)
            {
                Vector3 dir;
                time += Time.deltaTime;
                if (time > delay)
                {
                    var ovni = Instantiate(OvniPrefab, transform.position, Quaternion.identity);
                    Destroy(ovni, 6f);
                    dir = new Vector3(1.0f, 0, 0);
                    ovni.GetComponent<Ovni>().SetDirection(dir);
                    time = 0;
                }
            }
        }
        else if (numSpawner == 2)
        {
            if (active)
            {
                Vector3 dir;
                time += Time.deltaTime;
                if (time > delay)
                {
                    var ovni = Instantiate(OvniPrefab, transform.position, Quaternion.identity);
                    Destroy(ovni, 6f);
                    dir = new Vector3(-1.0f, 0, 0);
                    ovni.GetComponent<Ovni>().SetDirection(dir);
                    time = 0;
                }
            }
        }
    }

    public void StopSpawner()
    {
        active = false;
    }

    public void StartSpawner()
    {
        active = true;
    }
}