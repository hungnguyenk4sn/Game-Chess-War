using UnityEngine;
using System.Collections;

public class TestAttack : MonoBehaviour
{
    public float attackRange = 10.0f; // Phạm vi tấn công
    public GameObject bulletPrefab; // Prefab của viên đạn
    public Transform bulletSpawnPoint; // Vị trí bắn đạn
    public float bulletSpeed = 20f; // Tốc độ đạn
    public float attackInterval = 2.0f; // Khoảng thời gian giữa mỗi lần tấn công

    SpamBirdLeft spamBirdLeft;
    SpamBirdRight currentPoolRed;

    private Transform target; // Mục tiêu hiện tại
    private bool canAttack = true; // Flag kiểm soát thời gian tấn công

    private void Start()
    {
       spamBirdLeft = GameObject.Find("SpamPointLeft").GetComponent<SpamBirdLeft>();   
       currentPoolRed = GameObject.Find("SpamPointRight").GetComponent<SpamBirdRight>();

        StartCoroutine(AttackRoutine());
    }

    private void Update()
    {
        FindTarget(); // Tìm mục tiêu gần nhất
    }

    /// <summary>
    /// Tìm mục tiêu gần nhất trong phạm vi
    /// </summary>
    private void FindTarget()
    {
        var minDistance = Mathf.Infinity;
        target = null;

        for (int i = 0; i < spamBirdLeft.clonetransform.Count; i++)
        {
            float distance = Vector3.Distance(this.transform.position, spamBirdLeft.clonetransform[i].position);

            if (distance < minDistance && distance <= attackRange)
            {
                minDistance = distance;
                target = spamBirdLeft.clonetransform[i];
            }
        }
    }

    /// <summary>
    /// Coroutine gọi Attack mỗi 2 giây
    /// </summary>
    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (target != null && canAttack)
            {
                Attack(target);
                canAttack = false; // Ngăn chặn tấn công liên tục
                yield return new WaitForSeconds(attackInterval);
                canAttack = true; // Cho phép tấn công lại
            }

            yield return null; // Chờ frame tiếp theo
        }
    }

    /// <summary>
    /// Xử lý tấn công mục tiêu
    /// </summary>
    void Attack(Transform enemyTarget)
    {
        if (enemyTarget == null) return;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Debug.Log("co ban");

        Vector3 direction = (enemyTarget.position - bulletSpawnPoint.position).normalized;
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.velocity = direction * bulletSpeed;
        }
    }

    /// <summary>
    /// Gọi khi đối tượng bị phá hủy
    /// </summary>
    public void TakeDameTest()
    {
        if (currentPoolRed != null && currentPoolRed.cloneTranformRed.Contains(transform))
        {
            currentPoolRed.cloneTranformRed.Remove(transform);
        }
    }
}
