[System.Serializable]
public class AttachmentStats
{
    public float ergonomics;
    public float recoilVertical;
    public float recoilHorizontal;
    public float weight;
}

public enum AttachmentCaliber
{
    NA,
    C556x45,
    C545x39,
    C762x39,
}

public enum AttachmentType
{
    Barrel,
    Muzzle,
    Supressor,
    GasBlock,
    Handgaurd,
    LowerReciever,
    UpperReciever,
    PistolGrip,
    Stock,
    Magazine,
    UnderBarrelGrip,
    TacticalDevice,
    ChargingHandle,
    Optic,
}