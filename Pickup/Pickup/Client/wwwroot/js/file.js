window.Download = (options) => {
    var fileUrl = "data:" + options.mimeType + ";base64," + options.byteArray;
    fetch(fileUrl)
        .then(response => response.blob())
        .then(blob => {
            var link = window.document.createElement("a");
            link.href = window.URL.createObjectURL(blob, { type: options.mimeType });
            link.download = options.fileName;
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        });
}
window.copyToClipboard = (text, DotNetHelper) => {

    // Create a "hidden" input
    var aux = document.createElement("input");

    // Assign it the value of the specified element
    aux.setAttribute("value", text);

    // Append it to the body
    document.body.appendChild(aux);

    // Highlight its content
    aux.select();

    // Copy the highlighted text
    document.execCommand("copy");

    // Remove it from the body
    document.body.removeChild(aux);
    DotNetHelper.invokeMethodAsync('CopiedMessage');
}
window.clipboardCopy = {
    copyText: function (text) {
        navigator.clipboard.writeText(text).then(function () {
            console.log("Copied to clipboard successfully!");
        }, function () {
            console.error("Unable to write to clipboard. :-(");
        });
    }
}



//$(document).ready(function () {
//    //Hide Back to top button  
//    var btn = document.getElementById("back-to-top")
//    btn.style.display = "none";
//    window.onscroll(function () {
//        if (document.body.scrollTop > 200) {
//            btn.style.display = "block";
//        } else {
//            btn.style.display = "none";
//        }
//    });
//    document.getElementById("back-to-top").click(function () {
//        document.getElementsByTagName("body").animate({
//            scrollTop: 0
//        }, 1000);
//    });
//});

//Get the button
var mybutton = document.getElementById("back-to-top");
var rootElement = document.documentElement;
// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 20) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    rootElement.scrollTo({
        top: 0,
        behavior: "smooth"
    })
    //document.body.scrollTop = 0;
    //document.documentElement.scrollTop = 0;
}
