using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Public Fields
    public GameObject bulletPrefab;

    public float bulletSpeed;

    private float lastFire;

    public float fireDelay;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput() 
    {
        float shootX = Input.GetAxis("ShootHorizontal");
        float shootY = Input.GetAxis("ShootVertical");

        if ((shootX != 0 || shootY != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(shootX, shootY);
            lastFire = Time.time;
        }
    }

    private void Shoot(float x, float y)
    {
        float bulletX = transform.position.x;
        float bulletY = transform.position.y;
        if(x > 0)
        {
            bulletX += 1;
        }else if (x < 0)
        {
            bulletX -= 1;
        }

        if(y > 0)
        {
            bulletY += 1;
        }else if (y < 0)
        {
            bulletY -= 1;
        }
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(bulletX,bulletY,transform.position.z), transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
            0
        );

    }
}
