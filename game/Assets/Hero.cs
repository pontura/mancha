using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{

    public LineRenderer dragLine;
    public states state;
    public enum states
    {
        PLAYING,
        SAFE,
        ATTACKED
    }

    float dragSpeed = 1f;

    Rigidbody2D grabbedObject = null;

    void LateUpdate()
    {
        Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos2D = new Vector3(mouseWorldPos3D.x, mouseWorldPos3D.y, 0);

        transform.localPosition = mousePos2D;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SafeZone")
            Safe();
        else if (collision.gameObject.tag == "Mancha")
            Attacked();
        else if (collision.gameObject.tag == "ManchaZone")
            Attacked();
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "SafeZone" && state !=states.ATTACKED)
            Playing();
        else if (collision.gameObject.tag == "Mancha")
            Playing();
        else if (collision.gameObject.tag == "ManchaZone")
            Playing();
    }
    void Safe()
    {
        state = states.SAFE;
    }
    public void Playing()
    {
        if (state == states.PLAYING) return;
        state = states.PLAYING;
        animation.Play("HeroIdle");
        GetComponentInChildren<SpriteRenderer>().color = Color.blue;
    }
    public void Attacked()
    {
        if (state == states.SAFE) return;

        Events.OnHeroAttacked();
       // if (state == states.ATTACKED) return;
        state = states.ATTACKED;
        animation.Play("HeroAttacked");
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        Invoke("RestartHeroCollision", 0.4f);
    }
    void RestartHeroCollision()
    {
        if (state == states.ATTACKED) Attacked();
    }
}
