using UnityEngine;
using UnityEngine.UI;


public class SoundSettingsUIManager : MonoBehaviour
{
    // Slider điều chỉnh âm lượng trên UI
    public Slider volumeSlider;

    // Tham chiếu đến Controller và View
    public SoundSettingsController soundSettingsController;
    public SoundSettingsView soundSettingsView;

    void Start()
    {
        // Đăng ký sự kiện khi slider thay đổi giá trị
        if (volumeSlider != null)
            volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Đăng ký sự kiện của Controller để View cập nhật giao diện khi âm lượng thay đổi
        if (soundSettingsController != null && soundSettingsView != null)
            soundSettingsController.OnVolumeChanged += soundSettingsView.UpdateVolume;

        // (Tùy chọn) Đồng bộ giá trị ban đầu từ Model vào UI
        if (soundSettingsController != null && volumeSlider != null)
            volumeSlider.value = soundSettingsController.soundSettingsData.masterVolume;
    }

    // Khi người dùng thay đổi slider, gọi hàm trong Controller để cập nhật âm lượng
    private void OnSliderValueChanged(float newValue)
    {
        soundSettingsController.UpdateVolume(newValue);
    }
}
