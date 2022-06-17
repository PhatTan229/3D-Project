using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PersonState
{
    Single,
    Marriage
}

public class Person
{
    public string name;
    public int age;
    public string[] pets;
    public PersonState state = PersonState.Single;
}

public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("TheInvasion");
    }
}
