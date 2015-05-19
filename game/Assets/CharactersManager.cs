using UnityEngine;
using System.Collections;

public class CharactersManager : MonoBehaviour {

    private Hero[] hero;

	public void Init () {
        hero = new Hero[1];
        hero[0] = GameObject.Find("Hero").GetComponent<Hero>();
	}
	public Hero[] GetHeroes () {
        return hero;
	}
}
