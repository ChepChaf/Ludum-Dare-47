using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionDeTrayectoria : MonoBehaviour
{
    public static int maxIndex;
    public List<Transform> points;
    public Vector3 Trajectory(int index, float offset = 0, bool clockwise = false)
    {
        if (points.Count == 0) return new Vector3();

        if (index > points.Count - 1)
            index %= points.Count;

        if (clockwise)
            index = points.Count - index - 1;

        return points[index].position + (Vector3.one * offset);
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }
        if (points.Count > 1)
            Gizmos.DrawLine(points[points.Count - 1].position, points[0].position);
    }
}
