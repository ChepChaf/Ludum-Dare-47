using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionDeTrayectoria : MonoBehaviour
{
    [SerializeField] float radio = 3.0f;

    public float Radio { get => radio; set => radio = value; }

    public Vector3 TrayectoriaCircular(float tiempo, float rad = 0)
    {
        if(rad == 0)
        {
            rad = radio;
        }

        return new Vector3(rad * Mathf.Cos(Mathf.PI * 2 * tiempo), rad * Mathf.Sin(Mathf.PI * 2 * tiempo));
    }
}
