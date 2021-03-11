using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{


    public int y;
    public int x;

    
    // Start is called before the first frame update
    void Start()
    {
        y = (int)Mathf.Round(transform.position.y);
        x = (int)Mathf.Round(transform.position.x);


    }

    // Update is called once per frame
    void Update()
    {

        y = (int)Mathf.Round(transform.position.y);
        x = (int)Mathf.Round(transform.position.x);




        if (transform.position.x < -0.5)
        { transform.parent.position += Vector3.right; }
        if (transform.position.x > 9.5)
        { transform.parent.position += Vector3.left; }
        if (FindObjectOfType<FieldController>().fill[y, x] != null)
        {
            if (transform.parent != null)
            {
                transform.parent.Rotate(0, 0, -90);
            }
        }


    }
    public void DetachFromParent()
    {
        // Detaches the transform from its parent.
        transform.parent = null;
        FindObjectOfType<FieldController>().AddQube(gameObject);
    }
 

    public void CubeDestroy()
    {
        Destroy(gameObject);
    }
    public bool GroundCheck()
    {
       
        if (y ==0)
        {
            return true;
        }
        else if(FindObjectOfType<FieldController>().fill[y-1, x] != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool StarfeCheck(int direct)
    { 
        if (direct == 0)
        {
            if (x == 0)
            {
                return true;
            }
            else if (FindObjectOfType<FieldController>().fill[y , x-1] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        if (direct == 1)
        {
            if (x==9)
            {
                return true;
            }
            else if (FindObjectOfType<FieldController>().fill[y, x + 1] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}

