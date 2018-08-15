using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;

public class MenuManager : MonoBehaviour {

    public void QuitarJuego() {
        Application.Quit();
    }

    public void cargarEscenario(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
