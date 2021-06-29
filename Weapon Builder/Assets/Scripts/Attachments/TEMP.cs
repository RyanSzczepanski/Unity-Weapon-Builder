using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP : MonoBehaviour
{
    public GameObject attachmentAddition;
    public GameObject attachmentOriginal;
    public int attachmentSlotIndex;

    public void Call()
    {
        //Debug.Log(Attachment.CheckValidAttachmentSlot(attachmentAddition, attachmentOriginal));
        Attachment.AddAttachment(attachmentAddition, attachmentOriginal);

        //Debug.Log(Attachment.CheckValidAttachmentSlot(attachmentAddition, attachmentOriginal.attachmentSlots[attachmentSlotIndex]));
        //Attachment.AddAttachment(attachmentAddition, attachmentOriginal.attachmentSlots[attachmentSlotIndex]);
    }
}
