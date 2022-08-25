using Niantic.ARDK.AR.Awareness;
using Niantic.ARDK.AR.Awareness.Semantics;
using Niantic.ARDK.Extensions;
using Niantic.ARDK.Utilities.Input.Legacy;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Semantics : MonoBehaviour
{

    ISemanticBuffer _currentBuffer;

    public ARSemanticSegmentationManager _semanticManager;

    public Camera _camera;


    [SerializeField]
    TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _semanticManager.SemanticBufferUpdated += OnSemanticsBufferUpdated;
    }


    private void OnSemanticsBufferUpdated(ContextAwarenessStreamUpdatedArgs<ISemanticBuffer> args)
    {
        //get current buffer
        _currentBuffer = args.Sender.AwarenessBuffer;
    }









    // Update is called once per frame
    void Update()
    {

        if(PlatformAgnosticInput.touchCount <= 0) { return; }

        var touch = PlatformAgnosticInput.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            //print("Num of channels available " + _semanticManager.SemanticBufferProcessor.ChannelCount);
            //foreach(var c in _semanticManager.SemanticBufferProcessor.Channels) print(c);

            int x = (int)touch.position.x;
            int y = (int)touch.position.y;


            //int[] channelsInPixel = _semanticManager.SemanticBufferProcessor.GetChannelIndicesAt(x, y);
            //foreach (var i in channelsInPixel) _text.text = i.ToString();


            string[] channelsNamesInPixel = _semanticManager.SemanticBufferProcessor.GetChannelNamesAt(x, y);
            foreach(var i in channelsNamesInPixel) _text.text = i;

        }



        
    }
}
