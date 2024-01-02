using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public static int graus;
    private void Update()
    {
        graus++;
        this.transform.rotation = Quaternion.Euler(graus, graus, 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.tag == "Player")
        {
          
            gameObject.SetActive(false);
            Destroy(gameObject,5);


        }

    }
}
