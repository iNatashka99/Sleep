using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public Vector3 start_point;
    public float min, max;
    public float speed;
    public float distance;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Pod_count", PlayerPrefs.GetInt("Pod_count") + 1);
        int t = PlayerPrefs.GetInt("Pod_count");
        transform.position = new Vector3(PlayerPrefs.GetFloat("startX") + Random.Range(3, 10), start_point.y, start_point.z);
        target = transform.position;
        target.x = start_point.x - distance;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("startX", transform.position.x);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position.x <= target.x)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("Pod_count", PlayerPrefs.GetInt("Pod_count") - 1);
        }
    }
}
