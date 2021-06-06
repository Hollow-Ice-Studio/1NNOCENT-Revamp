using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace innocent {
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] GameObject PauseHud, ConfirmRestartHud, ConfirmReturnMainScreenHud, ConfigHud;
        [SerializeField] KeyCode Key = KeyCode.P;
        [SerializeField] string MainMenuSceneName = "MainScreen";
        [SerializeField] AudioSource interactionAudioSource;
        void Update()
        {
            if (Input.GetKeyDown(Key) || Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale > 0)
                    Pause();
                else
                    UnPause();
                ConfirmRestartHud.SetActive(false);
            }
        }

        public void Pause()
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PauseHud.SetActive(true);
        }
        public void UnPause()
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PauseHud.SetActive(false);
        }
        public void setConfigHUD(bool isActive)
        {
            ConfigHud.SetActive(isActive);
        }
        public void SetAudioListenerVolume(Scrollbar scrollbar)
        {
            AudioListener.volume = scrollbar.value;
        }
        public void tryRestartScene()
        {
            ConfirmRestartHud.SetActive(true);
        }
        public void cancelRestartScene()
        {
            ConfirmRestartHud.SetActive(false);
        }
        public void tryReturnMainScreenScene()
        {
            ConfirmReturnMainScreenHud.SetActive(true);
        }
        public void cancelMainScreenScene()
        {
            ConfirmReturnMainScreenHud.SetActive(false);
        }
        public void restartScene()
        {
            PlayerPrefs.DeleteAll();
            UnPause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void restartLastCheckPoint()
        {
            UnPause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void returnToMainMenu()
        {
            PlayerPrefs.DeleteAll();
            Time.timeScale = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(MainMenuSceneName);
        }
        public void PlayInteractionSound()
        {
            interactionAudioSource.Play();
        }
    }
}