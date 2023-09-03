using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;
    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
    const string yAxis = "Mouse Y";
    Rigidbody m_Rigidbody;
    public float movespeed = 0.1f;
    public float m_Thrust = 20f;

    
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(transform.up * m_Thrust);
        }
        
    }

    void Update()
    {
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        transform.localRotation = xQuat;

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("w key was pressed");
            transform.position += transform.forward * movespeed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("w key was pressed");
            transform.position += transform.forward * -movespeed;

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("w key was pressed");
            transform.position += transform.right * movespeed;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("w key was pressed");
            transform.position += transform.right * -movespeed;

        }

    }

}



