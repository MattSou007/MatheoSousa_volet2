using UnityEngine;
using UnityEngine.UI;

public class GestionJeu : MonoBehaviour
{
    public static GameObject unique;

    // audio
    AudioSource auSo;
    public AudioClip select;
    public AudioClip win;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       auSo = GetComponent<AudioSource>(); 
    }

    void Awake()
    {
        if (unique == null)
        {
            unique = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void onSelect()
    {
        auSo.PlayOneShot(select);
    }

    public void onWin()
    {
        auSo.PlayOneShot(win);
    }
}
