using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SoundSettingsView : MonoBehaviour
{
    // Slider hiển thị và điều chỉnh âm lượng
    public Slider volumeSlider;
    // Text hiển thị phần trăm âm lượng
    public TMP_Text volumeLabel;

    // Hàm cập nhật giao diện khi âm lượng thay đổi
    public void UpdateVolume(float newVolume)
    {
        if (volumeSlider != null)
            volumeSlider.value = newVolume;
        if (volumeLabel != null)
            volumeLabel.text = $"Volume: {Mathf.RoundToInt(newVolume * 100)}%";
    }
}
