using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBGR : MonoBehaviour
{
    public GameObject scoreLeft;
    public GameObject scoreRight;
    public GameObject dirBgr;
    public GameObject MainLeft;
    LeftCheckColi scoreL;
    RightCheckCol scoreR;
    MoveBgr dirMove;
    ScrollTexture2D scrollTexture2D;
    int forceL, forceR;

    private void Start()
    {
        scoreL = scoreLeft.GetComponent<LeftCheckColi>();
        scoreR = scoreRight.GetComponent<RightCheckCol>();
        dirMove = dirBgr.GetComponent < MoveBgr>();
        scrollTexture2D= MainLeft.GetComponent<ScrollTexture2D>();  
    }
    private void Update()
    {
        forceL = scoreL.ScoreLeft;
        forceR = scoreR.ScoreRight;
        if (forceL>forceR)
        {
            dirMove.Dir = 1;
            scrollTexture2D.ScrollSpeedX = -0.5f;
        }
        else if ((forceL < forceR))
        {
            dirMove.Dir = -1;
            scrollTexture2D.ScrollSpeedX = 0.5f;
        }
        else
        {
            scrollTexture2D.ScrollSpeedX = 0;

            dirMove.Dir = 0;
        }
    }
}