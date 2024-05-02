using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelSphere : MonoBehaviour
{
    public bool isLastLevel = false;

    private RocketPointsCounter[] rocketPointsCounterScripts;
    private bool run = true;

    private void Start()
    {
        rocketPointsCounterScripts = GameObject.FindObjectsOfType<RocketPointsCounter>();
        if (rocketPointsCounterScripts.Length != 1)
        {
            run = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(run)
        {
            rocketPointsCounterScripts[0].SumPointsToTotalScore();
        }
        else
        {
            Debug.LogWarning("Total points were not added to GameManager, because none or multiple instances of RocketPointsCounter script were found");
        }
        if (isLastLevel)
        {
            SceneManager.LoadScene("Success");
        }
        else
        {
            SceneManager.LoadScene("level2");
        }
        Destroy(gameObject);
    }
}
