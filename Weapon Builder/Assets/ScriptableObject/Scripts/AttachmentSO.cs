using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attachment", menuName = "Assets/Weapons/Attachments")]
public class AttachmentSO : ScriptableObject
{
    private bool ShowCaliber()
    {
        if (attachmentType == AttachmentType.Barrel ||
        attachmentType == AttachmentType.Magazine ||
        attachmentType == AttachmentType.Muzzle ||
        attachmentType == AttachmentType.Supressor)
            return true;
        else
            return false;
    }


    public GameObject attachmentPrefab;


    public AttachmentType attachmentType;

    public AttachmentCaliber attachmentCaliber;

    public float attachmentStart;

    public float attachmentEnd;

    public AttachmentStats attachmentStats;

    public List<AttachmentSlot> AttachmentSlots;
    
    public GameObject InstantateAttachment()
    {
        GameObject attachment = Instantiate(attachmentPrefab);
        SetAttachmentValues(attachment.GetComponent<Attachment>());
        return attachment;
    }

    public void SetAttachmentValues(Attachment attachment)
    {
        attachment.attachmentType = attachmentType;
        attachment.attachmentCaliber = attachmentCaliber;
        attachment.attachmentStats = attachmentStats;
        attachment.attachmentSlots = AttachmentSlots;
        
    }
}