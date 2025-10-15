using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] public string itext;
    [SerializeField] private AudioClip iclip;
    [SerializeField] public Material normal;
    private WindowTrigger wt;
    private TextMeshProUGUI UIText;
    private AudioSource source;

    public bool activated = false;

    private void Start()
    {
        UIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TextMeshProUGUI>();
        if (GetComponent<AudioSource>() != null)
        {
            source = GetComponent<AudioSource>();
            source.clip = iclip;
        }
        if (GetComponent<WindowTrigger>() != null)
        {
            wt = GetComponent<WindowTrigger>();
        }
    }

    public void Interact()
    {
        if (itext.Length > 0)
        {
            StartCoroutine(DisplayText());
        }

        if (iclip != null)
        {
            source.Play();
        }
        gameObject.GetComponent<MeshRenderer>().material = normal;
        if (wt != null)
            wt.Activate();
        activated = true;
    }

    private IEnumerator DisplayText()
    {
        UIText.text = itext;
        yield return new WaitForSeconds(5);
        if (UIText.text == itext)
            UIText.text = "";
    }
}
