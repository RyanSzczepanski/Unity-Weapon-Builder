using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attachment Database", menuName = "Assets/Weapons/Attachment Database")]
public class AttachmentDatabaseSO : ScriptableObject
{
    public List<AttachmentSO> attachments;
}
