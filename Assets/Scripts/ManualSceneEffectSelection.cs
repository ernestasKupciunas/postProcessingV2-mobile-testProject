using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class ManualSceneEffectSelection : MonoBehaviour 
{
	[Header("Effect toggles:")]
	[SerializeField] private Toggle ambientOcc;
	[SerializeField] private Toggle bloom;
	[SerializeField] private Toggle chromaticAber;
	[SerializeField] private Toggle colorGrad;
	[SerializeField] private Toggle depthOfField;
	[SerializeField] private Toggle grain;
	[SerializeField] private Toggle lensDist;
	[SerializeField] private Toggle motionBlur;
	[SerializeField] private Toggle vignette;

	[Header("Volume (added dinamically):")]
// init the effects:
	[SerializeField] PostProcessVolume _effectVolume;

	[Header("Effects:")]
	AmbientOcclusion _ambientOcc;
	Bloom _bloom;
	ChromaticAberration _chromaticAberration;
	ColorGrading _colorGrading;
	DepthOfField _depthOfField;
	Grain _grain;
	LensDistortion _lensDistortion;
	MotionBlur _motionBlur;
	Vignette _vignette;

[Header("Vignette effect controller:")]
	// Vignette effect controllers:
	[SerializeField] private Slider vignetteIntensity;
	[SerializeField] private Slider vignetteSmoothness;
	[SerializeField] private Slider vignetteRoundness;
	[SerializeField] private Toggle vignetteToggler;

[Header("EepthOfField effect controller:")]
[	SerializeField] private Slider depthOfFieldFocusDistance;
	[SerializeField] private Slider depthOfFieldAperture;
	[SerializeField] private Slider depthOfFieldFocalLength;
	[SerializeField] private Dropdown depthOfFieldMaxBlurSize;

[Header("Grain effect controller:")]
[	SerializeField] private Toggle grainColored;
	[SerializeField] private Slider grainIntensity;
	[SerializeField] private Slider grainSize;
	[SerializeField] private Slider grainLuminanceContr;

[Header("Lens Distortion effect controller:")]
	[SerializeField] private Slider lensDistIntensity;
	[SerializeField] private Slider lensDistYMultiplier;
	[SerializeField] private Slider lensDistXMultiplier;
	[SerializeField] private Slider lensDistCenterX;
	[SerializeField] private Slider lensDistCenterY;
	[SerializeField] private Slider lensDistScale;

[Header("Chromatic Aberration effect controller:")]
	[SerializeField] private Slider chromaticAberIntensity;
	[SerializeField] private Toggle chromaticAberFastMode;

[Header("Motion Blur effect controller:")]
	[SerializeField] private Slider motionBlurShutterAngle;
	[SerializeField] private Slider motionBlurSampleCount;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private GameObject cameraForTheEffect;

[Header("Ambient Occlusion effect controller:")]
	[SerializeField] private Slider ambientOccIntensity;
	[SerializeField] private Slider ambientOccRadius;
	[SerializeField] private Dropdown ambientOccQuality;
	[SerializeField] private Toggle ambientOccAmbientOnly;

[Header("Bloom effect controller:")]
	[SerializeField] private Slider bloomIntensity;
	[SerializeField] private Slider bloomThreshold;
	[SerializeField] private Slider bloomSoftKnee;
	[SerializeField] private Slider bloomDiffusion;
	[SerializeField] private Slider bloomAnamorphicRatio;
	[SerializeField] private Toggle bloomColorWhite;
	[SerializeField] private Toggle bloomColorGreen;
	[SerializeField] private Toggle bloomColorBlue;
	[SerializeField] private Toggle bloomFastMode;

[Header("Color Grading effect controller:")]
	[SerializeField] private Slider colorGradTemperature;
	[SerializeField] private Slider colorGradTint;
	[SerializeField] private Slider colorGradHueShift;
	[SerializeField] private Slider colorGradSaturation;
	[SerializeField] private Slider colorGradContrast;
	[SerializeField] private Toggle colorGradColorRed;
	[SerializeField] private Toggle colorGradColorGreen;
	[SerializeField] private Toggle colorGradColorBlue;
	[SerializeField] private Dropdown colorGradModes;



[Header("Effect windows:")]
	// making effects window to tweak
	[SerializeField] private GameObject effectsSelectionWindow;
	[SerializeField] private GameObject ambientOccWindow;
	[SerializeField] private GameObject bloomWindow;
	[SerializeField] private GameObject chromaticAberWindow;
	[SerializeField] private GameObject colorGradWindow;
	[SerializeField] private GameObject depthOfFieldWindow;
	[SerializeField] private GameObject grainWindow;
	[SerializeField] private GameObject lensDistWindow;
	[SerializeField] private GameObject motionBlurWindow;
	[SerializeField] private GameObject vignetteWindow;

	

	// Use this for initialization
	void Start () 
	{

		ambientOcc.isOn = false;
		bloom.isOn = false;
		chromaticAber.isOn = false;
		colorGrad.isOn = false;
		depthOfField.isOn = false;
		grain.isOn = false;
		lensDist.isOn = false;
		motionBlur.isOn = false;
		vignette.isOn = false;

		SetupToggles();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (vignetteWindow.activeSelf)
		{
			VignetteController();
		}

		if (depthOfFieldWindow.activeSelf)
		{
			DepthOfFieldCOntroller();
		}

		if (grainWindow.activeSelf)
		{
			GrainController();
		}

		if (lensDistWindow.activeSelf)
		{
			LenseDistController();
		}

		if (chromaticAberWindow.activeSelf)
		{
			ChromaticAberController();
		}

		if (motionBlurWindow.activeSelf)
		{
			MotionBlurController();
		}
		if (ambientOccWindow.activeSelf)
		{
			AmbientOccController();
		}
		if (bloomWindow.activeSelf)
		{
			BloomController();
		}
		if (colorGradWindow.activeSelf)
		{
			ColorGradController();
		}
		
		
	}
	void SetupToggles()
	{
		ambientOcc.onValueChanged.AddListener(delegate
		{
			AmbientOccController(ambientOcc);
		});
		bloom.onValueChanged.AddListener(delegate
		{
			BloomController(bloom);
		});
		chromaticAber.onValueChanged.AddListener(delegate
		{
			ChromaticAberController(chromaticAber);
		});
		colorGrad.onValueChanged.AddListener(delegate
		{
			ColorGradController(colorGrad);
		});
		depthOfField.onValueChanged.AddListener(delegate
		{
			DepthOfFieldController(depthOfField);
		});
		grain.onValueChanged.AddListener(delegate
		{
			GrainController(grain);
		});
		lensDist.onValueChanged.AddListener(delegate
		{
			LensDistController(lensDist);
		});
		motionBlur.onValueChanged.AddListener(delegate
		{
			MotionBlurController(motionBlur);
		});
		vignette.onValueChanged.AddListener(delegate
		{
			VignetteController(vignette);
		});
		vignetteToggler.onValueChanged.AddListener(delegate
		{
			if (vignetteToggler.isOn)
			{
				_vignette.rounded.Override(true);
			}
			else if (!vignetteToggler.isOn)
			{
				_vignette.rounded.Override(false);
			}
		});
		grainColored.onValueChanged.AddListener(delegate
		{
			if (grainColored.isOn)
			{
				_grain.colored.Override(true);
			}
			else if (!grainColored.isOn)
			{
				_grain.colored.Override(false);
			}
		});

		chromaticAberFastMode.onValueChanged.AddListener(delegate
		{
			if (chromaticAberFastMode.isOn)
			{
				_chromaticAberration.fastMode.Override(true);
			}
			else if (!chromaticAberFastMode.isOn)
			{
				_chromaticAberration.fastMode.Override(false);
			}
		});
		ambientOccAmbientOnly.onValueChanged.AddListener(delegate
		{
			if (ambientOccAmbientOnly.isOn)
			{
				_ambientOcc.ambientOnly.Override(true);
			}
			else if (!ambientOccAmbientOnly.isOn)
			{
				_ambientOcc.ambientOnly.Override(false);
			}
		});
		bloomColorWhite.onValueChanged.AddListener(delegate
		{
			if (bloomColorWhite.isOn)
			{
				_bloom.color.Override(Color.white);
				bloomColorBlue.isOn = false;
				bloomColorGreen.isOn = false;
			}
		});
		bloomColorBlue.onValueChanged.AddListener(delegate
		{
			if (bloomColorBlue.isOn)
			{
				_bloom.color.Override(Color.blue);
				bloomColorGreen.isOn = false;
				bloomColorWhite.isOn = false;
			}
		});
		bloomColorGreen.onValueChanged.AddListener(delegate
		{
			if (bloomColorGreen.isOn)
			{
				_bloom.color.Override(Color.green);
				bloomColorBlue.isOn = false;
				bloomColorWhite.isOn = false;
			}
		});
		bloomFastMode.onValueChanged.AddListener(delegate
		{
			if (bloomFastMode.isOn)
			{
				_bloom.fastMode.Override(true);
			}
			else if (!bloomFastMode.isOn)
			{
				_bloom.fastMode.Override(false);
			}
		});
			colorGradColorRed.onValueChanged.AddListener(delegate
		{
			if (colorGradColorRed.isOn)
			{
				_colorGrading.colorFilter.Override(Color.red);
				colorGradColorBlue.isOn = false;
				colorGradColorGreen.isOn = false;
			}
				else if (!colorGradColorRed.isOn)
			{
				_colorGrading.colorFilter.Override(Color.white);
			}
		});
			colorGradColorGreen.onValueChanged.AddListener(delegate
		{
			if (colorGradColorGreen.isOn)
			{
				_colorGrading.colorFilter.Override(Color.green);
				colorGradColorBlue.isOn = false;
				colorGradColorRed.isOn = false;
			}
				else if (!colorGradColorGreen.isOn)
			{
				_colorGrading.colorFilter.Override(Color.white);
			}
		});
			colorGradColorBlue.onValueChanged.AddListener(delegate
		{
			if (colorGradColorBlue.isOn)
			{
				_colorGrading.colorFilter.Override(Color.blue);
				colorGradColorGreen.isOn = false;
				colorGradColorRed.isOn = false;
			}
				else if (!colorGradColorBlue.isOn)
			{
				_colorGrading.colorFilter.Override(Color.white);
			}
			
		});
	}

	void ToggleValueChanged(Toggle change)
	{
		if (change.isOn)
		{
			Debug.Log("soething somethiong is On");
		}
		else if(!change.isOn)
		{
			Debug.Log("soething somethiong is Off");
		}
	}

	void VignetteController(Toggle change)
	{
		if (change.isOn)
		{
			vignetteWindow.SetActive(true);
			_vignette = ScriptableObject.CreateInstance<Vignette>();
			_vignette.enabled.Override(true);
			//_vignette.intensity.Override(1f);
			_effectVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, _vignette);
			effectsSelectionWindow.SetActive(false);
		}
		else if(!change.isOn)
		{
			vignetteWindow.SetActive(false);
			RuntimeUtilities.DestroyVolume(_effectVolume, false);
		}
	}

	void DepthOfFieldController(Toggle change)
	{
		if (change.isOn)
		{
			depthOfFieldWindow.SetActive(true);
			_depthOfField = ScriptableObject.CreateInstance<DepthOfField>();
			_depthOfField.enabled.Override(true);
			//_vignette.intensity.Override(1f);
			_effectVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, _depthOfField);
			effectsSelectionWindow.SetActive(false);
		}
		else if(!change.isOn)
		{
			depthOfFieldWindow.SetActive(false);
			RuntimeUtilities.DestroyVolume(_effectVolume, false);
		}
	}

	void GrainController(Toggle change)
	{
		if (change.isOn)
		{
			grainWindow.SetActive(true);
			_grain = ScriptableObject.CreateInstance<Grain>();
			_grain.enabled.Override(true);
			//_vignette.intensity.Override(1f);
			_effectVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, _grain);
			effectsSelectionWindow.SetActive(false);
		}
		else if(!change.isOn)
		{
			grainWindow.SetActive(false);
			RuntimeUtilities.DestroyVolume(_effectVolume, false);
		}
	}

	void LensDistController(Toggle change)
	{
		if (change.isOn)
		{
			lensDistWindow.SetActive(true);
			_lensDistortion = ScriptableObject.CreateInstance<LensDistortion>();
			_lensDistortion.enabled.Override(true);
			//_vignette.intensity.Override(1f);
			_effectVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, _lensDistortion);
			effectsSelectionWindow.SetActive(false);
		}
		else if(!change.isOn)
		{
			lensDistWindow.SetActive(false);
			RuntimeUtilities.DestroyVolume(_effectVolume, false);
		}
	}

	void ChromaticAberController(Toggle change)
	{
		if (change.isOn)
		{
			chromaticAberWindow.SetActive(true);
			_chromaticAberration = ScriptableObject.CreateInstance<ChromaticAberration>();
			_chromaticAberration.enabled.Override(true);
			_effectVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, _chromaticAberration);
			effectsSelectionWindow.SetActive(false);
		}
		else if(!change.isOn)
		{
			chromaticAberWindow.SetActive(false);
			RuntimeUtilities.DestroyVolume(_effectVolume, false);
		}
	}
	void AmbientOccController(Toggle change)
	{
		if (change.isOn)
		{
			ambientOccWindow.SetActive(true);
			_ambientOcc = ScriptableObject.CreateInstance<AmbientOcclusion>();
			_ambientOcc.enabled.Override(true);
			_ambientOcc.color.Override(Color.black);
			_ambientOcc.mode.Override(AmbientOcclusionMode.ScalableAmbientObscurance);
			_effectVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, _ambientOcc);
			effectsSelectionWindow.SetActive(false);
		}
		else if(!change.isOn)
		{
			ambientOccWindow.SetActive(false);
			RuntimeUtilities.DestroyVolume(_effectVolume, false);
		}
	}
		void BloomController(Toggle change)
	{
		if (change.isOn)
		{
			bloomWindow.SetActive(true);
			_bloom = ScriptableObject.CreateInstance<Bloom>();
			_bloom.enabled.Override(true);
			_bloom.color.Override(Color.white);
			_bloom.clamp.Override(65472f);
			_effectVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, _bloom);
			effectsSelectionWindow.SetActive(false);
		}
		else if(!change.isOn)
		{
			bloomWindow.SetActive(false);
			RuntimeUtilities.DestroyVolume(_effectVolume, false);
		}
	}

	void MotionBlurController(Toggle change)
	{
		if (change.isOn)
		{
			Debug.Log("Camera for motion blur is enabled");
			mainCamera.enabled = false;
			cameraForTheEffect.SetActive(true);
			motionBlurWindow.SetActive(true);
			_motionBlur = ScriptableObject.CreateInstance<MotionBlur>();
			_motionBlur.enabled.Override(true);
			_effectVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, _motionBlur);
			effectsSelectionWindow.SetActive(false);
		}
		else if(!change.isOn)
		{
			Debug.Log("Camera for motion blur is disabled");
			mainCamera.enabled = true;
			cameraForTheEffect.SetActive(false);
			motionBlurWindow.SetActive(false);
			RuntimeUtilities.DestroyVolume(_effectVolume, false);
		}
	}
		void ColorGradController(Toggle change)
	{
		if (change.isOn)
		{
			colorGradWindow.SetActive(true);
			_colorGrading = ScriptableObject.CreateInstance<ColorGrading>();
			_colorGrading.enabled.Override(true);
			_colorGrading.gradingMode.Override(GradingMode.HighDefinitionRange);
			_colorGrading.postExposure.Override(0.04f);
			_effectVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, _colorGrading);
			effectsSelectionWindow.SetActive(false);
		}
		else if(!change.isOn)
		{
			colorGradWindow.SetActive(false);
			RuntimeUtilities.DestroyVolume(_effectVolume, false);
		}
	}
