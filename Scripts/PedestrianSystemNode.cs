using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PedestrianSystemNode : MonoBehaviour
{
    [Header("Node configuration")]
    [Space(10)]
    [Tooltip("Add to the list every single adjacent node to this one")]
    public List<GameObject> adiacentNodes = new List<GameObject>();
    private List<GameObject> confirmedAdiacentNode = new List<GameObject>();

    void Start()
    {
        foreach (GameObject node in adiacentNodes)
        {
            if (node.GetComponent<PedestrianSystemNode>() != null)
            {
                confirmedAdiacentNode.Add(node);
            }
            else
            {
                Debug.LogError("Node " + node.name + " is missing a PedestrianSystemNode component");
            }
        }

        adiacentNodes = confirmedAdiacentNode;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        foreach (GameObject node in adiacentNodes)
        {
            if (node != null)
            {
                Vector3 from = transform.position;
                Vector3 to = node.transform.position;

                // Disegna la linea con Handles se in editor, altrimenti usa Gizmos
                #if UNITY_EDITOR
                Handles.color = Color.green;
                Handles.DrawAAPolyLine(5f, from, to); // Linea più spessa
                #else
                Gizmos.DrawLine(from, to);
                #endif

                DrawArrow(from, to, 0.4f); // Freccia più grande
            }
        }

        #if UNITY_EDITOR
        Handles.color = Color.yellow;
        Handles.SphereHandleCap(0, transform.position, Quaternion.identity, 1.4f, EventType.Repaint);
        #endif
    }

    private void DrawArrow(Vector3 from, Vector3 to, float arrowHeadLength)
    {
        Vector3 direction = (to - from).normalized;
        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 150, 0) * Vector3.forward;
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -150, 0) * Vector3.forward;

        Gizmos.DrawLine(to, to - right * arrowHeadLength);
        Gizmos.DrawLine(to, to - left * arrowHeadLength);
    }
}
