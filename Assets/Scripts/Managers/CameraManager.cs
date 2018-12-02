using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera mainCam;
    public float spriteSize; // sprite size in pixels
    private float baseOrthographicSize;

    #region Singleton

    public static CameraManager instance;

    #endregion

    private void Awake()
    {
        instance = this;
        mainCam = this.GetComponent<Camera>();
        baseOrthographicSize = Screen.height / spriteSize / 2.0f;
        mainCam.orthographicSize = baseOrthographicSize;
	}

    public void KeepItemWithinCameraBounds(Transform transform)
    {
        Vector3 pos = mainCam.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.01f, 0.99f);
        pos.y = Mathf.Clamp(pos.y, 0.01f, 0.99f);
        transform.position = mainCam.ViewportToWorldPoint(pos);
    }
}
