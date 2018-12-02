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
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = mainCam.ViewportToWorldPoint(pos);
    }
}
