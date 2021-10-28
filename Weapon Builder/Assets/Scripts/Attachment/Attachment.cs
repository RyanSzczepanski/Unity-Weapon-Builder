using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[System.Serializable]
public class AttachmentSlot
{
    private bool ShowCaliber()
    {
        if(attachmentType == AttachmentType.Barrel ||
        attachmentType == AttachmentType.Magazine ||
        attachmentType == AttachmentType.Muzzle ||
        attachmentType == AttachmentType.Supressor)
            return true;
        else
            return false;
    }

    public AttachmentType attachmentType;

    public AttachmentCaliber attachmentCaliber = 0;

    //Slot Specific
    public List<AttachmentSO> WhiteList;

    //Universal To Gun
    public List<AttachmentSO> BlackList;

    public Vector3 attachmentPointOffset;

    public Vector3 attachmentOffset;

    public float railStart;

    public float railEnd;

    public GameObject attachmentSlotObj;

    public GameObject attachmentInSlot;    
}

public class Attachment : MonoBehaviour
{
    public float attachmentStart;
    public float attachmentEnd;

    public AttachmentType attachmentType;
    public AttachmentCaliber attachmentCaliber;

    public List<AttachmentSlot> attachmentSlots;

    public AttachmentStats attachmentStats;

    public void CreateAttachmentPoints(AttachmentSO attachmentSO)
    {
        SetAttachmentValues(attachmentSO);
        for (int i = 0; i < attachmentSlots.Count; i++)
        {
            GameObject newAttachmentSlot = new GameObject($"mod_{attachmentSlots[i].attachmentType.ToString().ToLower()}");
            newAttachmentSlot.transform.parent = transform;
            newAttachmentSlot.transform.localScale = new Vector3(1, 1, 1);
            newAttachmentSlot.transform.localEulerAngles = new Vector3(0, 0, 0);
            newAttachmentSlot.transform.localPosition = attachmentSlots[i].attachmentOffset;
            attachmentSlots[i].attachmentSlotObj = newAttachmentSlot;
        }
    }

    public void SetAttachmentValues(AttachmentSO attachmentSO)
    {
        attachmentType = attachmentSO.attachmentType;
        attachmentCaliber = attachmentSO.attachmentCaliber;
        attachmentStats = attachmentSO.attachmentStats;
        attachmentSlots.Clear();
        attachmentSlots.Capacity = attachmentSO.AttachmentSlots.Count;
        attachmentSlots.AddRange(attachmentSO.AttachmentSlots);
    }

    public static bool CheckValidAttachment(AttachmentSO _attachment, AttachmentSlot _attachmentSlot)
    {
        //If there is no given attachment just return false
        if (!_attachment) { return false; }
        if ((_attachment.attachmentType != _attachmentSlot.attachmentType || _attachment.attachmentCaliber != _attachmentSlot.attachmentCaliber || _attachmentSlot.BlackList.Contains(_attachment)) && !_attachmentSlot.WhiteList.Contains(_attachment))
        {
            Debug.Log($"Invalid Attachment"); 
            return false;
        }

        return true;
    }

    //TODO: Take in attachment instead of attachmentSO so that you can add an attachment that is already in existance
    public void AddAttachment(AttachmentSO _attachmentSO, int _attachmentSlotIndex)
    {
        //Error when attachment not valid
        if (!_attachmentSO) { return; }
        if (CheckValidAttachment(_attachmentSO, attachmentSlots[_attachmentSlotIndex]))
        {
            if (attachmentSlots[_attachmentSlotIndex].attachmentInSlot)
            {
                //TODO: Call remove attachment function to allow inventory use
                Destroy(attachmentSlots[_attachmentSlotIndex].attachmentInSlot);
            }
            attachmentSlots[_attachmentSlotIndex].attachmentInSlot = Instantiate(_attachmentSO.attachmentPrefab, attachmentSlots[_attachmentSlotIndex].attachmentSlotObj.transform);

            attachmentSlots[_attachmentSlotIndex].attachmentInSlot.GetComponent<Attachment>().CreateAttachmentPoints(_attachmentSO);
            WeaponBuilderUI.SpawnImages();
        }
    }
    public void RemoveAttachment(int _attachmentSlotIndex)
    {
        Destroy(attachmentSlots[_attachmentSlotIndex].attachmentInSlot);
        attachmentSlots[_attachmentSlotIndex].attachmentInSlot = null;
        WeaponBuilderUI.SpawnImages();
    }
}
