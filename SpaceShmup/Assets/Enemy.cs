using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
[RequireComponent(typeof(BoundsCheck))]
public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10f;
    public int score = 100; //points earned for destroying this enemy

    private BoundsCheck bndCheck;

    public Vector3 pos
    {
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (!bndCheck.isOnScreen)
        {
            if (pos.y < bndCheck.camHeight)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;

    }
}
