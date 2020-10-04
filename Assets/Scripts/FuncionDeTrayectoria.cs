using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionDeTrayectoria : MonoBehaviour
{
    public List<Transform> points;
    public Vector3 Trajectory(float tiempo, float offset=0)
    {
        if (points.Count == 0) return new Vector3();

        int index = (int)(tiempo * points.Count) % points.Count;
        if (index < 0)
            index = points.Count + index;

        return points[index].position + (Vector3.one * offset);
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < points.Count-1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }
        if (points.Count > 1)
            Gizmos.DrawLine(points[points.Count - 1].position, points[0].position);
    }
}
