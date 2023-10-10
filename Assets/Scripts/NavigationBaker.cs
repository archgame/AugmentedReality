using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class NavigationBaker : MonoBehaviour
{
    private void Start()
    {
        UpdateNavMesh();
    }

    public void UpdateNavMesh()
    {
        var navMeshSrf = GetComponent<NavMeshSurface>(); //get the component
        navMeshSrf.BuildNavMesh();
    }
}