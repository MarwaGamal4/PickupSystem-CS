

function Screenshot() {
    html2canvas(document.querySelector("#tbl")).then(canvas => {
        debugger;
        var img = canvas.toDataURL("image/png");


        try {
            const imgURL = '/images/generic/file.png';
            const data = await fetch(img);
            const blob = await data.blob();
            await navigator.clipboard.write([
                new ClipboardItem({
                    [blob.type]: blob
                })
            ]);
            console.log('Image copied.');
        } catch (err) {
            console.error(err.name, err.message);
        }

    });
}