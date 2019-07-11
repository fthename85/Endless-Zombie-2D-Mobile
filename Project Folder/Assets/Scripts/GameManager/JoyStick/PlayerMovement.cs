using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float Horizontal;
    float Vertical;
    bool flipped = false;
    Rigidbody2D _Rigidbody;
    float CharacterSpeed;
	public float delayTime;
    public Joystick Joystick;
    void Start()
    {

        CharacterSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().MovementSpeed;
        _Rigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (delayTime < 0)
        {
            Horizontal = Joystick.Horizontal * CharacterSpeed;
            Vertical = Joystick.Vertical * CharacterSpeed;
        }
        else
        {
			delayTime -= Time.deltaTime;
        }


        movementInput(Horizontal, Vertical);
        if (Horizontal == 0 && Vertical == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
    }
    public void movementInput(float Horizontal, float Vertical)
    {
        var deltaTime = Time.deltaTime;

        if (Horizontal < 0 && !flipped)
        {
            _Rigidbody.freezeRotation = false;
            flipped = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Horizontal > 0 && flipped == true)
        {
            _Rigidbody.freezeRotation = false;
            flipped = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.Translate(Vector2.up * Vertical * deltaTime);
        if (Horizontal < 0)
        {
            transform.Translate(Vector2.right * Horizontal * deltaTime * -1);
        }
        else
        {
            transform.Translate(Vector2.right * Horizontal * deltaTime);
        }
        _Rigidbody.freezeRotation = true;
    }
}
