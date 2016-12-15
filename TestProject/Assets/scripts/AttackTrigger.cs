using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	public int dmg = 20;

	void OnTriggerEnter2D(Collider2D col){
	
		if (col.isTrigger != true) {
		
			col.SendMessageUpwards ("Damage", dmg);
			Debug.Log ("TEST: Send a Damage method call to whatever enemy the attack collided with, SUCCESS");
		}

	}
		
}
