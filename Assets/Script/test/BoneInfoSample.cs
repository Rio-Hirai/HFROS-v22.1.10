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
            { "Start",Color.black},  //  �X�^�[�g�ʒu
            { "Thumb",Color.red},       //  �e�w
            { "Index",Color.green},     //  �l�����w
            { "Middle",Color.blue},     //  ���w
            { "Ring", Color.cyan},      //  ��w
            { "Pinky",Color.magenta},   //  ���w
            { "Forearm",Color.yellow},  //  �O�r��
        };

        foreach (var bone in _skeleton.Bones)
        {

            //  Sphere�𐶐����{�[���Ɋ��蓖�Ă�
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = bone.Transform.position;
            sphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            sphere.transform.parent = bone.Transform;

            //  �w�P�ʂŐF��ς���
            var color = boneColor.FirstOrDefault(x => bone.Id.ToString().Contains(x.Key));
            sphere.GetComponent<Renderer>().material.color = color.Value;

            _spheres.Add(sphere);
        }
    }

    void Update()
    {
        //  �g���b�N���O�ꂽ��Sphere������
        foreach (var sphere in _spheres)
        {
            sphere.SetActive(_hand.IsTracked);
        }

    }
}