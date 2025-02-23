using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundSettingsController : MonoBehaviour
{
    // Tham chiếu đến dữ liệu cài đặt âm thanh
    public SoundSettingsData soundSettingsData;

    // Tham chiếu đến AudioMixer (gán qua Inspector, nếu dùng)
    [SerializeField] private AudioMixer audioMixer;

    // Tên parameter trong AudioMixer để điều chỉnh âm lượng chính
    private const string volumeParameter = "MasterVolume";

    // Tham chiếu đến AudioSource cụ thể, ví dụ như nhạc nền
    [SerializeField] private AudioSource musicSource;

    // Sự kiện thông báo khi âm lượng thay đổi
    public event Action<float> OnVolumeChanged;

    // Hàm cập nhật âm lượng, được gọi từ UIManager khi người dùng thay đổi slider
    public void UpdateVolume(float newVolume)
    {
        // Cập nhật Model
        soundSettingsData.masterVolume = newVolume;

        // Nếu có AudioMixer, sử dụng AudioMixer để đặt âm lượng, nếu không thì dùng AudioListener
        if (audioMixer != null)
        {
            // Chuyển đổi giá trị volume tuyến tính (0-1) sang decibel
            float dB = newVolume > 0 ? Mathf.Log10(newVolume) * 20 : -80;
            audioMixer.SetFloat(volumeParameter, dB);
        }
        else
        {
            AudioListener.volume = newVolume;
        }

        // Nếu có AudioSource cụ thể, cập nhật luôn volume của nó
        if (musicSource != null)
        {
            musicSource.volume = newVolume;
        }

        // Lưu cài đặt âm lượng để sử dụng lại khi game khởi động lại
        PlayerPrefs.SetFloat("MasterVolume", newVolume);
        PlayerPrefs.Save();

        // Phát sự kiện để thông báo cho View cập nhật giao diện
        OnVolumeChanged?.Invoke(newVolume);
    }
}
