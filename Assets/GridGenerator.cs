using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject gridPrefab; // Prefab of the GameObject to be used for the grid
    public int gridSizeX = 5; // Number of grid cells along the X-axis
    public int gridSizeZ = 5; // Number of grid cells along the Z-axis
    public float cellSize = 1f; // Size of each grid cell
    public Vector3 center;
    public BoundingBox BoundingBox;
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < gridSizeX; i++)
        {
            // Generate random offsets within the range (-center, center) for each axis
            float randomOffsetX = Random.Range(BoundingBox.length / -2, BoundingBox.length / 2);
            float randomOffsetY = Random.Range(BoundingBox.height / -2, BoundingBox.height / 2);
            float randomOffsetZ = Random.Range(BoundingBox.width / -2, BoundingBox.width / 2);

            // Calculate the position for the current grid cell by adding random offsets to the center point
            Vector3 position = center + new Vector3(randomOffsetX, randomOffsetY, randomOffsetZ);

            // Instantiate the grid prefab at the calculated position
            GameObject gridCell = Instantiate(gridPrefab, position, Quaternion.identity);

            // Set the parent of the grid cell to be this GameObject (GridGenerator)
            gridCell.transform.parent = transform;
        }
    }
    private void OnDrawGizmos()
    {
        BoundingBox.Draw();
    }
}
