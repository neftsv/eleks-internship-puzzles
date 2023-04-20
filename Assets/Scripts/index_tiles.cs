using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;


public class index_tiles : MonoBehaviour
{
    public Text txt;
    public Text txtNumerator;
    public List<GameObject> tiles = new List<GameObject>();

    private List<Vector2> tilePos = new List<Vector2>();
    private List<Vector2> startPos = new List<Vector2>();
    [HideInInspector] public bool finish;
    [HideInInspector] public int step = 0;

    private void Awake()
    {
        Init();
        finish = false;
    }


    private void Init()
    {
        //Data initialization
        for (int i = 0; i < 15; i++)
        {
            Vector2 temp;
            temp.x = tiles[i].transform.position.x;
            temp.y = tiles[i].transform.position.y;
            tilePos.Add(temp);
            startPos.Add(temp);
        }

        //Move Tiles
        for (int i = 0; i < 15; i++)
        {
            int j = Random.Range(0, tilePos.Count);
            tiles[i].transform.position = tilePos[j];
            tilePos.RemoveAt(j);
        }
    }

    //Checking win
    public void Check()
    {
        bool isTrue = true;
        for (int i = 0; i < 15; i++)
        {
            //If the coordinates NOT match
            if (tiles[i].transform.position.x != startPos[i].x || tiles[i].transform.position.y != startPos[i].y)
            {
                isTrue = false;
                //Debug.Log("Nope");
                break;
            }
        }

        //Congratulations!
        if (isTrue && step > 1)
        {
            finish = true;
            txt.gameObject.SetActive(true);
            //Debug.Log("Congratulations!");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
