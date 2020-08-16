using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

    void OnPlatformTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Ball")
        {
            Invoke("FallDown", 0.5f); 
            FallDownPlatform();
        }
    }
    
    void FallDownPlatform() 
    {
        GetComponentInParent<Rigidbody> ().useGravity = true; 
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f); 
    }
}
