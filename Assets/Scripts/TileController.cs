using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private bool move = false;
    private Collider2D freeTile;
    private Vector2 tileThisPos;    //Coordinates this obj
    private Vector2 tilePos;        //Coordinates free tile
    private index_tiles Game;
    private float duration = 0.06f;

    private void Start()
    {
        Game = GetComponentInParent<index_tiles>();
    }

    private void OnMouseDown()
    {
        //Can you move a tile?
        if(move && !Game.finish)
        {
            tileThisPos = gameObject.transform.position;
            tilePos = freeTile.transform.position;
            MoveObj();
            if (Game != null)
            {
                //Check victory condition
                Game.step++;
                Game.txtNumerator.text = "Step: " + Game.step.ToString();
            }
        }
    }

    private void MoveObj()  //Move tile
    {
        //transform.position = tilePos;
        
        StartCoroutine(Coroutine(tileThisPos, tilePos, duration));
        freeTile.transform.position = tileThisPos;
        //tileThisPos = gameObject.transform.position;
        tilePos = freeTile.transform.position;
    }

    public IEnumerator Coroutine(Vector2 startPos, Vector2 endPos, float duration)
    {
        move = false;
        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / duration;
            transform.position = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }
        transform.position = endPos;
        tileThisPos = gameObject.transform.position;
        move = true;
        if(Game != null) Game.Check();
    }

    //Checking neighboring free tile
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            freeTile = collision;
            move = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            move = false;
        }
    }
}
