using System.Collections;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string itext;
    [SerializeField] private AudioClip iclip;
    [SerializeField] public Material normal;
    private TextMeshProUGUI UIText;

    private AudioSource source;

    private void Start()
    {
        UIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TextMeshProUGUI>();
        source = GetComponent<AudioSource>();
        source.clip = iclip;
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
    }

    private IEnumerator DisplayText()
    {
        UIText.text = itext;
        yield return new WaitForSeconds(5);
        UIText.text = "";
    }
}
