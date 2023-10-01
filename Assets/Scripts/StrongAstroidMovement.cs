using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAstroidMovement : AstroidMovement
{
    [SerializeField] protected int lives;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            lives -=1;
            textureIndex += 1;
            if(lives ==0)
            {
                GameManager.instance.AstroidKill(shrinkAmout, score);
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }



}
