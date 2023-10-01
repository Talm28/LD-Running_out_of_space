using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject astroid;
    [SerializeField] GameObject directAstroid;
    [SerializeField] GameObject strongAstroid;
    [SerializeField] GameObject alien;

    [SerializeField] float tick;
    [SerializeField] float spawnClock;
    [SerializeField] float levelClock;
    [SerializeField] float globalClock;

    // Start is called before the first frame update
    void Start()
    {
        spawnClock = 0;
        levelClock = 0;
        globalClock = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnClock += Time.deltaTime;
        levelClock += Time.deltaTime;
        globalClock += Time.deltaTime;
        if(spawnClock >= tick)
        {
            spawnClock = 0;
            int rndNum = Random.Range(0,16);
            if(rndNum <= 4) // Strong astroid spawn
                Instantiate(strongAstroid, Vector3.zero, Quaternion.identity);
            else if(rndNum == 5) // Alien spawn
                Instantiate(alien, Vector3.zero, Quaternion.identity);
            else // Regular astroid spawn
            {
                if(Random.Range(0,3) == 0)
                    Instantiate(directAstroid, Vector3.zero, Quaternion.identity);
                else
                    Instantiate(astroid, Vector3.zero, Quaternion.identity);
            }
        }

        if(levelClock >= 10)
        {
            if(tick >= 0.5f)
                tick -= 0.2f;
            levelClock = 0;
        }
    }
}
