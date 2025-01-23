using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public CameraMovement cameraMove;
    public int roomIndex;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.Player)) {
            cameraMove.SetMove(roomIndex);
        }
    }
}
