using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public delegate void OnCoinPicked();
    public static event OnCoinPicked onCoinPickedEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            onCoinPickedEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
