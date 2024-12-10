using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLight : MonoBehaviour
{
    float[] speeds = new float[3];
    private Vector3 rotationAxes;
    public float rotationSpeed = 10f; // سرعة دوران الكرات
    private Vector3[] randomRotationAxes; // محاور الدوران العشوائية لكل كرة


    void Start()
    {
        
        // for (int i = 0; i < speeds.Length; i++)
        // {
        //     speeds[i] = Random.Range(10f, 20f); // Random float speed

        // }
        randomRotationAxes = new Vector3[3];
        for (int i = 0; i < 3; i++)
        {
            randomRotationAxes[i] = new Vector3(
                0, // محور عشوائي للـ X
                0, // محور عشوائي للـ Y
                Random.Range(-1f, 1f)  // محور عشوائي للـ Z
            ); // تأكيد أن المحور وحدة
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            // دوران الكرات حول المحاور العشوائية التي تم توليدها
            transform.Rotate(randomRotationAxes[i], rotationSpeed * Time.deltaTime);
        }
        // rotationAxes += new Vector3(0, 0, Random.Range(-45, 180)); // Random rotation axis
        // foreach (float speed in speeds)
        // {
        //     transform.Rotate(rotationAxes, speed * Time.deltaTime);
        // }
    }
}
