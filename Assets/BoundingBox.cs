using UnityEngine;
[System.Serializable]
public class BoundingBox
{
    public Vector3 centerPoint;
    public float length;
    public float width;
    public float height;

    // Constructor
    public BoundingBox(Vector3 center, float length, float width, float height)
    {
        this.centerPoint = center;
        this.length = length;
        this.width = width;
        this.height = height;
    }

    // Draw method to draw the bounding box using gizmos
    public void Draw()
    {
        // Calculate half extents
        float halfLength = length / 2f;
        float halfWidth = width / 2f;
        float halfHeight = height / 2f;

        // Calculate box corners
        Vector3 corner1 = centerPoint + new Vector3(-halfLength, -halfHeight, -halfWidth);
        Vector3 corner2 = centerPoint + new Vector3(halfLength, -halfHeight, -halfWidth);
        Vector3 corner3 = centerPoint + new Vector3(-halfLength, -halfHeight, halfWidth);
        Vector3 corner4 = centerPoint + new Vector3(halfLength, -halfHeight, halfWidth);
        Vector3 corner5 = centerPoint + new Vector3(-halfLength, halfHeight, -halfWidth);
        Vector3 corner6 = centerPoint + new Vector3(halfLength, halfHeight, -halfWidth);
        Vector3 corner7 = centerPoint + new Vector3(-halfLength, halfHeight, halfWidth);
        Vector3 corner8 = centerPoint + new Vector3(halfLength, halfHeight, halfWidth);

        // Draw lines between corners to form the box
        Gizmos.DrawLine(corner1, corner2);
        Gizmos.DrawLine(corner2, corner4);
        Gizmos.DrawLine(corner4, corner3);
        Gizmos.DrawLine(corner3, corner1);

        Gizmos.DrawLine(corner5, corner6);
        Gizmos.DrawLine(corner6, corner8);
        Gizmos.DrawLine(corner8, corner7);
        Gizmos.DrawLine(corner7, corner5);

        Gizmos.DrawLine(corner1, corner5);
        Gizmos.DrawLine(corner2, corner6);
        Gizmos.DrawLine(corner3, corner7);
        Gizmos.DrawLine(corner4, corner8);
    }
}
