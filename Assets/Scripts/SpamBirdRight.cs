using System.ComponentModel;
using UnityEngine;

public class SpamBirdRight : MonoBehaviour
{
    [Header("Cấu Hình Clone")]
    public GameObject prefab;       // Prefab bạn muốn clone
    public Transform spawnPoint;    // Điểm trung tâm để spawn clone
    public int numberOfClones = 10; // Số lượng clone
    public float radius = 5f;       // Bán kính cụm

    private GameObject centerClone; // Clone trung tâm
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

            if (spawnPoint == null)
            {
                Debug.LogError("SpawnPoint chưa được gán!");
                return;
            }

            SpawnCluster();
        }
    }

    void SpawnCluster()
    {
        for (int i = 0; i < numberOfClones; i++)
        {
            Vector2 position;

            if (i == 0)
            {
                // Clone trung tâm tại SpawnPoint
                position = spawnPoint.position;
                centerClone = Instantiate(prefab, position, Quaternion.identity);
                centerClone.name = "Center Clone";
            }
            else
            {
                // Clone xung quanh SpawnPoint trong bán kính ngẫu nhiên 2D
                Vector2 offset = Random.insideUnitCircle * radius;
                position = (Vector2)spawnPoint.position + offset;

                GameObject clone = Instantiate(prefab, position, Quaternion.identity);
                clone.name = $"Clone_{i}";
            }
        }
    }
}
