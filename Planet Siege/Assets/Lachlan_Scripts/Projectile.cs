using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private LayerMask barrierLayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
