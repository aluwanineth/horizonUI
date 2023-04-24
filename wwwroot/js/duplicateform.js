window.duplicate = function (addform) {

    if (addform == 'true') {

        const div = document.getElementById('form-wrapper');

        let forms = div.getElementsByClassName('bankdetails');
        let firstForm = forms[0];
        let formClone = firstForm.cloneNode(true);
        div.appendChild(formClone);
    }
        

}