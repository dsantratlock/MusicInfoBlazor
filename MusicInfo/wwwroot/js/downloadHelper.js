window.downloadFile = (content, filename, contentType) =>
{
    let blob = new Blob([content], { type: contentType });
    let url = URL.createObjectURL(blob);

    let fileDonwloadLink = document.createElement('a');
    fileDonwloadLink.href = url;
    fileDonwloadLink.setAttribute('download', filename);
    fileDonwloadLink.click();
}