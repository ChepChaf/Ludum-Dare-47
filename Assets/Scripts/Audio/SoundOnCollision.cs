using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{
    private SoundManager soundManager;
    public string objectName;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        objectName = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Play Sound for:" + this.gameObject.name);
                soundManager.PlayCollisionSound("Collide Enemy");
            }
            else if (this.gameObject.CompareTag("Coin"))
            {
                Debug.Log("Play Sound for:" + this.gameObject.name);
                soundManager.PlayCollisionSound("Pick Up Coin");
            }
        }

    }
}
