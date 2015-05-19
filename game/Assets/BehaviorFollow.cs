using UnityEngine;
using System.Collections;

public class BehaviorFollow : MonoBehaviour {

    public Transform target;
    private CharactersManager charactersManager;

    public float behaviorSpeed = 6;
    public float acceleration = 0.02f;

    private Mancha mancha;

    void Start()
    {
        charactersManager = Game.I.charactersManager;
        mancha = GetComponent<Mancha>();
    }

    void FixedUpdate()
    {
        if (mancha.speed < behaviorSpeed) mancha.speed += acceleration;
        else if (mancha.speed > behaviorSpeed) mancha.speed -= acceleration;

        Hero hero = charactersManager.GetHeroes()[0];
        target = hero.transform;

        if (target != null)
        {
            Vector2 destination = target.localPosition;

            Vector3 dir = destination - new Vector2(transform.localPosition.x, transform.localPosition.y);

           // rigidbody.velocity = dir.normalized * moveSpeed;

            transform.Translate(Vector3.up * mancha.speed * Time.deltaTime);

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        }
    }
}
