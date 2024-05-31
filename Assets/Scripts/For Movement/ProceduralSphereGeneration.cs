using UnityEngine;

public class ProceduralSphereGeneration : MonoBehaviour
{
    public GameObject spherePrefab;  // Prefab for the spheres to be generated
    public MeshFilter meshFilter;    // MeshFilter of the target mesh
    public int numberOfSpheres = 100; // Number of spheres to generate
    public Vector3 areaCenter = new Vector3(0, 0, 0); // Center of the area on the mesh
    public Vector3 areaSize = new Vector3(5, 5, 0);   // Size of the area on the mesh

    void Start()
    {
        if (spherePrefab == null || meshFilter == null)
        {
            Debug.LogError("Please assign the sphere prefab and the mesh filter.");
            return;
        }

        GenerateSpheresOnMesh();
    }

    void GenerateSpheresOnMesh()
    {
        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        for (int i = 0; i < numberOfSpheres; i++)
        {
            // Find a random point within the designated area
            Vector3 randomPointInArea = new Vector3(
                Random.Range(areaCenter.x - areaSize.x / 2, areaCenter.x + areaSize.x / 2),
                Random.Range(areaCenter.y - areaSize.y / 2, areaCenter.y + areaSize.y / 2),
                Random.Range(areaCenter.z - areaSize.z / 2, areaCenter.z + areaSize.z / 2)
            );

            Debug.Log("Random Point in Area: " + randomPointInArea);

            // Find the closest point on the mesh
            float minDistance = float.MaxValue;
            Vector3 closestPoint = Vector3.zero;
            Vector3 closestNormal = Vector3.zero;

            foreach (Vector3 vertex in vertices)
            {
                float distance = Vector3.Distance(randomPointInArea, vertex);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestPoint = vertex;
                }
            }

            Debug.Log("Closest Point on Mesh: " + closestPoint);

            // Instantiate the sphere at the closest point
            GameObject sphere = Instantiate(spherePrefab, meshFilter.transform);
            sphere.transform.localPosition = closestPoint;

            // Align the sphere to the normal of the mesh at that point
            int vertexIndex = System.Array.IndexOf(vertices, closestPoint);
            if (vertexIndex >= 0)
            {
                closestNormal = normals[vertexIndex];
                sphere.transform.up = closestNormal;
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(areaCenter, areaSize);
    }
}
