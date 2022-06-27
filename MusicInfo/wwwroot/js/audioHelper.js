window.setPlayStatus = (element, volume, lastPlayed, pagePlayer, audioEnded) =>
{
    if (!audioEnded)
    {
        if (lastPlayed !== "" && lastPlayed != element) {
            let previousTarget = document.getElementById(lastPlayed);
            if (previousTarget.paused && pagePlayer) {
                previousTarget.play();
            }
            else {
                previousTarget.pause();
            }
            if (pagePlayer) {
                return !previousTarget.paused;
            }
        }

        if (!pagePlayer) {
            let target = document.getElementById(element);
            if (target.paused) {
                target.play();
                target.volume = volume;
                return true;
            }
            else {
                target.pause();
                return false;
            }
        }
    }
    return false;
}

window.volumeChanged = (element, slider) =>
{
    let volume = document.getElementById(slider).value / 100;
    if (element !== "") {
        document.getElementById(element).volume = volume
    }
    return volume;
}