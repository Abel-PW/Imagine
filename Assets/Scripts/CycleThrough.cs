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
        StartCoroutine(CycleObjects());
    }



    private IEnumerator CycleObjects()
    {
        int index = 0;
        while (true)
        {
            // Deactivate all objects
            foreach (var obj in objects)
            {
                obj.SetActive(false);
            }
            // Activate the current object
            if (objects.Count > 0)
            {
                objects[index].SetActive(true);
            }
            // Wait for the specified cycle time
            yield return new WaitForSeconds(cycleTime);
            // Move to the next index
            index = (index + 1) % objects.Count;
            if (index > 6)
                SceneManager.LoadScene("Bat flying");
        }
    }
}
