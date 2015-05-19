using UnityEngine;
using System.Collections;

public class BehaviorPath : MonoBehaviour {

    public Vector2[] paths;
    public float behaviorSpeed = 4;
    public float acceleration = 0.01f;
    private int activePath = 0;
    private Mancha mancha;

    void Start()
    {
        mancha = GetComponent<Mancha>();
    }
    void FixedUpdate()
    {
        if (mancha.speed < behaviorSpeed) mancha.speed += acceleration;
        else if (mancha.speed > behaviorSpeed) mancha.speed -= acceleration;

        Vector2 destination = paths[activePath];
        float distance = Vector3.Distance(transform.localPosition, destination);

        if (distance < 0.1f)
            nextPath();
        
        Vector2 dir = destination - new Vector2(transform.localPosition.x, transform.localPosition.y);

        transform.Translate(Vector3.up * mancha.speed * Time.deltaTime);


        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    }
    void nextPath()
    {
        if (activePath < paths.Length - 1) activePath++;
        else activePath = 0;
    }
}
