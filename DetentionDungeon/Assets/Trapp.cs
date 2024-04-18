using UnityEngine;
using System.Collections;
 
public class Trapp : MonoBehaviour {
    public GameObject objToDestroy;
 
 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(objToDestroy);
 
    }
 
}