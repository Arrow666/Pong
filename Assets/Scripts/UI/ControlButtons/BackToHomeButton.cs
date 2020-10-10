using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BackToHomeButton : MonoBehaviour
{
  public Button button;

  private void OnValidate()
  {
    button = GetComponent<Button>();
  }
}
