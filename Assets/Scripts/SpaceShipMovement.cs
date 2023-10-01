using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem thrust;

    AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        SpaceShipRotation();
        SpaceShipMove();
    }

    void SpaceShipRotation()
    {
        float rotateAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        transform.Rotate(0,0,-rotateAmount);
    }

    void SpaceShipMove()
    {   
        // Particle system
        if(Input.GetKey(KeyCode.UpArrow))
        {
            thrust.enableEmission = true;
        }      
        else
        {
            thrust.enableEmission = false;
        }
        // Sound
        if(Input.GetKeyDown(KeyCode.UpArrow))
            audioSource.Play();
        if(Input.GetKeyUp(KeyCode.UpArrow))
            audioSource.Stop();

        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        if(moveAmount < 0) moveAmount = 0;
        transform.Translate(0,moveAmount,0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Border" || other.gameObject.tag == "Astroid")
        {
            Destroy(this.gameObject);
            GameManager.instance.GameOver();
        }
    }
}

