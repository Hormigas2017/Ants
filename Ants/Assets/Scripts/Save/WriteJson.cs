using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteJson : MonoBehaviour {
    
    public Character player = new Character(0,"Wintaaa",100,new int[] {7,4,5});


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Character {
    public int id;
    public string name;
    public int health;
    public int[] stats;

    public Character(int _id, string _name, int _health, int[] _stats)
    {
        this.id = _id;
        this.name = _name;
        this.health = _health;
        this.stats = _stats;

    }
}
