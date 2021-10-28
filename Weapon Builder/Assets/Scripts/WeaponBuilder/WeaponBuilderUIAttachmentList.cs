using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBuilderUIAttachmentList : MonoBehaviour
{
    public static WeaponBuilderUIAttachmentList instance;
    public GameObject weaponAttachmentListing;
    public Transform weaponAttachmentListingContainer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public static GameObject InstantiateRemoveAttachmentListing()
    {
        GameObject _newListing = Instantiate(instance.weaponAttachmentListing, instance.weaponAttachmentListingContainer.transform);
        _newListing.GetComponent<TextMeshProUGUI>().text = "None";

        //Dumb shit I need to do to update content size fitter
        LayoutRebuilder.ForceRebuildLayoutImmediate(_newListing.transform.GetComponentInParent<RectTransform>());

        return _newListing;
    }

    public static GameObject InstantiateAttachmentListing(AttachmentSO _attachment)
    {
        GameObject _newListing = Instantiate(instance.weaponAttachmentListing, instance.weaponAttachmentListingContainer.transform);
        _newListing.GetComponent<TextMeshProUGUI>().text = _attachment.name;

        //Dumb shit I need to do to update content size fitter
        LayoutRebuilder.ForceRebuildLayoutImmediate(_newListing.transform.GetComponentInParent<RectTransform>());

        return _newListing;
    }

    public static void ClearAttachmentList()
    {
        GameObject _currentAttachmentListing;
        for (int i = instance.weaponAttachmentListingContainer.transform.childCount-1; i >= 0; i--)
        {
            _currentAttachmentListing = instance.weaponAttachmentListingContainer.transform.GetChild(i).gameObject;
            Destroy(_currentAttachmentListing);
        }
    }
}
