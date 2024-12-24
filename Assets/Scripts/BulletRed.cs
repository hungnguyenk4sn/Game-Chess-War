using Unity.VisualScripting;
using UnityEngine;

public class BulletRed : MonoBehaviour
{
    //public float damage = 10f; // Sát thương
    public float destroyAfter = 5f; // Tự hủy sau 5 giây

    void Start()
    {
        //Tự hủy đạn sau thời gian giới hạn
        Destroy(gameObject, destroyAfter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bluebird"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    

}
