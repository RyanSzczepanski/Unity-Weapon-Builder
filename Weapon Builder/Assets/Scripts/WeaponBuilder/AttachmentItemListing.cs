using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Rename this class its fucking horrible
public class AttachmentItemListing : MonoBehaviour, IPointerClickHandler
{
    public WeaponBuilderUISlot weaponBuilderUISlot;
    public AttachmentSO attachment;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (attachment == null) 
        {
            weaponBuilderUISlot.attachment.RemoveAttachment(weaponBuilderUISlot.attachmentSlotIndex);
            return;
        }
        weaponBuilderUISlot.attachment.AddAttachment(attachment, weaponBuilderUISlot.attachmentSlotIndex);
    }
}
