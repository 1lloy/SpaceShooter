using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool MouseLook = true;
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";
    public float MaxSpeed = 7f;
    public float ReloadDelay = 0.3f;
    public bool CanFire = true;
    public Transform[] TurretTransforms;
    private List<GameObject> zvuki = new List<GameObject>();
    public AudioClip clip;
    private Vector3 MousePosWorld;

    private Rigidbody rb = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        MouseLook = true;

        if (MouseLook)
        {
            MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);


            Vector3 LookDirection = MousePosWorld - transform.position;

            if ((System.Math.Round(MousePosWorld.x, 1) != System.Math.Round(transform.position.x, 1)) && ((System.Math.Round(MousePosWorld.z, 1) != System.Math.Round(transform.position.z, 1))))
            {
                transform.LookAt(MousePosWorld);
            }
        }

        float Horz = Input.GetAxis(HorzAxis);
        float Vert = Input.GetAxis(VertAxis);
        Vector3 MoveDirection = new Vector3(Horz, 0.0f, Vert).normalized;

        if ((System.Math.Round(MousePosWorld.x, 1) != System.Math.Round(transform.position.x, 1)) && ((System.Math.Round(MousePosWorld.z, 1) != System.Math.Round(transform.position.z, 1))))
        {
            transform.position += transform.TransformDirection(MoveDirection)* Time.deltaTime * MaxSpeed;
        }

        if (Input.GetButtonDown(FireAxis) && CanFire)
        {
            foreach (Transform T in TurretTransforms)
            {
                AmmoManager.SpawnAmmo(T.position, T.rotation);
                zvuki.Add(Instantiate(new GameObject(), transform));
                zvuki[zvuki.Count - 1].AddComponent<AudioSource>();
                zvuki[zvuki.Count - 1].GetComponent<AudioSource>().clip = clip;
                zvuki[zvuki.Count - 1].GetComponent<AudioSource>().volume = 0.5f;
                zvuki[zvuki.Count - 1].GetComponent<AudioSource>().Play();
            }

            CanFire = false;
            Invoke("EnableFire", ReloadDelay);
        }
    }

    void EnableFire()
    {
        CanFire = true;
    }
}
