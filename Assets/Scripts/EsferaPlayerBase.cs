using UnityEngine;

public class EsferaPlayerBase : MonoBehaviour
{
    protected Rigidbody rb;
    public float velocidad = 10f;

    public Transform respawnPoint;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    public void Respawn()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = respawnPoint.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("KillBox"))
        {
            GameManager.Instance.RemovePoint(gameObject.tag);
            Respawn();
        }
    }
    private void OnTriggerEnter(Collider other) 
    { 
        if (other.CompareTag("Collectible")) 
        { 
            GameManager.Instance.AddCollectible(gameObject.tag); 
            Destroy(other.gameObject); 
        } 
    }
}