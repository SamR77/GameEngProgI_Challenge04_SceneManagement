using UnityEngine;
public class SpawnPointGizmo : MonoBehaviour
{
    // This script adds a gizmo icon in the scene view for spawn points

    // You can change this to a custom icon by setting it in the Unity editor
    public string gizmoIconName = "spawnPoint";

    // This method is called by Unity to draw the gizmo
    private void OnDrawGizmos()
    {
        // Draw a sphere at the spawn point
        Gizmos.color = Color.red;  // You can change the color here
        Gizmos.DrawSphere(transform.position, 0.5f); // Draw a sphere at the spawn point location with radius 0.5

        // Draw an icon at the spawn point (optional: you can use custom icons if placed in the project)
        Gizmos.DrawIcon(transform.position, gizmoIconName, true); // The 'true' argument makes the icon rotate with the scene view
    }
}