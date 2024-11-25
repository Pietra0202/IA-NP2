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

    void Start()
    {

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
        if (cheser == null)
            return;

        // Calcula a direção normalizada para fugir do perseguidor
        Vector3 directionNormalized = (cheser.position - transform.position).normalized;

        // Adiciona um desvio aleatório à direção
        MoveToPos(transform.position - (directionNormalized * travelCost));

        directionNormalized = Quaternion.AngleAxis(Random.Range(0, 179), Vector3.up) * directionNormalized;

    }

    private void MoveToPos(Vector3 position)

    {
        agent.SetDestination(position);
        agent.isStopped = false;
    }



}