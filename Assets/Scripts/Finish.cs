using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject endScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            endScreen.SetActive(true);
        }
    }
}
