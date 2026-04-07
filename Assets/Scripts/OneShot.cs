using UnityEngine;

public class OneShot : MonoBehaviour
{
    AudioSource src;
    private void Start()
    {
        src = GetComponent<AudioSource>();
        src.Play();
    }
}
