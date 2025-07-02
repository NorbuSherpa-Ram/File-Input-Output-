// 7/2/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using File_Input_Output;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionHandler : MonoBehaviour
{
    private SaveManager saveManager;

    private void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>();
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
       // saveManager.SaveSceneData(scene.name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      //  saveManager.LoadSceneData(scene.name);
    }

    private void OnDestroy()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
