using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private Interact_Distance ID = Interact_Distance.GetInsance();
    private inventory_controller invC = inventory_controller.getInstance();
    private scene_controller sceneC = scene_controller.getInstance();
    [SerializeField] private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        string SItem = invC.selectedItem();
        if (ID.checkDistance(5, gameObject))
        {
            if (SItem != null)
            {
                if (SItem == "magnet image")
                {
                    myAudioSource.Play();
                    invC.useItem();
                }

            }
        }
    }
}
