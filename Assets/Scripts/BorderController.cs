using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    [SerializeField] GameObject upBorder;
    [SerializeField] GameObject downBorder;
    [SerializeField] GameObject leftBorder;
    [SerializeField] GameObject rightBorder;

    [SerializeField] float moveSpeed;
    [SerializeField] float shrinkClock;

    [SerializeField] float levelTick;
    [SerializeField] float levelClock;

    private Vector3 center;
    private Vector3 upStartPos;
    private Vector3 upEndPos;
    private Vector3 downStartPos;
    private Vector3 downEndPos;
    private Vector3 leftStartPos;
    private Vector3 leftEndPos;
    private Vector3 rightStartPos;
    private Vector3 rightEndPos;

    // Markers
    [SerializeField] GameObject upLeftMarker;
    [SerializeField] GameObject upRightMarker;
    [SerializeField] GameObject downRightMarker;
    private Vector3 upLeftMarkerStartPos;
    private Vector3 upRightMarkerStartPos;
    private Vector3 downRightMarkerStartPos;

    // Start is called before the first frame update
    void Start()
    {
        center = Vector3.zero;
        // Initialize borders positions
        upStartPos = upBorder.transform.position;
        upEndPos = new Vector3(0,upBorder.transform.localScale.y/2,0);
        downStartPos = downBorder.transform.position;
        downEndPos = new Vector3(0,-downBorder.transform.localScale.y/2,0);
        leftStartPos = leftBorder.transform.position;
        leftEndPos = new Vector3(-leftBorder.transform.localScale.x/2,0,0);
        rightStartPos = rightBorder.transform.position;
        rightEndPos = new Vector3(rightBorder.transform.localScale.x/2,0,0);
        // Save markers position
        upLeftMarkerStartPos = upLeftMarker.transform.position;
        upRightMarkerStartPos = upRightMarker.transform.position;
        downRightMarkerStartPos = downRightMarker.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        levelClock += Time.deltaTime;
        if(levelClock >= levelTick)
        {
            levelClock = 0;
            moveSpeed += 0.005f;
        }

        if(shrinkClock < 0)
            shrinkClock = 0;
            
        shrinkClock += moveSpeed * Time.deltaTime;
        GameManager.instance.FastMusic(shrinkClock);
        
        upBorder.transform.position = Vector3.Lerp(upStartPos, upEndPos, shrinkClock);
        downBorder.transform.position = Vector3.Lerp(downStartPos, downEndPos, shrinkClock);
        leftBorder.transform.position = Vector3.Lerp(leftStartPos, leftEndPos, shrinkClock);
        rightBorder.transform.position = Vector3.Lerp(rightStartPos, rightEndPos, shrinkClock);

        upLeftMarker.transform.position = Vector3.Lerp(upLeftMarkerStartPos, center, shrinkClock);
        upRightMarker.transform.position = Vector3.Lerp(upRightMarkerStartPos, center, shrinkClock);
        downRightMarker.transform.position = Vector3.Lerp(downRightMarkerStartPos, center, shrinkClock);
    }

    public void ExpandBorder(float amount)
    {
        shrinkClock -= amount;
    }

}
