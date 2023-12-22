using UnityEngine;

public class DeactivateChildObjects : MonoBehaviour
{
    [SerializeField] private GameObject parentOne;
    [SerializeField] private GameObject parentTwo;
    [SerializeField] private GameObject parentThree;

    // This method can be called to deactivate the first child of each parent GameObject
    public void DeactivateChildren()
    {
        if (parentOne != null && parentOne.transform.childCount > 0)
            parentOne.transform.GetChild(0).gameObject.SetActive(false);

        if (parentTwo != null && parentTwo.transform.childCount > 0)
            parentTwo.transform.GetChild(0).gameObject.SetActive(false);

        if (parentThree != null && parentThree.transform.childCount > 0)
            parentThree.transform.GetChild(0).gameObject.SetActive(false);
    }
}

