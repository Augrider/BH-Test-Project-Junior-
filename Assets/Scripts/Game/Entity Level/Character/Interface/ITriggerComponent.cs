using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerComponent
{
    /// <summary>
    /// Event (ICharacter self, ICharacter other), invoked when other character was detected inside trigger
    /// </summary>
    event System.Action<ICharacter, ICharacter> OnTriggerDetected;

    void CmdToggleActive(bool value);
}
