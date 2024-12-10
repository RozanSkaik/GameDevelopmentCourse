using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spheres;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float displacement = 1f;
        foreach (GameObject sphere in spheres)
        {

            displacement += 0.5f;
            float yNew = Mathf.Sin(Time.time) + displacement;
            sphere.transform.localScale = new Vector3(yNew, yNew, sphere.transform.localScale.z);

            float xNew = Mathf.Cos(Time.time);
            sphere.transform.position += new Vector3(0, 0, xNew * Time.deltaTime);

        }
    }
}
