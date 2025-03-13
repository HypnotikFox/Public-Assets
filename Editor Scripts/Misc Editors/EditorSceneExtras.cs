using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Editor
{
    public class EditorSceneExtras : MonoBehaviour
    {
        #region RESTART SCENE
        [MenuItem("Debugging Tools/Restart Current Scene #R")]
        private static void RestartCurrentScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        [MenuItem("Debugging Tools/Play Scene Zero")]
        private static void PlaySceneZero()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Debug.LogWarning("You already are on scene 0!");
                return;
            }

            LoadScene(0);
        }

        private static void LoadScene(int sceneIndex)
        {
            if (!EditorApplication.isPlaying) return;

            SceneManager.LoadScene(sceneIndex);
        }
        #endregion

        #region AUTO REFRESH
        [MenuItem("Debugging Tools/Auto Refresh")]
        static void AutoRefreshToggle()
        {
            var status = EditorPrefs.GetInt("kAutoRefresh");
            if (status == 1)
                EditorPrefs.SetInt("kAutoRefresh", 0);
            else
                EditorPrefs.SetInt("kAutoRefresh", 1);
        }

        [MenuItem("Debugging Tools/Auto Refresh", true)]
        static bool AutoRefreshToggleValidation()
        {
            var status = EditorPrefs.GetInt("kAutoRefresh");
            Menu.SetChecked("Debugging Tools/Auto Refresh", status == 1);
            return true;
        }
        #endregion

        #region MANUAL RECOMPILE
        [MenuItem("Debugging Tools/Manual Recompile")]
        private static void ManualRecompile()
        {
            // Force recompile scripts and refresh the Asset Database
            AssetDatabase.Refresh();
            EditorApplication.ExecuteMenuItem("Assets/Reimport All");

            Debug.Log("Manual recompile triggered.");
        }
        #endregion
    }
}
