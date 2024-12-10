using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBookManager : MonoBehaviour
{
    public Transform bookFace, bedTransform, wolfTransform;

    public float rotationBookSpeed = 50f;
    public float rotationBedSpeed = 30f;
    public float scaleSpeed = 1f;
    public float positionSpeed = 1f;
    private float bookAngle = 0f;

    Vector3 targetBedScale = new Vector3(1.4f, 1.4f, 0.1f);
    Vector3 targetBedPostion = new Vector3(-2.8f, 0f, -1.592f);
    Vector3 targetWolfScale = new Vector3(0.8f, 0.8f, 0.1f);
    Vector3 targetWolfPostion = new Vector3(-3f, 0.15f, -0.218f);

    Vector3 currentBedPosition, currentBedScale, currentWolfPosition, currentWolfScale;

    void Start()
    {
        CurrentGameObjectsTransform();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateCoverBook(angle: 1);
            if (bookAngle < 180)
            {
                CameraAnimate(Vector3.right, 0.001f);
                ChangeBedTransforms(targetScale: targetBedScale,
                    targetPostion: targetBedPostion,
                    rotateAngle: Vector3.right,
                    checkIfMoveBed: false);
                ChangeWolfTransforms(targetScale: targetWolfScale, targetPostion: targetWolfPostion, rotateAngle: Vector3.right);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateCoverBook(-1);
            if (bookAngle > 0)
            {
                CameraAnimate(Vector3.left, -0.001f);
                ChangeBedTransforms(targetScale: currentBedScale,
                    targetPostion: currentBedPosition,
                    rotateAngle: Vector3.left,
                    checkIfMoveBed: true);
                ChangeWolfTransforms(targetScale: currentWolfScale, targetPostion: currentWolfPosition, rotateAngle: Vector3.left);
            }
        }
        CheckActiveObjects();
    }

    private void CurrentGameObjectsTransform()
    {
        currentBedPosition = new Vector3(bedTransform.localPosition.x, bedTransform.localPosition.y, bedTransform.localPosition.z);
        currentBedScale = new Vector3(bedTransform.localScale.x, bedTransform.localScale.y, bedTransform.localScale.z);

        currentWolfPosition = new Vector3(wolfTransform.localPosition.x, wolfTransform.localPosition.y, wolfTransform.localPosition.z);
        currentWolfScale = new Vector3(wolfTransform.localScale.x, wolfTransform.localScale.y, wolfTransform.localScale.z);
    }

    private void RotateCoverBook(float angle)
    {
        bookAngle += rotationBookSpeed * Time.deltaTime * angle;
        bookAngle = Mathf.Clamp(bookAngle, 0, 180);
        bookFace.rotation = Quaternion.Euler(new Vector3(0, 0, bookAngle));
    }

    private void ChangeBedTransforms(Vector3 targetScale, Vector3 targetPostion, Vector3 rotateAngle, bool checkIfMoveBed)
    {
        if (checkIfMoveBed == false)
        {
            bedTransform.localScale = Vector3.Lerp(bedTransform.localScale, targetScale, Time.deltaTime * scaleSpeed);
            bedTransform.localPosition = Vector3.Lerp(bedTransform.localPosition, targetPostion, Time.deltaTime * positionSpeed);
        }
        else
        {
            if (bookAngle < 80)
            {
                bedTransform.localScale = Vector3.Lerp(bedTransform.localScale, targetScale, Time.deltaTime * scaleSpeed);
                bedTransform.localPosition = Vector3.Lerp(bedTransform.localPosition, currentBedPosition, Time.deltaTime * positionSpeed);
            }
        }

        bedTransform.Rotate(rotateAngle, rotationBedSpeed * Time.deltaTime, Space.Self);
    }
    private void ChangeWolfTransforms(Vector3 targetScale, Vector3 targetPostion, Vector3 rotateAngle)
    {
        wolfTransform.localScale = Vector3.Lerp(wolfTransform.localScale, targetScale, Time.deltaTime * scaleSpeed);
        wolfTransform.localPosition = Vector3.Lerp(wolfTransform.localPosition, targetPostion, Time.deltaTime * positionSpeed);
        wolfTransform.Rotate(rotateAngle, rotationBedSpeed * Time.deltaTime, Space.Self);
    }

    private void CheckActiveObjects()
    {
        if (bookAngle > 170f)
        {
            bedTransform.gameObject.SetActive(false);
            wolfTransform.gameObject.SetActive(false);
        }
        else
        {
            bedTransform.gameObject.SetActive(true);
            wolfTransform.gameObject.SetActive(true);
        }
    }
    private void CameraAnimate(Vector3 rotateAngle, float positionAngle)
    {
        Camera.main.transform.Rotate(rotateAngle, Time.deltaTime * 10f, Space.Self);
        Camera.main.transform.Translate(Vector3.up * positionAngle, Space.World);
        Camera.main.transform.Translate(Vector3.forward * positionAngle, Space.World);
    }

}

