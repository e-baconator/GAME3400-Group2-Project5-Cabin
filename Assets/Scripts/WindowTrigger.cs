using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    [SerializeField] private GameObject openWindow;
    [SerializeField] private GameObject closedWindow;
    [SerializeField] private GameObject spooky;

    public void Activate()
    {
        openWindow.transform.localPosition = closedWindow.transform.localPosition;
        openWindow.transform.localScale = closedWindow.transform.localScale;
        openWindow.transform.rotation = closedWindow.transform.rotation;
        spooky.GetComponent<AudioSource>().Play();
        spooky.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -8);
    }
}
