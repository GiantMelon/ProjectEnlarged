using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 90;
    public PlatformerCharacter2D playerControl;

    public Vector2 dir;

    void Update()
    {
        if (playerControl.m_FacingRight)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            dir = Input.mousePosition - pos;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (angle > 90 || angle < -90)
            {
                playerControl.Flip();
            }
        }
        else if (!playerControl.m_FacingRight)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            dir = -Input.mousePosition + pos;
            var angle = -Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (angle > 90 || angle < -90)
            {
                playerControl.Flip();
            }
        }
    }
}
