window.ScrollToBottom = (elementName) => {
    element = document.getElementById(elementName);
    element.scrollTop = element.scrollHeight - element.clientHeight;

    //element2 = document.getElementById('msg');
    //element2.onkeypress =
    //    function enterKeyPressed(event) {

    //        if (event.keyCode == 13) {
    //            console.log("Enter key is pressed");
    //            return true;
    //        } else {
    //            return false;
    //        }
    //    }
}

window.SendMessage = (netHelper) => {
    element = document.getElementById('msg');
    element.onkeypress =
        function enterKeyPressed(event) {
            if (event.keyCode == 13) {
                netHelper.invokeMethodAsync('SubmitAsync');
            }
        }
}