using UnityEngine;
using UnityEngine.UI; // Để sử dụng UI Image

public class ControHP2 : MonoBehaviour
{
    public Transform leftLimit;  // Điểm giới hạn bên trái
    public Transform rightLimit; // Điểm giới hạn bên phải

    private float totalDistance = 40f; /*Tổng quãng đường giữa hai giới hạn*/
    private float currentDistance; // Quãng đường hiện tại từ giới hạn bên trái
    [SerializeField] UpdateHp UpdateHp;

    void Start()
    {
       
        // Đảm bảo rằng totalDistance không phải 0 để tránh lỗi chia cho 0
        if (totalDistance <= 0)
        {
            Debug.LogWarning("Total distance must be greater than 0. Setting to default value of 10.");
            totalDistance = 40f;
        }

        currentDistance = totalDistance/2;
        UpdateHp.SetUpHP(currentDistance, totalDistance);
    }
    void Update()
    {
        currentDistance = Mathf.Clamp(transform.position.x - leftLimit.position.x, 0, totalDistance);
        //Debug.Log($"curr {currentDistance}"); 

        
       UpdateHp.SetUpHP(currentDistance,totalDistance);
        //Debug.Log("hp" + currentDistance);
       
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit.position.x, rightLimit.position.x),
            transform.position.y,
            transform.position.z
        );
    }
}
