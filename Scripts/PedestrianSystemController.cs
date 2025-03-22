#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSystemController : MonoBehaviour
{
    [Header("___________________________________________________________________________________________________________________________________________")]
    [Header("Pedestrian configuration values")]
    [Space(10)]
    [Tooltip("The pedestrian prefab")]
    public GameObject pedestrianPrefab;
    [Space(10)]

    [Tooltip("The minimum speed of the pedestrians")]
    public float minimumSpeed = 0.5f;

    [Tooltip("The maximum speed of the pedestrians")]
    public float maximumSpeed = 2.0f;
    [Space(10)]

    [Tooltip("The number of pedestrians to spawn")]
    public int pedestrianNumber = 5;
    private Transform selectedNodeSpawnPoint;
    [Space(10)]
    [Tooltip("Do the pedestrians have a random wait time at each node?")]
    public bool hasWaitTime = false;
    
    [Tooltip("Minimum amount of time a pedestrian can wait at a node before moving to the next one")]
    public float minimumWaitTime = 0f;
    [Tooltip("Maximum amount of time a pedestrian can wait at a node before moving to the next one")]
    public float maximumWaitTime = 1f;
    [Space(10)]
    [Tooltip("Do the pedestrians change their color each time they spawn?")]
    public bool useRandomColor = false;
    public List<Color> colors = new List<Color>();

    [Header("___________________________________________________________________________________________________________________________________________")]
    [Header("Nodes configuration")]
    [Space(10)]
    [Tooltip("The parent object of all nodes")]
    public GameObject nodesParent;
    private GameObject mainNode;
    private List<GameObject> nodes = new List<GameObject>();
    

    void Start()
    {
    if (minimumWaitTime > maximumWaitTime)
    {
        Debug.LogError("Minimum pedestrian wait time cannot be greater than maximum pedestrian wait time");
        return;
    }

    foreach (Transform child in nodesParent.transform)
    {
        if (child.gameObject.GetComponent<PedestrianSystemNode>() != null)
        {
            nodes.Add(child.gameObject);
            Debug.Log("Node " + child.gameObject.name + " added to the nodes list");
        }
        else
        {
            Debug.LogError("Node " + child.gameObject.name + " is missing a PedestrianSystemNode component");
        }
    }

    HashSet<Transform> occupiedNodes = new HashSet<Transform>();
    int currentInstantiatedPedestrians = 0;

    while (currentInstantiatedPedestrians < pedestrianNumber)
    {
        Transform selectedNodeSpawnPoint;

        if (occupiedNodes.Count < nodes.Count)
        {
            do
            {
                selectedNodeSpawnPoint = nodes[Random.Range(0, nodes.Count)].transform;
            }
            while (occupiedNodes.Contains(selectedNodeSpawnPoint));

            occupiedNodes.Add(selectedNodeSpawnPoint);
        }
        else
        {
            selectedNodeSpawnPoint = nodes[Random.Range(0, nodes.Count)].transform;
        }

        GameObject newPedestrian = Instantiate(pedestrianPrefab, selectedNodeSpawnPoint.position, Quaternion.identity);

        if (useRandomColor && colors.Count > 0)
        {
            Color randomColor = colors[Random.Range(0, colors.Count)];
            Renderer pedestrianRenderer = newPedestrian.GetComponent<Renderer>();
            if (pedestrianRenderer != null)
            {
                pedestrianRenderer.material.color = randomColor;
            }
        }

        // Genera una velocità casuale per il pedone
        float randomSpeed = Random.Range(minimumSpeed, maximumSpeed);

        // Inizializza il movimento del pedone
        PedestrianMover mover = newPedestrian.GetComponent<PedestrianMover>();
        if (mover != null)
        {
            mover.Initialize(
                selectedNodeSpawnPoint.GetComponent<PedestrianSystemNode>(), 
                randomSpeed,
                hasWaitTime, 
                minimumWaitTime, 
                maximumWaitTime
            );
        }

        currentInstantiatedPedestrians++;
    }
}



    public void AddNode()
    {
        // Finds the main node prefab in the project folder
        // If the prefab is found, loads it and assigns it to the mainNode variable
        #if UNITY_EDITOR
        string[] guids = AssetDatabase.FindAssets("t:Prefab PedestrianSystemNodePrefab");
        if (guids.Length > 0)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            mainNode = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        }
        #endif

        // Adds the main node to the scene
        Instantiate(mainNode, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("Node added to the scene at position (0, 0, 0)");
    }
}
