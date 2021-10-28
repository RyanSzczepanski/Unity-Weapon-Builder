using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Think about renaming the class better, possibly WeaponBuilderAttachmentSlot
public class WeaponBuilderUISlot : MonoBehaviour, IPointerClickHandler
{
    public Attachment attachment;
    public int attachmentSlotIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        WeaponBuilderUIAttachmentList.ClearAttachmentList();
        for (int i = 0; i < CompleteAttachmentList.attachmentsDatabse.attachments.Count; i++)
        {
            if (i == 0)
            {
                GameObject _newAttachmentListing = WeaponBuilderUIAttachmentList.InstantiateRemoveAttachmentListing();
                _newAttachmentListing.GetComponent<AttachmentItemListing>().weaponBuilderUISlot = this;
            }

            if (attachment.attachmentSlots[attachmentSlotIndex].WhiteList.Contains(CompleteAttachmentList.attachmentsDatabse.attachments[i]) || (attachment.attachmentSlots[attachmentSlotIndex].attachmentType == CompleteAttachmentList.attachmentsDatabse.attachments[i].attachmentType && attachment.attachmentSlots[attachmentSlotIndex].attachmentCaliber == CompleteAttachmentList.attachmentsDatabse.attachments[i].attachmentCaliber))
            {
                GameObject _newAttachmentListing = WeaponBuilderUIAttachmentList.InstantiateAttachmentListing(CompleteAttachmentList.attachmentsDatabse.attachments[i]);
                _newAttachmentListing.GetComponent<AttachmentItemListing>().weaponBuilderUISlot = this;
                _newAttachmentListing.GetComponent<AttachmentItemListing>().attachment = CompleteAttachmentList.attachmentsDatabse.attachments[i];
            }
        }
    }
}
