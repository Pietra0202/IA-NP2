using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class AwayRun : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform cheser = null;
    [SerializeField] private float travelCost = 5f;
    private object m_Curve;

    //[SerializeField] private Transform[] waypoints;
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    public int targetPoint = 0;

    void Start()
    {

        targetPoint = Random.Range(0, waypoints.Count);

        if (agent == null)
        {
            if (!TryGetComponent(out agent))
            {
                Debug.LogWarning(name + "precisa colocar um navmesh agent");
            }
        }
    }

    void Update()
    {
        Debug.Log(waypoints.Count);

        if (cheser == null)
            return;

        // Calcula a direção normalizada para fugir do perseguidor
        //Vector3 directionNormalized = (cheser.position - transform.position).normalized;

        // Adiciona um desvio aleatório à direção
        MoveToPos(waypoints[targetPoint].position);

        if (transform.position.x == waypoints[targetPoint].position.x && transform.position.z == waypoints[targetPoint].position.z)
        {
            Debug.Log("Chegou na moeda");

            Destroy(waypoints[targetPoint].gameObject);

            waypoints.Remove(waypoints[targetPoint]);

            targetPoint = Random.Range(0, waypoints.Count);
        }

        //directionNormalized = Quaternion.AngleAxis(Random.Range(0, 179), Vector3.up) * directionNormalized;

    }

    private void MoveToPos(Vector3 position)

    {
        agent.SetDestination(position);
        agent.isStopped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}