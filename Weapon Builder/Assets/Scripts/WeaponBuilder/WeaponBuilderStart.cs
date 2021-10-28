using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuilderStart : MonoBehaviour
{
    [SerializeField]
    private AttachmentSO startingAttachment;
    void Awake()
    {
        Attachment attachment = Instantiate(startingAttachment.attachmentPrefab, transform).GetComponent<Attachment>();
        attachment.CreateAttachmentPoints(startingAttachment);

        for (int i = 0; i < startingAttachment.AttachmentSlots.Count; i++)
        {
            attachment.attachmentSlots[i].attachmentCaliber = startingAttachment.AttachmentSlots[i].attachmentCaliber;
            attachment.attachmentSlots[i].attachmentType = startingAttachment.AttachmentSlots[i].attachmentType;
            attachment.attachmentSlots[i].attachmentPointOffset = startingAttachment.AttachmentSlots[i].attachmentPointOffset;
            attachment.attachmentSlots[i].attachmentOffset = startingAttachment.AttachmentSlots[i].attachmentOffset;
            attachment.attachmentSlots[i].WhiteList = startingAttachment.AttachmentSlots[i].WhiteList;
            attachment.attachmentSlots[i].BlackList = startingAttachment.AttachmentSlots[i].BlackList;
        }
        WeaponBuilderUI.instance.mainAttachnent = attachment;
        WeaponBuilderUI.SpawnImages();
    }
}
