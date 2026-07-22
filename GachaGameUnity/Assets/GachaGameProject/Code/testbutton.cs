using UnityEngine;

public class testbutton : MonoBehaviour
{
    public void OnClick()
    {
        CharacterManager.Instance.CheckHaveCharacter();
    }

    public void OnClickSave()
    {
        //SaveManager.Instance.OnAutoSave();
    }
}
