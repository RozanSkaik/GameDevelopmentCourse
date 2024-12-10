using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public float flowerRotation = 0f;

    float[] speeds = new float[3];

    void Start()
    {
        for (int i = 0; i < speeds.Length; i++)
        {
            speeds[i] = Random.Range(0.1f, 1f); // Random float speed

        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (float speed in speeds)
        {
            float yOffset = Mathf.Abs(Mathf.Sin(Time.time * speed)) * 2f;  // Sine wave oscillation
            transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);

            float scale = Mathf.Abs(Mathf.Sin(Time.time * speed)) + 0.5f;  // Smooth scaling
            transform.localScale = new Vector3(scale, scale, scale);
        }

        // flowerRotation += 0.3f;
        // transform.rotation = Quaternion.Euler(new Vector3(0, flowerRotation, 0));

        transform.Rotate(Vector3.up, 50f * Time.deltaTime);


    }
}
