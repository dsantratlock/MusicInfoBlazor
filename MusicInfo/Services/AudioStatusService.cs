using MusicInfo.Components;
using MusicInfo.Models;

namespace MusicInfo.Services
{

    public delegate void StatusChangedEvent();

    public class AudioStatusService
    {
        public AudioPlayer? CurrentPlayer { get; set; }
        public double Volume { get; set; } = 0.7;
        public bool Playing { get; set; }

        public string PlayingStatus { get; set; } = "Play";

        public void SetVolume(double volume)
        {
            Volume = volume;
        }

        public void SetCurrentPlayer(bool playing, bool audioEnded, AudioPlayer player)
        {
            if (player.ElementId != "PagePlayer" || audioEnded)
            {
                CurrentPlayer = player;
            }
            Playing = playing;
            PlayingStatus = playing ? "Pause" : "Play";
        }
    }
}
