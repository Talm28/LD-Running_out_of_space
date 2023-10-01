using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : StrongAstroidMovement
{
    GameObject spaceShip;
    [SerializeField] GameObject[] hands;
    int hand;

    void Start() 
    {
        hand = 0;
        spaceShip = GameObject.FindGameObjectWithTag("Spaceship");
    }

    void Update()
    {  
        AstroidMove();
        AstroidRotation();
        DirectionUpdate();

        if(Vector3.Distance(transform.position, Vector3.zero) > 10)
            Destroy(this.gameObject);
    }

    void DirectionUpdate()
    {
        if(spaceShip != null)
        {
            moveDir = spaceShip.transform.position - transform.position;
            moveDir = moveDir / moveDir.magnitude;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            lives -=1;
            textureIndex += 1;
            TakeLife();
            if(lives ==0)
            {
                GameManager.instance.AstroidKill(shrinkAmout, score);
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    public void TakeLife()
    {
        if(hand > 3 || hands.Length == 0)
            return;
        Destroy(hands[hand]);
        hand += 1;
    }
}
