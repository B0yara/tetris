using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour
{   
    
    private float previousTime;
    public float fallTime = 0.8f;
    public bool groundFlag;
    public float fDelay;
    Component[] qubes;
    // Start is called before the first frame update
    void Start()
    {
         qubes = GetComponentsInChildren(typeof(CubeController));
        fallTime = FindObjectOfType<GameController>().fallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
       
       
       
        if(Time.time - previousTime>(Input.GetKey(KeyCode.S)? fallTime/10 : fallTime))
            {
            if (SteepCheck())
            {
                foreach (Component child in qubes)
                {
                    
                    child.GetComponent<CubeController>().DetachFromParent();

                }

                if (transform.position.y > 20)
                {
                    FindObjectOfType<SpawnController>().canSpawn = false;
                    FindObjectOfType<GameController>().GameOver();
                } 
                FindObjectOfType<FieldController>().GroundEnd();
                Destroy(gameObject);
                
            } 
            transform.position += Vector3.down;
            previousTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Rotate(0, 0, 90);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            int i = 0;
            foreach (Component child in qubes)
            {
                if (child.GetComponent<CubeController>().StarfeCheck(0))
                    i++;
            }
            if(i==0)
            transform.position += Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            int i = 0;
            foreach (Component child in qubes)
            {
                if (child.GetComponent<CubeController>().StarfeCheck(1))
                    i++;

            }
            if(i ==0)
            transform.position += Vector3.right;
        }
    

    }
   public bool SteepCheck()
    {
        foreach (Component child in qubes)
        {
            if(child.GetComponent<CubeController>().GroundCheck())
            {
                return true; 
            }
        }
        return false; 
    }
    
        
  
   
}
