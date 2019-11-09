using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExtraTools;

public class TemporarySceneSwitcher : Singleton<TemporarySceneSwitcher>
{
    [SerializeField]
    private List<GameObject> ignore = new List<GameObject>();
    [SerializeField]
    private List<GameObject> objectsToDisable = new List<GameObject>();

    private void CombatSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        SceneManager.sceneLoaded -= CombatSceneLoaded;
        SceneManager.SetActiveScene(scene);
    }
    private void CombatSceneUnloaded(Scene scene)
    {
        SceneManager.sceneUnloaded -= CombatSceneUnloaded;

        foreach (var obj in objectsToDisable)
            obj.SetActive(true);

        objectsToDisable.Clear();
    }

    public void SwitchToCombat()
    {
        SceneManager.GetActiveScene().GetRootGameObjects(objectsToDisable);

        foreach (var obj in ignore)
            objectsToDisable.Remove(obj);

        objectsToDisable.Remove(gameObject);

        foreach (GameObject obj in objectsToDisable)
            obj.SetActive(false);

        SceneManager.sceneLoaded += CombatSceneLoaded;
        SceneManager.LoadScene("Combat", LoadSceneMode.Additive);
    }

    public void GetBackFromCombat()
    {
        SceneManager.sceneUnloaded += CombatSceneUnloaded;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
