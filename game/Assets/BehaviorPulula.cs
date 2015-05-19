using UnityEngine;
using System.Collections;

public class BehaviorPulula : MonoBehaviour {

    public float waitToRedirect = 2;
    public float behaviorSpeed = 1;
    public float rotationSpeed = 2;
    public float acceleration = 0.05f;

    private int desiredRotation;
    private Mancha mancha;

	void Start () {
        mancha = GetComponent<Mancha>();
	}
    void OnEnable()
    {
        Redirect();
        rigidbody.velocity = Vector3.zero;
    }
    void OnDisable()
    {
        CancelInvoke("Redirect");
    }
    void Redirect()
    {        
        desiredRotation = Random.Range(-359, 359);        
        Invoke("Redirect", waitToRedirect);
       // transform.localEulerAngles = new Vector3(0, 0, desiredRotation);
    }
    void FixedUpdate()
    {
        
        if (mancha.speed < behaviorSpeed) mancha.speed += acceleration;
        else if (mancha.speed > behaviorSpeed) mancha.speed -= acceleration;

        float rotateZ = transform.localEulerAngles.z;

        transform.Translate(Vector3.up * mancha.speed * Time.deltaTime);

        if (Mathf.Abs(rotateZ - desiredRotation)<1) return;

        if (rotateZ < desiredRotation) rotateZ += rotationSpeed;
        else if (rotateZ > desiredRotation) rotateZ -= rotationSpeed;

        transform.localEulerAngles = new Vector3(0, 0, rotateZ);


    }
    void M_OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mancha") return;
        desiredRotation = 0;
        Vector3 myCollisionNormal = collision.contacts[0].normal;
        Vector3 normal = Reflect(Vector3.up, myCollisionNormal);
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, normal);
        transform.rotation = rot;
    }
    Vector3 Reflect(Vector3 vector, Vector3 normal)
    {
        return vector - 2 * Vector3.Dot(vector, normal) * normal;
    }
}
