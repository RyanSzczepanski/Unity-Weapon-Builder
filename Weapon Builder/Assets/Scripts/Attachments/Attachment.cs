using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[System.Serializable]
public class AttachmentSlot
{
    public AttachmentType attachmentType;
    public AttachmentCaliber attachmentCaliber;
    //Add Bool for if it is vital

    public GameObject attachmentSlotObj;
    public Vector3 attachmentPointOffset;
    //Hmm might need to change type to Attachment
    public GameObject attachmentInSlot;
}

public class Attachment : MonoBehaviour
{
    public AttachmentType attachmentType;
    public AttachmentCaliber attachmentCaliber;

    public AttachmentSlot[] attachmentSlots;

    public AttachmentStats weaponStats;

    public static void AddAttachment(GameObject _attachmentAdditionGO, GameObject _attachmentBaseGO)
    {
        Attachment _attachmentBase;
        Attachment _attachmentAddition;

        if (_attachmentBaseGO.TryGetComponent<Attachment>(out _attachmentBase) && _attachmentAdditionGO.TryGetComponent<Attachment>(out _attachmentAddition))
        {   //GameObjects have attachment component
            AttachmentSlot[] _validAttachments;
            if (FindValidAttachmentSlots(_attachmentBase, _attachmentAddition, out _validAttachments))
            {   //Found minimum 1 valid attachment slot
                _validAttachments[0].attachmentInSlot = Instantiate(_attachmentAdditionGO, _validAttachments[0].attachmentSlotObj.transform);
            }
            else
            {   //No valid attachment slots found
                
            }
        }
        else
        {   //Gameobject Attempting to be added to the weapon is not an attachment
            
        }
    }

    public static void AddAttachment(Attachment _attachment, AttachmentSlot _attachmentSlot)
    { 
        if (CheckValidAttachmentSlot(_attachment, _attachmentSlot))
        {   //Attachment Valid
            //TODO: Create attachment and place on gun

        }
        else
        {   //Attachment Invalid

        }
    }

    public static bool FindValidAttachmentSlots(Attachment _attachmentBase, Attachment _attachmentAddition, out AttachmentSlot[] _validAttachmentSlots)
    {
        List<AttachmentSlot> _validAttachmentSlotsList = new List<AttachmentSlot>();
        foreach (AttachmentSlot _slot in _attachmentBase.attachmentSlots)
        {
            if (_slot.attachmentInSlot != null)
            {   //If there is an attachment equiped check the attachments attachment slots
                AttachmentSlot[] _attachmentSlotsSubArray;
                FindValidAttachmentSlots(_slot.attachmentInSlot.GetComponent<Attachment>(), _attachmentAddition, out _attachmentSlotsSubArray);
                _validAttachmentSlotsList.AddRange(_attachmentSlotsSubArray);
            }
            if (CheckValidAttachmentSlot(_attachmentAddition, _slot))
            {   //If the slot is compatible with the attachment add to the valid slots list
                _validAttachmentSlotsList.Add(_slot);
            }
        }
        _validAttachmentSlots = _validAttachmentSlotsList.ToArray();
        
        if (_validAttachmentSlots.Length != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CheckValidAttachmentSlot(Attachment _attachment, AttachmentSlot _attachmentSlot)
    {
        if (_attachment.attachmentType == _attachmentSlot.attachmentType && _attachment.attachmentCaliber == _attachmentSlot.attachmentCaliber && _attachmentSlot.attachmentInSlot == null)
        {   //Attachment type and caliber match aswell as the slot is not ocupied 
            //TODO: Add override whitelist and blacklist attachments
            //TODO: Allow multiple calibers
            //TODO: Implement more indepth rail system
            return true;
        }   
        return false;
    }
}
