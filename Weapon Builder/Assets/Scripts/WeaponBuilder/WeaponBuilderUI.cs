using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponBuilderUI : MonoBehaviour
{
    public static WeaponBuilderUI instance;
    //rename variable lol vv
    public GameObject slot;
    public Transform slotParrent;
    //rename variable, possibly baseAttachment rather than mainAttachment vv
    public Attachment mainAttachnent;
    private static AttachmentSlot[] allAttachmentSlots;
    private static List<GameObject> allAttachmentSlotImages;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        
    }

    void Update()
    {
        if (allAttachmentSlots == null) { return; }
        for (int i = 0; i < allAttachmentSlotImages.Count; i++)
        {
            
            allAttachmentSlotImages[i].GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(allAttachmentSlots[i].attachmentSlotObj.transform.position + allAttachmentSlots[i].attachmentPointOffset);
        }
    }

    public static void SpawnImages()
    {
        if (allAttachmentSlotImages != null)
        {
            for (int i = 0; i < allAttachmentSlotImages.Count; i++)
            {
                Destroy(allAttachmentSlotImages[i]);
            }
        }
        allAttachmentSlotImages = new List<GameObject>(GetAllAttachmentsSlotsLength(instance.mainAttachnent));
        allAttachmentSlots = GetAllAttachments(instance.mainAttachnent).ToArray();
    }

    public static GameObject InstantiateSlotImage(Attachment _attachment, int _attachmentSlotIndex)
    {
        GameObject _newSlotImage = Instantiate(instance.slot, instance.slotParrent);
        _newSlotImage.transform.position = Camera.main.WorldToScreenPoint(_attachment.attachmentSlots[_attachmentSlotIndex].attachmentSlotObj.transform.position) + _attachment.attachmentSlots[_attachmentSlotIndex].attachmentPointOffset;
        _newSlotImage.GetComponent<WeaponBuilderUISlot>().attachment = _attachment;
        _newSlotImage.GetComponent<WeaponBuilderUISlot>().attachmentSlotIndex = _attachmentSlotIndex;
        return _newSlotImage;
    }

    //Hmm might need to change array type to Attachment or GameObject.
    private static List<AttachmentSlot> GetAllAttachments(Attachment _mainAttachment)
    {
        List<AttachmentSlot> _allAttachments = new List<AttachmentSlot>();
        for (int i = 0; i < _mainAttachment.attachmentSlots.Count; i++)
        {
            _allAttachments.Add(_mainAttachment.attachmentSlots[i]);
            allAttachmentSlotImages.Add(InstantiateSlotImage(_mainAttachment, i));
            if (_mainAttachment.attachmentSlots[i].attachmentInSlot)
            {
                _allAttachments.AddRange(GetAllAttachments(_mainAttachment.attachmentSlots[i].attachmentInSlot.GetComponent<Attachment>()));
            }
        }
        return _allAttachments;
    }

    //Crackhead energy repeating the same function but slightly stripped because I needed to use this function to set an array but i also used this function to get the size of the array
    //I did this at 2 am so don't get to mad when Im finaly looking at this rationaly
    private static int GetAllAttachmentsSlotsLength(Attachment _mainAttachment)
    {
        List<AttachmentSlot> _allAttachments = new List<AttachmentSlot>();
        int _allAttachmentsCount = 0;
        for (int i = 0; i < _mainAttachment.attachmentSlots.Count; i++)
        {
            _allAttachments.Add(_mainAttachment.attachmentSlots[i]);
            _allAttachmentsCount = _allAttachments.Count;
            if (_mainAttachment.attachmentSlots[i].attachmentInSlot)
            {
                _allAttachmentsCount += GetAllAttachmentsSlotsLength(_mainAttachment.attachmentSlots[i].attachmentInSlot.GetComponent<Attachment>());
            }
        }
        return _allAttachmentsCount;
    }

    //public static void EquipAttachment(AttachmentSO _attachment, int _attachmentSlot)
    //{
    //    instance.mainAttachnent.attachmentSlots[_attachmentSlot].attachmentInSlot = Instantiate(_attachment.attachmentGO, allAttachmentSlots[_attachmentSlot].attachmentSlotObj.transform);
    //}
}

