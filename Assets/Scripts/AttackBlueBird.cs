using UnityEngine;
using System.Collections;

public class AttackBlueBird : MonoBehaviour
{
    public float attackRange = 10.0f; // Phạm vi tấn công
    public Transform target; // Mục tiêu
    public GameObject bulletPrefab; // Prefab của viên đạn
    public Transform bulletSpawnPoint; // Vị trí bắn đạn
    public float bulletSpeed = 20f; // Tốc độ đạn
    public float attackInterval = 2.0f; // Khoảng thời gian giữa mỗi lần tấn công

    private void Start()
    {
        // Bắt đầu Coroutine tấn công
        StartCoroutine(AttackRoutine());


    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (target != null)
            {
                float distance = Vector3.Distance(this.transform.position, target.position);
                if (distance <= attackRange)
                {
                    Attack(target);
                }
            }

            // Đợi 2 giây trước khi thực hiện lần tấn công tiếp theo
            yield return new WaitForSeconds(attackInterval);
        }
    }

    void Attack(Transform enemyTarget)
    {
        Debug.Log("Bắn đạn vào mục tiêu: " + enemyTarget.name);

        // Tạo viên đạn tại vị trí bắn
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Hướng viên đạn về mục tiêu
        Vector3 direction = (enemyTarget.position - bulletSpawnPoint.position).normalized;
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.velocity = (direction * bulletSpeed);
            Debug.Log("Viên đạn đã được bắn!");
        }
    }
}