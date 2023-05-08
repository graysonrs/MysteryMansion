using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour
{
    public CheckKeys keys;
    public Image arrowImage;
    public Camera uiCamera;

    private Transform target;

    void Update()
    {
        target = keys.GetDestination();
        // Debug.Log(target);
        Vector3 camPos = Camera.main.transform.position;
        camPos.z = 0f;
        // Calculate direction vector between target and camera
        Vector3 dir = (target.position - camPos).normalized;
        // Debug.Log(dir);

        float angle = GetAngleFromVectorFloat(dir);
        arrowImage.rectTransform.localEulerAngles = new Vector3(0, 0, angle);

        Vector3 targetPosScrnPnt = Camera.main.WorldToScreenPoint(target.position);
        bool isOffScreen = targetPosScrnPnt.x <= 0 || targetPosScrnPnt.x >= Screen.width || targetPosScrnPnt.y <= 0 || targetPosScrnPnt.y >= Screen.height;
        // Debug.Log(isOffScreen + " " + targetPosScrnPnt);
        if (isOffScreen) {
            Vector3 capTargetScrnPos = targetPosScrnPnt;
            if (capTargetScrnPos.x <= 0) capTargetScrnPos.x = 0;
            if (capTargetScrnPos.x >= Screen.width) capTargetScrnPos.x = Screen.width;
            if (capTargetScrnPos.y <= 0) capTargetScrnPos.y = 0;
            if (capTargetScrnPos.y >= Screen.height) capTargetScrnPos.x = Screen.height;

            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(capTargetScrnPos);
            arrowImage.rectTransform.position = pointerWorldPosition;
            arrowImage.rectTransform.localPosition = new Vector3(arrowImage.rectTransform.localPosition.x, arrowImage.rectTransform.localPosition.y, 0f);
        }
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        if (angle < 0) {
            angle += 360;
        }
        return angle;
    }
}