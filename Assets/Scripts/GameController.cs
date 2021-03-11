using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject replica;
    public FieldController fCont;
    public SpawnController sCont; 
    public float fallSpeed = 0.8f;
    public UIController ui;
    public int score;
    void Start()
    {
        score = 0;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int addition)
    {
        score += addition;
        ui.DisplayScore(score);
    }
    public void GameOver()
    {
        
        ui.PushGameOver();
        StartCoroutine(GOAnimation());
    }
    private IEnumerator GOAnimation()
    {
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                
                fCont.AddQube(Instantiate(replica, new Vector3(j, i, 0), Quaternion.identity));
                

                yield return new WaitForSeconds(0.01f);  
            }

        }
        Debug.Log(fCont.fill);
        for (int i = 24; i >= 0; i--)
        {
            fCont.RemoveLine(i);
            

                yield return new WaitForSeconds(0.05f);
            

        }
       
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

    }
  IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        sCont.canSpawn = true;
        sCont.PrepareFigure();
        sCont.SpawnFigure();
    }
}
