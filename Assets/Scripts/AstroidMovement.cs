using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{  
    [SerializeField] protected Sprite[] textures;
    protected SpriteRenderer spriteRenderer;
    protected int textureIndex;

    [SerializeField] float maxMoveSpeed;
    [SerializeField] float minMoveSpeed;
    private float moveSpeed;

    protected Vector3 moveDir;
    private Vector3 minDir;
    private Vector3 maxDir;

    [SerializeField] float maxRotateSpeed;
    [SerializeField] float minRotateSpeed;
    private float rotateSpeed;
    private int rotateDirection;

    Transform upLeftMarker;
    Transform upRightMarker;
    Transform downRightMarker;

    [SerializeField] protected int score;
    [SerializeField] protected float shrinkAmout;

    [SerializeField] protected GameObject destroyEffect;
    
    void Awake() 
    {
        // Initialize screen markers
        GameManager gameManager = GameManager.instance;
        upLeftMarker = gameManager.GetUpLeftMarker();
        upRightMarker = gameManager.GetUpRightMarker();
        downRightMarker = gameManager.GetDownRightMarker();

        spriteRenderer = GetComponent<SpriteRenderer>();

        SpawnAstroid();
    }

    // Update is called once per frame
    void Update()
    {  
        AstroidMove();
        AstroidRotation();

        spriteRenderer.sprite = textures[textureIndex];
        
        if(Vector3.Distance(transform.position, Vector3.zero) > 10)
            Destroy(this.gameObject);
    }

    void SpawnAstroid()
    {
        // Initialize Random obj + random bool
        System.Random random = new System.Random();
        bool isHorizonatl = random.Next(2) == 1;

        // Textures type choose
        textureIndex = random.Next(2) * 3; // (0 or 3)
        spriteRenderer.sprite = textures[textureIndex];

        float borderSize = upRightMarker.position.x + 0.5f;
        // Spawn astroid on horizontal axis
        if(isHorizonatl)
        {
            // Chhose Random location
            int factor = Random.Range(0,2) * 2 - 1;
            float randomX = borderSize * factor;
            float randomY = Random.Range(-borderSize, borderSize);
            transform.position = new Vector2(randomX,randomY);

            // Initialize direction borders
            minDir = new Vector3(0, borderSize, 0) - transform.position;
            maxDir = new Vector3(0, -borderSize, 0) - transform.position;
        }
        else // Spawn astroid on vertical axis
        {
            // Chhose Random location
            int factor = Random.Range(0,2) * 2 - 1;
            float randomX = Random.Range(-borderSize, borderSize);
            float randomY = borderSize * factor;
            transform.position = new Vector2(randomX,randomY);

            // Initialize direction borders
            minDir = new Vector3(borderSize, 0, 0) - transform.position;
            maxDir = new Vector3(-borderSize, 0, 0) - transform.position;
        }
        moveDir = Vector3.Lerp(minDir, maxDir, Random.Range(0f,1f));
        moveDir = moveDir / moveDir.magnitude;

        moveSpeed = Random.Range(minMoveSpeed,maxMoveSpeed);

        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
        rotateDirection = Random.Range(0,2) * 2 - 1;
    }

    protected void AstroidMove()
    {
        transform.position += moveSpeed * moveDir * Time.deltaTime;
    }

    protected void AstroidRotation()
    {
        float rotateAmount = rotateSpeed * rotateDirection * Time.deltaTime;
        transform.Rotate(0,0,-rotateAmount);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            GameManager.instance.AstroidKill(shrinkAmout, score);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
