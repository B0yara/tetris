using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public bool canSpawn;
    public GameObject[] figure = new GameObject[7];
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnFigure()
    {
        if (canSpawn)
        {
            Instantiate(figure[i]);
            PrepareFigure();
        }
    }
    public void PrepareFigure()
    {
        i = Random.Range(0, 6);
        FindObjectOfType<WillNext>().DisplayNext(i);
    }
}
