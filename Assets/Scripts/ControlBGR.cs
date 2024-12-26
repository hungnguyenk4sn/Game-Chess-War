using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBGR : MonoBehaviour
{
    public GameObject scoreLeft;
    public GameObject scoreRight;
    public GameObject dirBgr;
    public GameObject MainLeft;
    public GameObject MainRight;
    public GameObject Pipe;
    LeftCheckColi scoreL;
    RightCheckCol scoreR;
    MoveBgr dirMove;
    ScrollTexture2D scrollTexture2DMainLeft;
    ScrollTexture2D scrollTexture2DMainRight;
    ScrollTexture2D scrollTexture2DPipe;
    int forceL, forceR;

    private void Start()
    {
        scoreL = scoreLeft.GetComponent<LeftCheckColi>();
        scoreR = scoreRight.GetComponent<RightCheckCol>();
        dirMove = dirBgr.GetComponent < MoveBgr>();
        scrollTexture2DMainLeft = MainLeft.GetComponent<ScrollTexture2D>();
        scrollTexture2DMainRight = MainRight.GetComponent<ScrollTexture2D>();
        scrollTexture2DPipe = Pipe.GetComponent<ScrollTexture2D>();
    }
    private void Update()
    {
        forceL = scoreL.ScoreLeft;
        forceR = scoreR.ScoreRight;
        if (forceL>forceR)
        {
            dirMove.Dir = -1;
            scrollTexture2DMainLeft.ScrollSpeedX = 0.5f;
            scrollTexture2DMainRight.ScrollSpeedX = 0.5f;
            scrollTexture2DPipe.ScrollSpeedX =-1f;
        }
        else if ((forceL < forceR))
        {
            dirMove.Dir = 1;
            scrollTexture2DMainLeft.ScrollSpeedX = -0.5f;
            scrollTexture2DMainRight.ScrollSpeedX = -0.5f;
            scrollTexture2DPipe.ScrollSpeedX = 1f;
        }
        else
        {
            scrollTexture2DMainLeft.ScrollSpeedX = 0;
            scrollTexture2DMainRight.ScrollSpeedX= 0;
            scrollTexture2DPipe.ScrollSpeedX = 0;

            dirMove.Dir = 0;
        }
    }
}