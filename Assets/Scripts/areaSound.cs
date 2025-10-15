using UnityEngine;

public class areaSound : MonoBehaviour
{
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
