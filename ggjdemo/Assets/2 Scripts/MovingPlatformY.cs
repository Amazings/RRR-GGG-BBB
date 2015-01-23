using UnityEngine;
using System.Collections;
public class MovingPlatformY : MonoBehaviour
{
    public Transform pointB;
    private Vector3 pointA;
    public float speed = 1.0f;
    private float direction = 1.0f;

    IEnumerator Start()
    {
        pointA = transform.position;
        while (true)
        {
            if (transform.position.y < pointA.y)
            {
                direction = 1;
            }
            else if (transform.position.y > pointB.position.y)
            {
                direction = -1;
            }
            float delta = Time.deltaTime * 60;
            transform.Translate(0, direction * speed * delta, 0, Space.World);
            yield return 0;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }

}