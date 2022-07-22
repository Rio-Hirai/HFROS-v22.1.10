using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoneInfoSample : MonoBehaviour
{
    OVRHand _hand;
    OVRSkeleton _skeleton;
    List<GameObject> _spheres = new List<GameObject>();

    void Start()
    {
        _hand = GetComponent<OVRHand>();
        _skeleton = GetComponent<OVRSkeleton>();

        var boneColor = new Dictionary<string, Color>()
        {
            { "Start",Color.black},  //  スタート位置
            { "Thumb",Color.red},       //  親指
            { "Index",Color.green},     //  人差し指
            { "Middle",Color.blue},     //  中指
            { "Ring", Color.cyan},      //  薬指
            { "Pinky",Color.magenta},   //  小指
            { "Forearm",Color.yellow},  //  前腕部
        };

        foreach (var bone in _skeleton.Bones)
        {

            //  Sphereを生成しボーンに割り当てる
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = bone.Transform.position;
            sphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            sphere.transform.parent = bone.Transform;

            //  指単位で色を変える
            var color = boneColor.FirstOrDefault(x => bone.Id.ToString().Contains(x.Key));
            sphere.GetComponent<Renderer>().material.color = color.Value;

            _spheres.Add(sphere);
        }
    }

    void Update()
    {
        //  トラックが外れたらSphereを消す
        foreach (var sphere in _spheres)
        {
            sphere.SetActive(_hand.IsTracked);
        }

    }
}