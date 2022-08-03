function alphaNumericCheck(name) {
    var regEx = /^[-\w\s]+$/;
    if (name.match(regEx)) {
        return true;
    }

    else {
        return false;
    }
}




function validatePassword(pass) {
    var regEx = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&])([a-zA-Z0-9@$!%*?&]{8,})$/;
    if (pass.match(regEx)) {
        return true;
    }

    else {
        return false;
    }
}



function validateEmail(email) {
    var regEx = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;;
    if (email.match(regEx)) {
        return true;
    }

    else {
        return false;
    }
}