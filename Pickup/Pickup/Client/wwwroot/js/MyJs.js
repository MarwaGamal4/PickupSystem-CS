

window.TakeScreenShoot = async function Screenshot(dotNetHelper) {
    html2canvas(document.querySelector("#tbl")).then(async canvas => {

        // var img = canvas.toDataURL("image/png");
        canvas.toBlob(blob => navigator.clipboard.write([new ClipboardItem({ 'image/png': blob })]))
        await DotNetHelper.invokeMethodAsync('CopiedMessage');
        //try {
        //    const imgURL = '/images/generic/file.png';
        //    const data = await fetch(img);
        //    const blob = await data.blob();
        //    await navigator.clipboard.write([
        //        new ClipboardItem({
        //            [blob.type]: blob
        //        })
        //    ]);
        //    console.log('Image copied.');
        //} catch (err) {
        //    console.error(err.name, err.message);
        //}

    });

}

window.EportTableToExcel = function exportTableToExcel(tableID, filename = '') {
    var downloadLink;
    var dataType = 'application/vnd.ms-excel';
    var tableSelect = document.getElementById(tableID);
    var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

    // Specify file name
    filename = filename ? filename + '.xls' : 'excel_data.xls';

    // Create download link element
    downloadLink = document.createElement("a");

    document.body.appendChild(downloadLink);

    if (navigator.msSaveOrOpenBlob) {
        var blob = new Blob(['\ufeff', tableHTML], {
            type: dataType
        });
        navigator.msSaveOrOpenBlob(blob, filename);
    } else {
        // Create a link to the file
        downloadLink.href = 'data:' + dataType + ', ' + tableHTML;

        // Setting the file name
        downloadLink.download = filename;

        //triggering the function
        downloadLink.click();
    }
}
