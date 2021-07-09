using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Transform Container;
    public GameObject Panel;
    public Attachment attachmentOriginal;
    public AttachmentSlot[] attachments;

    void Start()
    {
        Attachment.FindAllAttachmentSlots(attachmentOriginal, out attachments);
        foreach (AttachmentSlot slot in attachments) 
        {
             GameObject _panel = Instantiate(Panel, Container);
            _panel.transform.GetChild(0).GetComponent<Text>().text = slot.attachmentSlotObj.name;
        }
    }
}
