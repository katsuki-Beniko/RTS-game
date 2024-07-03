using UnityEngine.UI;

public class SetView : BaseView
{
    protected override void OnAwake()
    {
        base.OnAwake();
        Find<Button>("bg/closeBtn").onClick.AddListener(onCloseBtn);
        Find<Toggle>("bg/IsOpnSound").onValueChanged.AddListener(onIsStopBtn);
        Find<Slider>("bg/soundCount").onValueChanged.AddListener(onSliderBgmBtn);
        Find<Slider>("bg/effectCount").onValueChanged.AddListener(onSliderSoundEffectBtn);

        Find<Toggle>("bg/IsOpnSound").isOn = GameApp.SoundManager.IsStop;
        Find<Slider>("bg/soundCount").value = GameApp.SoundManager.BgmVolume;
        Find<Slider>("bg/effectCount").value = GameApp.SoundManager.EffectVolume;
    }

    // «∑Òæ≤“Ù
    private void onIsStopBtn(bool isStop)
    {
        GameApp.SoundManager.IsStop = isStop;
    }

    //…Ë÷√bgm“Ù¡ø
    private void onSliderBgmBtn(float val)
    {
        GameApp.SoundManager.BgmVolume = val;
    }

    private void onSliderSoundEffectBtn(float val)
    {
        GameApp.SoundManager.EffectVolume = val;
    }

    private void onCloseBtn()
    {
        GameApp.ViewManager.Close(ViewId);
    }
}
