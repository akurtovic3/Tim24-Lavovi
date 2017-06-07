using UnityEngine;
using System.Collections;

public class ItemRotator : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        //Ovo se poziva svaki frame
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
