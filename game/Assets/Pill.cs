using UnityEngine;
using System.Collections;

public class Pill : MonoBehaviour {

    public states state;

    public enum states
    {
        INACTIVE,
        ACTIVE
    }
	void Start () {
	    
	}
    public void SetOn(bool on)
    {
        state = states.ACTIVE;
    }

    void OnTriggerEnter (Collider other) {
        if(other.tag == "Player")
        {
            Events.OnPillCarried();
            gameObject.SetActive(false);
        }
	}
}
