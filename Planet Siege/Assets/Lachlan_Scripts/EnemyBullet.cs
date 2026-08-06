using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EnemyBulletHit()
    {
        Destroy(this.gameObject);
    }
}
