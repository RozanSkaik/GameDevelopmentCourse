using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assignment19
{
    public class GameManager : MonoBehaviour
    {
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
                displacement += 0.1f;

                float yNew = Mathf.Sin(Time.time * displacement);
                sphere.transform.rotation = Quaternion.Euler(new Vector3(0, 0, yNew * 90f));

                float xNew = Mathf.Cos(Time.time * displacement);
                sphere.transform.position += new Vector3(xNew * Time.deltaTime, 0, 0);
            }
        }
    }
}
