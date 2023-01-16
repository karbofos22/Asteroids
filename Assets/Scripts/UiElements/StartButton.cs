using UnityEngine;
public class StartButton : MonoBehaviour
{
   public void GameStart() 
    {
        EventManager.SendStart();
    }
}
