﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    public GameObject animationObj;

    public void LoadSceneWithTransition(string scene)
    {
        Time.timeScale = 1f;
        StartCoroutine(SwapWithAnimation(scene, 1f));
    }
    IEnumerator SwapWithAnimation(string scene, float transitionSpeed)
    {
        if (animationObj != null)
        {
            animationObj.GetComponent<Animator>().SetTrigger("Start");
            yield return new WaitForSeconds(transitionSpeed);
            SceneManager.LoadScene(scene);
        }
        else
        {
            if (GameObject.Find("TransitionPrefab") != null)
            {
                GameObject.Find("TransitionPrefab").GetComponent<Animator>().SetTrigger("Start");
                yield return new WaitForSeconds(transitionSpeed);
                SceneManager.LoadScene(scene);
            }
            else
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
    public void QuitGameWithAnimation()
    {
        StartCoroutine(QuitGame(1f));
    }

    IEnumerator QuitGame(float transitionSpeed)
    {
        if (animationObj != null)
        {
            animationObj.GetComponent<Animator>().SetTrigger("Start");
            yield return new WaitForSeconds(transitionSpeed);
            Application.Quit();
        }
        else
        {
            if (GameObject.Find("TransitionPrefab") != null)
            {
                GameObject.Find("TransitionPrefab").GetComponent<Animator>().SetTrigger("Start");
                yield return new WaitForSeconds(transitionSpeed);
                Application.Quit();
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
