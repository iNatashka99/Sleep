using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    public int pod_count;
    public float jump;
    public bool moveup;
    private Vector2 force;
    private Rigidbody rb;
    private bool inAir = false;
    public GameObject podushka;
    Vector3 pos = new Vector3(100, 0, 0);
    Quaternion rot = new Quaternion(0, 0, 0, 0);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, 0, 0);
        PlayerPrefs.SetString("finish", "no");
        PlayerPrefs.SetInt("Pod_count", 0);
    }

    // Update is called once per frame
    void Update()
    {
        force = new Vector2(0, jump);

        if (Input.GetKey(KeyCode.W))
        {
            MoveU();
        }
        if (moveup)
        {
            MoveU();
        }
        int t = PlayerPrefs.GetInt("Pod_count");
        if (PlayerPrefs.GetInt("Pod_count") < pod_count)
            Instantiate(podushka, pos, rot);



    }
    void MoveU()
    {
        if (!inAir)
        {
            inAir = true;
            rb.AddForce(force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            inAir = false;
 
    }
}
