using UnityEngine;
using System.Collections;

public class Mancha : MonoBehaviour {
    
    public behaviors behavior;
    public float speed = 0;
    private bool scaleReady;
    private Vector3 realScale;
    private float scaleBornSpeed = 0.02f;

    public enum behaviors
    {
        IDLE,
        PATHS,
        FOLLOW,
        PULULA,
        ATTACK
    }
    
    void Start()
    {
       // Events.OnManchaChangeBehavior += OnManchaChangeBehavior;
        realScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }
    void OnDestroy()
    {
        //Events.OnManchaChangeBehavior -= OnManchaChangeBehavior;
    }
    void Update()
    {
        if (scaleReady) return;

        transform.localScale += new Vector3(scaleBornSpeed, scaleBornSpeed, scaleBornSpeed);
        if (transform.localScale.x >= realScale.x) scaleReady = true;

    }
    public void OnManchaChangeBehavior(behaviors _behavior)
    {
        if (behavior == behaviors.PATHS) return;
        if (behavior == _behavior) return;

        behavior = _behavior;

        GetComponent<BehaviorPulula>().enabled = false;
        GetComponent<BehaviorPath>().enabled = false;
        GetComponent<BehaviorFollow>().enabled = false;

        switch (behavior)
        {
            case behaviors.FOLLOW:
                GetComponent<BehaviorFollow>().enabled = true;
                break;
            case behaviors.PULULA:
                GetComponent<BehaviorPulula>().enabled = true;
                break;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            SendMessage("M_OnCollisionEnter", collision, SendMessageOptions.DontRequireReceiver);
        }
    }
    void Attack(Hero hero)
    {
        behavior = behaviors.ATTACK; 
    }
    Vector3 Reflect(Vector3 vector, Vector3 normal)
    {
        return vector - 2 * Vector3.Dot(vector, normal) * normal;
    }
}
