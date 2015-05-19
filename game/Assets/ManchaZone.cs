using UnityEngine;
using System.Collections;

public class ManchaZone : MonoBehaviour {

    public AnimationClip animation_On;
    public AnimationClip animation_Loop;
    public AnimationClip animation_Off;

    private states state;
    private Animation anim;
    private enum states
    {
        ON,
        OFF
    }
    void Start()
    {
        anim = GetComponent<Animation>();
        Events.OnLevelComplete += OnLevelComplete;
        anim.clip = animation_On;
        anim.Play();
    }
    void OnDestroy()
    {
        Events.OnLevelComplete -= OnLevelComplete;
    }
    void OnLevelComplete()
    {
        state = states.OFF;
    }
    public void Animation_On_Ready()
    {
        anim.Play(animation_Loop.name);
    }
    public void Animation_Loop_Ready()
    {
        if(state == states.OFF)
            anim.Play(animation_Off.name);
    }
    public void Animation_Off_Ready()
    {
        GameObject.Destroy(gameObject);
    }
}
