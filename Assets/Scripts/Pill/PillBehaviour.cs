using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float healAmount = 25f;

    private Vector3 originPosition;
    private float yRange;
    private float yDirection;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        yRange = 0.5f;
        yDirection = 1;
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 100, 0) * Time.deltaTime);

        if (yDirection == 1)
        {
            if (transform.position.y < originPosition.y + yRange)
                transform.position += new Vector3(0, yDirection * speed * Time.deltaTime, 0);
            else
                yDirection = -1;
        }
        else
        {
            if (transform.position.y > originPosition.y - yRange)
                transform.position += new Vector3(0, yDirection * speed * Time.deltaTime, 0);
            else
                yDirection = 1;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TankHealth>(out TankHealth targetHealth))
        {
            targetHealth.Heal(healAmount);
            Destroy(this.gameObject);
        }
    }
}
