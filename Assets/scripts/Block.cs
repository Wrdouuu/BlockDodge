using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed = 2f;
    
    public void blockMove()
    {
        transform.position += new Vector3(0f, -1f, 0f) * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <-6f)
        {
            transform.position = new Vector3(Random.Range(-2.35f, 2.35f), 5.8f, 0);
            GameManager.instance.score ++;           
            
        }
        GameManager.instance.OnScore();
        blockMove();
    }
}
