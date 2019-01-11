using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour

{
    ////////////////////////////////////////////////for first window
    public Text avgFPS;
    public Text avgMS;
    public Text currentFrame;
   // public Text totalFPS;
   // public Text totalMS;
    private float deltaTime = 0.0f;
    public float fps;
    public float msec;
    private int frames = 0;
    private int _tenthFrame = 0;
    private float tempFPS = 0;
    private float tempMS = 0;
    public float FPS;
    public float MS;

	public int frameToStart = 100;
	public int framesToEnd = 1000;
    [SerializeField] private int effectDelay = 50;
    [SerializeField]private int _firstTempDelay, _secondTempDelay, _thirdTempDelay, _fourthTemDelay;

   
    ////////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////////////Pre-defined Scene result
    [SerializeField] private Text[] effectText;
     string[] effects;
     [SerializeField] private GameObject preDefinedSceneWindow;
     [SerializeField] private GameObject lastEffectStart;
     [SerializeField] private GameObject lastEffectEnd;
     //[SerializeField] private bool _lastEffect = false;
     [SerializeField] private bool _firstEffectStart = false, _firstEffectEnd = false, _secondEffectStart = false, _secondEffectEnd = false,
     _thirdEffectStart = false, _thirdEffectEnd = false, _fourthEffectStart = false, _fourthEffectEnd = false;
     [SerializeField] private Text totalAvg;

     /////////////////////////////////////////////first effect FPS:
    public Text firstEffectMin, secondEffectMin, thirdEffectMin, fourthEffectMin, totalSceneMin;
    public Text firstEffectMax, secondEffectMax, thirdEffectMax, fourthEffectMax, totalSceneMax;
    public Text firstEffectAvg, secondEffectAvg, thirdEffectAvg, fourthEffectAvg;
  
    public float firstEffectFPS, secondEffectFPS, thirdEffectFPS, fourthEffectFPS;
    public float firstEffectMS, secondEffectMS, thirdEffectMS, fourthEffectMS;

    /////////////////////////////////////////////////average for each effect:
    private float firstTempFPS, secondTempFPS, thirdTempFPS, fourthTempFPS;
    private float firstTempMS, secondTempMS, thirdTempMS, fourthTempMS;

    private float firstAvgFPS, secondAvgFPS, thirdAvgFPS, fourthAvgFPS;
    private float firstAvgMS, secondAvgMS, thirdAvgMS, fourthAvgMS;

    private int firstEffectFrames, secondEffectFrames, thirdEffectFrames, fourthEffectFrames;
    

    List<float> _firstMinMaxMS = new List<float>();
    List<float> _firstMinMaxFPS = new List<float>();
    List<float> _secondMinMaxMS = new List<float>();
    List<float> _secondMinMaxFPS = new List<float>();
    List<float> _thirdMinMaxMS = new List<float>();
    List<float> _thirdMinMaxFPS = new List<float>();
    List<float> _fourthMinMaxMS = new List<float>();
    List<float> _fourthMinMaxFPS = new List<float>();

     List<float> _totalMinMaxFPS = new List<float>();
     List<float> _totalMinMaxMS = new List<float>();



    /////////////////////////////////////////////////////////////////////////

    void Start()
    {
        preDefinedSceneWindow.SetActive(false);
        effects = GameObject.Find("_ToggleLibrary").GetComponent<EnabledEffects>().effectList.ToArray();
        SetupEffectName();
    }

    void Update()
    {
       
        ++frames;
        currentFrame.text = "Current frame: " + frames.ToString();
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (frames >= frameToStart)
        {
            if (frames % 10 == 0)
            {
                // Debug.Log("FPS:" + fps);
                ++_tenthFrame;
                tempFPS += fps;
                float _tempFPS = tempFPS;
                tempMS += msec;
                float _tempMS = tempMS;

                _totalMinMaxMS.Add(msec);
                _totalMinMaxFPS.Add(fps);

                if (_firstEffectStart == true)
                {
                    _firstTempDelay++;
                    if (_firstTempDelay >= effectDelay)
                    {
                        ++firstEffectFrames;
                        firstTempFPS += fps;
                        firstTempMS += msec;
                        _firstMinMaxFPS.Add(fps);
                        _firstMinMaxMS.Add(msec);
                        firstAvgFPS = firstTempFPS / firstEffectFrames;
                        firstAvgMS = firstTempMS / firstEffectFrames;
                    } 
                }

                if (_secondEffectStart == true)
                {
                    _secondTempDelay++;
                    if (_secondTempDelay >= effectDelay)
                    {
                        ++secondEffectFrames;
                        secondTempFPS += fps;
                        secondTempMS += msec;
                        _secondMinMaxFPS.Add(fps);
                        _secondMinMaxMS.Add(msec);
                        secondAvgFPS = secondTempFPS / secondEffectFrames;
                        secondAvgMS = secondTempMS / secondEffectFrames;
                    }
                }
                if (_thirdEffectStart == true)
                {
                    _thirdTempDelay++;
                    if (_thirdTempDelay >= effectDelay)
                    {
                        ++thirdEffectFrames;
                        thirdTempFPS += fps;
                        thirdTempMS += msec;
                        _thirdMinMaxFPS.Add(fps);
                        _thirdMinMaxMS.Add(msec);
                        thirdAvgFPS = thirdTempFPS / thirdEffectFrames;
                        thirdAvgMS = thirdTempMS / thirdEffectFrames;
                    }
                }
                if (_fourthEffectStart == true)
                {
                    _fourthTemDelay++;
                    if(_fourthTemDelay >= effectDelay)
                    {
                         ++fourthEffectFrames;
                        fourthTempFPS += fps;
                        fourthTempMS += msec;
                        _fourthMinMaxFPS.Add(fps);
                        _fourthMinMaxMS.Add(msec);
                        fourthAvgFPS = fourthTempFPS / fourthEffectFrames;
                        fourthAvgMS = fourthTempMS / fourthEffectFrames;
                    }
                }

                FPS = _tempFPS / _tenthFrame;
                MS = _tempMS / _tenthFrame;

                avgFPS.text = "avg fps: " + (Mathf.RoundToInt(FPS)).ToString();
                avgMS.text = "avg ms: " + (MS = Mathf.Round(MS * 100) / 100f).ToString();
            }
        } 

      //  FirstEffectCalculation();
    }


//////////////////////////write a method to show the result of the pre-defined scene stats
    void PreDefinedSceneStatsResult()
    {
        preDefinedSceneWindow.SetActive(true);
        totalAvg.text = (Mathf.RoundToInt(FPS)).ToString() + "/" + (MS = Mathf.Round(MS * 100) / 100f).ToString();
        Time.timeScale = 0f;
        // writting first efffect result into the table:
        firstEffectMin.text = (Mathf.RoundToInt(Mathf.Min(_fourthMinMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Max(_fourthMinMaxMS.ToArray()) * 100) / 100f).ToString();
        firstEffectMax.text = (Mathf.RoundToInt(Mathf.Max(_fourthMinMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Min(_fourthMinMaxMS.ToArray()) * 100) / 100f).ToString();
        firstEffectAvg.text = (Mathf.RoundToInt(fourthAvgFPS)).ToString() + "/" + (fourthAvgMS = Mathf.Round(fourthAvgMS * 100) / 100f).ToString();

         // writting second efffect result into the table:
        secondEffectMin.text = (Mathf.RoundToInt(Mathf.Min(_firstMinMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Max(_firstMinMaxMS.ToArray()) * 100) / 100f).ToString();
        secondEffectMax.text = (Mathf.RoundToInt(Mathf.Max(_firstMinMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Min(_firstMinMaxMS.ToArray()) * 100) / 100f).ToString();
        secondEffectAvg.text = (Mathf.RoundToInt(firstAvgFPS)).ToString() + "/" + (firstAvgMS = Mathf.Round(firstAvgMS * 100) / 100f).ToString();

          // writting third efffect result into the table:
        thirdEffectMin.text = (Mathf.RoundToInt(Mathf.Min(_secondMinMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Max(_secondMinMaxMS.ToArray()) * 100) / 100f).ToString();
        thirdEffectMax.text = (Mathf.RoundToInt(Mathf.Max(_secondMinMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Min(_secondMinMaxMS.ToArray()) * 100) / 100f).ToString();
        thirdEffectAvg.text = (Mathf.RoundToInt(secondAvgFPS)).ToString() + "/" + (secondAvgMS = Mathf.Round(secondAvgMS * 100) / 100f).ToString();

           // writting fourth efffect result into the table:
        fourthEffectMin.text = (Mathf.RoundToInt(Mathf.Min(_thirdMinMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Max(_thirdMinMaxMS.ToArray()) * 100) / 100f).ToString();
        fourthEffectMax.text = (Mathf.RoundToInt(Mathf.Max(_thirdMinMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Min(_thirdMinMaxMS.ToArray()) * 100) / 100f).ToString();
        fourthEffectAvg.text = (Mathf.RoundToInt(thirdAvgFPS)).ToString() + "/" + (thirdAvgMS = Mathf.Round(thirdAvgMS * 100) / 100f).ToString();

        totalSceneMin.text = (Mathf.RoundToInt(Mathf.Min(_totalMinMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Max(_totalMinMaxMS.ToArray()) * 100) / 100f).ToString();
        totalSceneMax.text = (Mathf.RoundToInt(Mathf.Max(_totalMinMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Min(_totalMinMaxMS.ToArray()) * 100) / 100f).ToString();
        // fourthEffectAvg.text = (Mathf.RoundToInt(fourthEffectFPS)).ToString() + "/" + (thirdEffectMS = Mathf.Round(fourthEffectMS * 100) / 100f).ToString();
        
    }

///////write a methot to calculate each effect performance
 /* void FirstEffectCalculation()
    {

        firstEffectdeltaTime += (Time.unscaledDeltaTime - firstEffectdeltaTime) * 0.1f;
        firstEffectmsec = firstEffectdeltaTime * 1000.0f;
        firstEffectfps = 1.0f / firstEffectdeltaTime;
        if(_firstEffectStart == true)
        {
            _firstEffectDelay ++;
            if (frames % 10 == 0 && _firstEffectDelay >= effectDelay)
            {
               // Debug.Log("firstEffectSatrted!!");
                ++_firstEffecttenthFrame;
                firstEffecttempFPS += firstEffectfps;
                float _tempFPS = firstEffecttempFPS;
                firstEffecttempMS += firstEffectmsec;
                float _tempMS = firstEffecttempMS;
                
                _minMaxMS.Add(firstEffectmsec);
                _minMaxFPS.Add(firstEffectfps);

                firstEffectFPS = _tempFPS / _firstEffecttenthFrame;
                firstEffectMS = _tempMS / _firstEffecttenthFrame;
        
                firstEffectMin.text = (Mathf.RoundToInt(Mathf.Min(_minMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Max(_minMaxMS.ToArray()) * 100) / 100f).ToString();
                firstEffectMax.text = (Mathf.RoundToInt(Mathf.Max(_minMaxFPS.ToArray()))).ToString() + "/" + (Mathf.Round(Mathf.Min(_minMaxMS.ToArray()) * 100) / 100f).ToString();
                firstEffectAvg.text = (Mathf.RoundToInt(firstEffectFPS)).ToString() + "/" + (firstEffectMS = Mathf.Round(firstEffectMS * 100) / 100f).ToString();
            }
        } 
    }*/

    ////////////////write a trigger to show the stats
    void OnTriggerEnter(Collider other)
    {
        // first effect:
        if (other.gameObject.name == "_effect1Enter")
        {
            _firstEffectStart = true;
        }
        if (other.gameObject.name == "_effect1Exit")
        {        
            _firstEffectEnd = true;
            _firstEffectStart = false;
        }

        // second effect:
         if (other.gameObject.name == "_effect2Enter")
        {
            _secondEffectStart = true;
        }
        if (other.gameObject.name == "_effect2Exit")
        {        
            _secondEffectEnd = true;
            _secondEffectStart = false;
        }

        // third effect:
          if (other.gameObject.name == "_effect3Enter")
        {
            _thirdEffectStart = true;
        }
        if (other.gameObject.name == "_effect3Exit")
        {        
            _thirdEffectEnd = true;
            _thirdEffectStart = false;
        }

         //Last effect
        if (other.gameObject.name == "_effect4Enter")
        {
            _fourthEffectStart = true;    
        }
        if (other.gameObject.name == "_effect4Exit" && _fourthEffectStart == true)
        {
            _fourthEffectEnd = true;
            _fourthEffectStart = false;
            PreDefinedSceneStatsResult();
        }
    }

    void SetupEffectName()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effectText[i].text = effects[i].ToString();
        }
    }


/////////////////////////performance colors depends on the platform you're testing
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;

#if UNITY_EDITOR      
		 if (fps < 40)
            style.normal.textColor = Color.yellow;
        else
        if (fps < 10)
            style.normal.textColor = Color.red;
        else
            style.normal.textColor = Color.green;
#endif

#if UNITY_STANDALONE      
		 if (fps < 40)
            style.normal.textColor = Color.yellow;
        else
        if (fps < 10)
            style.normal.textColor = Color.red;
        else
            style.normal.textColor = Color.green;
#endif

#if UNITY_ANDROID
 if (fps < 25)
            style.normal.textColor = Color.yellow;
        else
        if (fps < 10)
            style.normal.textColor = Color.red;
        else
            style.normal.textColor = Color.green;
#endif

#if UNITY_IOS
 if (fps < 25)
            style.normal.textColor = Color.yellow;
        else
        if (fps < 10)
            style.normal.textColor = Color.red;
        else
            style.normal.textColor = Color.green;
#endif
        msec = deltaTime * 1000.0f;
        fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}