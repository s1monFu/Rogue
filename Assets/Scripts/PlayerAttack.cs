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
        
    }

    private void ProcessInput() 
    {
        float shootX = Input.GetAxis("ShootHorizontal");
        float shootY = Input.GetAxis("ShootVertical");

        if ((shootX != 0 || shootY != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(shootX, shootY);
        }
    }

    private void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0 ?))
    }
}
