using NavMeshPlus.Components;
using UnityEngine;

public class NavMeshSurfaceManagement : MonoBehaviour
{
    public static NavMeshSurfaceManagement Instance { get; private set; }

    private NavMeshSurface _navmeshSurface;

    private void Awake()
    {
        Instance = this;
        _navmeshSurface = GetComponent<NavMeshSurface>();
        _navmeshSurface.hideEditorLogs = true;
    }

    public void RebakeNavmeshSurface()
    {
        _navmeshSurface.BuildNavMesh();
    }
}
