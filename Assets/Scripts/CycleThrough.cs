using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class CycleThrough : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private float cycleTime = 2f;

    private void Start()
    {
        //StartCoroutine(CycleObjects());
        StartCoroutine(WaitingTime());
    }

    private IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(51);
        SceneManager.LoadScene("Bat flying");
    }

    private IEnumerator CycleObjects()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(true);
            yield return new WaitForSeconds(cycleTime);
        }
        SceneManager.LoadScene("Bat flying");
    }
}
