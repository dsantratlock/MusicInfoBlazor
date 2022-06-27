using Microsoft.AspNetCore.Components;
using MusicInfo.Models;
using MusicInfo.Services;

namespace MusicInfo.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] MusicInfoService? MusicInfoService { get; set; }
        [Inject] AudioStatusService? AudioStatusService { get; set; }

        private List<TrackData> resultEntries = new List<TrackData>();

        private TrackData? currentTrackData;
        private string? currentTrackUrl;
        private string currentPlayStatus = "Play";
        private bool pagePlayerDisabled = true;
        private bool showGraph;
        private string requestedDataSet = "artist";

        protected override void OnInitialized()
        {
            if (AudioStatusService!.CurrentPlayer != null)
                currentTrackData = resultEntries.Where(x => x.TrackId == int.Parse(AudioStatusService!.CurrentPlayer.ElementId)).First();
        }


        public async Task GetTrackData(string searchValue)
        {
            if (!string.IsNullOrEmpty(searchValue))
            {
                resultEntries = await MusicInfoService!.GetMusicInfoAsync(searchValue);
                StateHasChanged();
            }
        }

        public void ToggleShowGraph()
        {
            showGraph = !showGraph;
            StateHasChanged();
        }

        public void OnDataSetChange(ChangeEventArgs e)
        {
            requestedDataSet = e!.Value!.ToString()!;
            StateHasChanged();
        }

        public void SetPlayingTrack()
        {
            if (AudioStatusService!.CurrentPlayer != null)
            {
                currentTrackData = resultEntries.Where(x => x.TrackId == int.Parse(AudioStatusService!.CurrentPlayer.ElementId)).First();
                currentTrackUrl = currentTrackData.PreviewUrl;
                currentPlayStatus = AudioStatusService!.PlayingStatus;
                pagePlayerDisabled = false;
            }
            StateHasChanged();
        }

        public void RerfreshVolume()
        {
            StateHasChanged();
        }
    }
}
