using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
  /// ボタンをクリックした時の処理
  public void OnClick() {
    SceneManager.LoadScene("game_mode");
  }
}
