using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RightCheckCol : MonoBehaviour
{
    [SerializeField] int _scoreRight = 0;
    public int ScoreRight
    {
        set { _scoreRight = value; }
        get { return _scoreRight; }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("redbird"))
        {
            _scoreRight += 2;
            Debug.Log(_scoreRight); 
        }
    }
}
