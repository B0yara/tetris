using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillNext : MonoBehaviour
{
   public GameObject[] child;
    GameObject next;
    // Start is called before the first frame update
    public void DisplayNext(int figure)
    {
        if (next != null)
        {
            next.GetComponent<Dubler>().SelfDestroy();
        }
        next = Instantiate(child[figure], transform.position,Quaternion.identity);
    }
}
