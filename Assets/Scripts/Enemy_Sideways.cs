using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    // [SerializeField] private float movementDistance;
    // [SerializeField] private float speed;
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Enemy_Sideways: " + collision.gameObject.name + " ");
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}