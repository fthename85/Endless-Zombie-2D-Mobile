using UnityEngine;

public class CameraOrientation : MonoBehaviour {

	public Camera Camera;
	GameObject Target;
	// Use this for initialization
	void Awake () {
		
		 Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	void Start()
	{
		Target = GameObject.FindGameObjectWithTag("Player");
	}
	void Update()
	{
		Camera.transform.position = Target.transform.position + new Vector3(0,0,-10);
	}
}