// back button forEffects:
	public void VignetteBack()
	{
		vignette.isOn = false;
		effectsSelectionWindow.SetActive(true);
	}

	public void DepthOfFieldBack()
	{
		depthOfField.isOn = false;
		effectsSelectionWindow.SetActive(true);
	}
	public void GrainBack()
	{
		grain.isOn = false;
		effectsSelectionWindow.SetActive(true);
	}
	public void LensDistBack()
	{
		lensDist.isOn = false;
		effectsSelectionWindow.SetActive(true);
	}

	public void ChromaticAberBack()
	{
		chromaticAber.isOn = false;
		effectsSelectionWindow.SetActive(true);
	}

	public void MotionBlurBack()
	{
		motionBlur.isOn = false;
		effectsSelectionWindow.SetActive(true);

	}
	public void AmbientOccBack()
	{
		ambientOcc.isOn = false;
		effectsSelectionWindow.SetActive(true);
	}
	public void BloomBack()
	{
		bloom.isOn = false;
		effectsSelectionWindow.SetActive(true);
	}
	public void ColorGradBack()
	{
		colorGrad.isOn = false;
		effectsSelectionWindow.SetActive(true);
	}




	// Controllers:

	void VignetteController()
	{
		_vignette.intensity.Override(vignetteIntensity.value);
		_vignette.smoothness.Override(vignetteSmoothness.value);
		_vignette.roundness.Override(vignetteRoundness.value);
	}
	void BloomController()
	{
		_bloom.intensity.Override(bloomIntensity.value);
		_bloom.threshold.Override(bloomThreshold.value);
		_bloom.softKnee.Override(bloomSoftKnee.value);
		_bloom.diffusion.Override(bloomDiffusion.value);
		_bloom.anamorphicRatio.Override(bloomAnamorphicRatio.value);
	}
	void ColorGradController()
	{
		_colorGrading.temperature.Override(colorGradTemperature.value);
		_colorGrading.tint.Override(colorGradTint.value);
		_colorGrading.hueShift.Override(colorGradHueShift.value);
		_colorGrading.saturation.Override(colorGradSaturation.value);
		_colorGrading.contrast.Override(colorGradContrast.value);

		if (colorGradModes.value == 0)
		{
			_colorGrading.tonemapper.Override(Tonemapper.None);
		}
		else if (colorGradModes.value == 1)
		{
			_colorGrading.tonemapper.Override(Tonemapper.Neutral);
		}
		else if (colorGradModes.value == 2)
		{
			_colorGrading.tonemapper.Override(Tonemapper.ACES);
		}
	}


	void AmbientOccController()
	{
		_ambientOcc.intensity.Override(ambientOccIntensity.value);
		_ambientOcc.radius.Override(ambientOccRadius.value);
		if (ambientOccQuality.value == 0)
		{
			//Debug.Log("AmboentOcc level 0");
			_ambientOcc.quality.Override(AmbientOcclusionQuality.Lowest);
		}
		else if (ambientOccQuality.value == 1)
		{
			_ambientOcc.quality.Override(AmbientOcclusionQuality.Low);
		}
		else if (ambientOccQuality.value == 2)
		{
			_ambientOcc.quality.Override(AmbientOcclusionQuality.Medium);
		}
		else if (ambientOccQuality.value == 3)
		{
			_ambientOcc.quality.Override(AmbientOcclusionQuality.High);
		}
		else
		{
			_ambientOcc.quality.Override(AmbientOcclusionQuality.Ultra);
		}
	}
	void MotionBlurController()
	{
		//mainCamera.enabled = true;
		//cameraForTheEffect.SetActive(false);
		_motionBlur.shutterAngle.Override(motionBlurShutterAngle.value);
		_motionBlur.sampleCount.Override(Mathf.RoundToInt(motionBlurSampleCount.value));
	}

	void ChromaticAberController()
	{
		_chromaticAberration.intensity.Override(chromaticAberIntensity.value);
	}

	void LenseDistController()
	{
		_lensDistortion.intensity.Override(lensDistIntensity.value);
		_lensDistortion.intensityY.Override(lensDistYMultiplier.value);
		_lensDistortion.intensityX.Override(lensDistXMultiplier.value);
		_lensDistortion.centerX.Override(lensDistCenterX.value);
		_lensDistortion.centerY.Override(lensDistCenterY.value);
		_lensDistortion.scale.Override(lensDistScale.value);
	}

	void GrainController()
	{
		_grain.intensity.Override(grainIntensity.value);
		_grain.size.Override(grainSize.value);
		_grain.lumContrib.Override(grainLuminanceContr.value);
	}

	void DepthOfFieldCOntroller()
	{
		_depthOfField.focusDistance.Override(depthOfFieldFocusDistance.value);
		_depthOfField.aperture.Override(depthOfFieldAperture.value);
		_depthOfField.focalLength.Override(depthOfFieldFocalLength.value);
		
		if (depthOfFieldMaxBlurSize.value == 0)
		{
			_depthOfField.kernelSize.Override(KernelSize.Small);
		}
		else if (depthOfFieldMaxBlurSize.value == 1)
		{
			_depthOfField.kernelSize.Override(KernelSize.Medium);
		}
		else if (depthOfFieldMaxBlurSize.value == 2)
		{
			_depthOfField.kernelSize.Override(KernelSize.Large);
		}
		else
		{
			_depthOfField.kernelSize.Override(KernelSize.VeryLarge);
		}
		 
	}
}
