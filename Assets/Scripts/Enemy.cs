using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player1;
    private GameObject player2;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    void Update()
    {
        if (player1 == null && player2 == null) return;

        GameObject target = GetClosestPlayer();
        agent.destination = target.transform.position;
    }

    GameObject GetClosestPlayer()
    {
        float dist1 = player1 != null
            ? Vector3.Distance(transform.position, player1.transform.position)
            : Mathf.Infinity;

        float dist2 = player2 != null
            ? Vector3.Distance(transform.position, player2.transform.position)
            : Mathf.Infinity;

        return dist1 < dist2 ? player1 : player2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1") ||
            collision.gameObject.CompareTag("Player2"))
        {
            // quitar puntos
            GameManager.Instance.RemovePoint(collision.gameObject.tag);
            EsferaPlayerBase player = collision.gameObject.GetComponent<EsferaPlayerBase>();

            if (player != null)
            {
                player.Respawn();
            }
        }
    }
}