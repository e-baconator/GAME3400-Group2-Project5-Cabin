using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Interaction : MonoBehaviour
{
    private Interactable current;
    [SerializeField] private Material highlight;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (current != null) 
                current.Interact();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject g = other.gameObject;
        Interactable c = g.GetComponent<Interactable>();
        if(c != null && !c.activated)
        {
            current = c;
            g.GetComponent<MeshRenderer>().material = highlight;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject g = other.gameObject;
        Interactable c = g.GetComponent<Interactable>();
        if (c != null)
        {
            current = null;
            g.GetComponent<MeshRenderer>().material = c.normal;
        }
    }
}
