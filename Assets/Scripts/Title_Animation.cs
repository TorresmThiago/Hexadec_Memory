using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Title_Animation : MonoBehaviour
{

  public Camera MainCamera;
  public GameObject Wave;
  public GameObject Audio;
  public GameObject Delta;
  public float time;
  private Color bgColor;
  private readonly bool onMenu;

  public void Awake()
  {
    GameObject spawned = GameObject.FindGameObjectWithTag("Audio");
    if (spawned == null)
      Instantiate(Audio);
  }

  void Start()
  {
    StartCoroutine(ColorShifter());
    if (SceneManager.GetActiveScene().buildIndex == 3)
    {
      float deltaTime = PlayerPrefs.GetFloat("DeltaTime");
      Delta.GetComponent<Text>().text = "" + Mathf.FloorToInt(deltaTime) + " segundos";
    }
  }

  IEnumerator ColorShifter()
  {
    if (SceneManager.GetActiveScene().buildIndex == 0)
    {
      yield return new WaitForSeconds(time);
      Instantiate(Wave);
    }

    while (true)
    {
      bgColor = new Color(Random.value, Random.value, Random.value, 0.5f);

      float time = 0.0f;
      Color currentColor = MainCamera.backgroundColor;

      while (time < 1.0f)
      {
        MainCamera.backgroundColor = Color.Lerp(currentColor, bgColor, time);
        yield return new WaitForSeconds(0.0123f);
        time += Time.deltaTime;
      }
    }
  }
}
