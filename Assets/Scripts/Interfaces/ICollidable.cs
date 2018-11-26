using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollidable {

    int myDamage { get; set; }
    int yourDamage { get; set; }

    int myClass { get; set; }
    int yourClass { get; set; }

    int damageToMe();


}
