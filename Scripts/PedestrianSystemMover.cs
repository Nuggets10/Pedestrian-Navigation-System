using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMover : MonoBehaviour
{
    private float speed;
    private bool hasWaitTime;
    private float minWaitTime;
    private float maxWaitTime;
    private PedestrianSystemNode currentNode;

    public void Initialize(PedestrianSystemNode startNode, float pedestrianSpeed, bool waitTimeEnabled, float minWait, float maxWait)
    {
        currentNode = startNode;
        speed = pedestrianSpeed;
        hasWaitTime = waitTimeEnabled;
        minWaitTime = minWait;
        maxWaitTime = maxWait;

        StartCoroutine(WalkPath());
    }

    private IEnumerator WalkPath()
    {
        while (true) // Il pedone continuerà a muoversi finché è attivo
        {
            if (currentNode.adiacentNodes.Count == 0)
            {
                Debug.LogWarning(gameObject.name + " non ha nodi adiacenti! Resta fermo.");
                yield break;
            }

            // Scegli un nodo casuale tra quelli adiacenti
            GameObject nextNode = currentNode.adiacentNodes[Random.Range(0, currentNode.adiacentNodes.Count)];
            Vector3 targetPosition = nextNode.transform.position;

            // Muoviti verso il nodo
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Aggiorna il nodo corrente
            currentNode = nextNode.GetComponent<PedestrianSystemNode>();

            // Se il sistema prevede un tempo di attesa, aspetta un tempo casuale
            if (hasWaitTime)
            {
                float waitTime = Random.Range(minWaitTime, maxWaitTime);
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}
