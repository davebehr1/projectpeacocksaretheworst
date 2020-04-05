using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerController))]
public class Player : MonoBehaviour {

	public float moveSpeed = 5;

	Camera viewCamera;
	PlayerController controller;
	DogController controller_dog;

	GameObject dog;


    private void Awake()
    {
		dog = GameObject.FindWithTag("Dog");
	}
    void Start () {

		
		controller_dog = dog.GetComponent<DogController>();
		controller = GetComponent<PlayerController> ();
		viewCamera = Camera.main;
	}

	void Update () {
		Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		Vector3 moveVelocity = moveInput.normalized * moveSpeed;
		controller.Move (moveVelocity);
		controller_dog.Move(moveVelocity);



	}
}