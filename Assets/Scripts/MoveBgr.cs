using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBgr : MonoBehaviour
{
    public float speed = 1;
    [SerializeField] float _dir = 1;
    public float Dir
    {
        set { _dir = value; }
        get { return _dir; }

    }
   
    void Update()
    {
        transform.Translate(Vector2.right*_dir*speed*Time.deltaTime);
    }
}
