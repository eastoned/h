using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCemetary : MonoBehaviour
{

    public List<GameObject> tombs;
    public List<Sprite> deaths;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < deaths.Count; i++)
        {
            GameObject clone = Instantiate(tombs[Random.Range(0, tombs.Count)], new Vector3(Random.Range(-95, 95), 0.25f, Random.Range(5, 198)), Quaternion.Euler(-90, 0, -90));
            clone.GetComponentInChildren<SpriteRenderer>().sprite = deaths[i];
        }
    }

 
}
