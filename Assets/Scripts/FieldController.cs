using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class FieldController : MonoBehaviour
{
    public GameController gCont;
  public GameObject[,] fill ; 
  
    // Start is called before the first frame update
    void Start()
    {
        fill = new GameObject[25, 10];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GroundEnd()
    {
        CheckLines();
        
    }
    public void AddQube(GameObject qube)
    {
        int y = (int)Mathf.Round(qube.transform.position.y);
        int x = (int)Mathf.Round(qube.transform.position.x);
        
        if(fill[y,x]!=null)
        {
            fill[y,x].GetComponent<CubeController>().CubeDestroy();
            fill[y,x] = null;
        }

        fill[y, x] = qube;
        Debug.Log("(" + y + ";" + x + ")");
    }
    public void CheckLines()
    {
        int[] lines = new int[] { 21, 21, 21, 21 };
        int f = 0;
         for (int i =0;i<20;i++)
        {
           for (int j = 0;j<10; j++)
            {
                if (fill[i, j] == null)
                    break;
                if (j == 9)
                {
                   
                    lines[f] = i;
                    f++;
                }
            }

        }
        gCont.AddScore(10 * f * f);
       StartCoroutine( RemoveLine(lines));
        
}
    public void RemoveLine(int i)
    {
        for (int j = 0; j < 10; j++)
        {
            
            {
                fill[i,  j].GetComponent<CubeController>().CubeDestroy();
                fill[i,  j] = null;

                
            }
            
        }
    }
   
    public void RefillLines(int[] lines)
    {

        int fall ;
        for (int i = 0; i < 20; i++)
        {
            bool contFlag = false;
            fall = 0;
            for (int f = 0; f < 4; f++)
            {
                if (lines[f] < i)
                    fall++;
                if (lines[f] == i)
                    contFlag = true;
            }
            if (contFlag)
                continue;
            if (fall!=0)
            {
               
                for (int j = 0; j < 10; j++)
            {
                    
                    if (fill[i, j] != null)
                    {
                        fill[i, j].transform.position += new Vector3(0, -fall, 0);
                        AddQube(fill[i, j]);
                        fill[i, j] = null;
                    }
            } 
            }

            
        }
        FindObjectOfType<SpawnController>().SpawnFigure();
    }
     IEnumerator  RemoveLine(int[] lines)
    {
        for (int j = 0; j < 5; j++)
        {
            foreach (int i in lines)
            {
                if (i<21)
                {
                fill[i, 4 - j].GetComponent<CubeController>().CubeDestroy();
                fill[i, 4 - j] = null;

                fill[i, 5 + j].GetComponent<CubeController>().CubeDestroy();
                fill[i, 5 + j] = null; 
                }
                
            }
            yield return new WaitForSeconds(0.05f);
        }
        RefillLines(lines);
    }
}
