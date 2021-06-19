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
}
