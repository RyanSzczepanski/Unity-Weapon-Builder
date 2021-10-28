using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteAttachmentList : MonoBehaviour
{
    public static CompleteAttachmentList instance;
    public static AttachmentDatabaseSO attachmentsDatabse;
    public AttachmentDatabaseSO _entireAttachmentList;
    private void Awake()
    {
        instance = this;
        attachmentsDatabse = _entireAttachmentList;
    }
}
