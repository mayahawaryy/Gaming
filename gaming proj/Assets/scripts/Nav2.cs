using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Nav2 : MonoBehaviour
{
    // Start is called before the first frame update
   public void Loadscene(int i)
    {
      SceneManager.LoadScene(i);
    }   
}
