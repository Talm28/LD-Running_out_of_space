using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveAmount =  moveSpeed * Time.deltaTime;
        transform.Translate(0,moveAmount,0);

    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Border" || other.tag == "Astroid")
        {
            Destroy(this.gameObject);
        }
    }
}
