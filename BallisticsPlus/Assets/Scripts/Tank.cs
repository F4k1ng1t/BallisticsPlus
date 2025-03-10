using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Reload the Scene
            SceneManager.LoadScene(0);
        }
    }
    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation) as GameObject;
    }
}
