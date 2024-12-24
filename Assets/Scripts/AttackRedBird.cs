using UnityEngine;
using System.Collections;

public class AttackRedBird : MonoBehaviour
{
    public float attackRange = 10.0f; // Phạm vi tấn công
    public GameObject bulletPrefab; // Prefab của viên đạn
    public Transform bulletSpawnPoint; // Vị trí bắn đạn
    public float bulletSpeed = 20f; // Tốc độ đạn
    public float attackInterval = 2.0f; // Khoảng thời gian giữa mỗi lần tấn công
    public SpamBirdLeft spamBirdLeft;

    private void Start()
    {

        // Bắt đầu Coroutine tấn công
        StartCoroutine(AttackRoutine());
  
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            var minDistance = Mathf.Infinity;
            Transform target = null;
            for (int i = 0; i < spamBirdLeft.clonetransform.Count; i++)
            {
                float distance = Vector3.Distance(this.transform.position, spamBirdLeft.clonetransform[i].position);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    target = spamBirdLeft.clonetransform[i];
                }
            }

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