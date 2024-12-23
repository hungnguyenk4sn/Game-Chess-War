using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeftCheckColi : MonoBehaviour
{
    [SerializeField] int _scoreLeft = 0;
    public int ScoreLeft
    {
        set { _scoreLeft = value; }
        get { return _scoreLeft; }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bluebird"))
        {
            _scoreLeft += 3;
            Debug.Log(_scoreLeft); 
        }
    }
}
