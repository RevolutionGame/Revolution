using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollidable {

    int MyDamage { get; set; }
    int YourDamage { get; set; }

    int ReciveDamage();

}
