function validateFormElements(){
    let isNameValid = checkNameValidation();
    let isEmailValid = checkEmailValidation();
    let isWebsiteValid = checkWebsiteValidation();
    let isImageLinkValid = checkImageLinkValidation();
    let isGenderValid = checkGenderValidation();
    
    let isFormValid = isNameValid && isEmailValid && isWebsiteValid && isImageLinkValid && isGenderValid;

    return isFormValid;
}

function checkNameValidation(){
    let name = document.getElementById('name');

    let errorDiv1 = name.nextElementSibling;
    let errorDiv2 = errorDiv1.nextElementSibling;
    
    if(name.value.trim().length == 0){
        errorDiv1.style.display = 'block';
        errorDiv2.style.display = 'none';
        name.classList.add('is-invalid');
        return false;
    }else if((/[^a-zA-Z\s]+/).test(name.value)){
        errorDiv2.style.display = 'block';
        errorDiv1.style.display = 'none';
        name.classList.add('is-invalid');
        return false;
    }else{
        errorDiv1.style.display = 'none';
        errorDiv2.style.display = 'none';
        name.classList.remove('is-invalid');
        return true;
    }
}

function checkEmailValidation(){
    let email = document.getElementById('email');
    if ((/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/).test(email.value)){
        email.classList.remove('is-invalid');
        return true;
    }else{
        email.classList.add('is-invalid');
        return false;
    }
}

function checkWebsiteValidation(){
    let website = document.getElementById('website');
    let urlRegExp = /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,4}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)/;
    if(urlRegExp.test(website.value)){
        website.classList.remove('is-invalid');
        return true;
    }else{
        website.classList.add('is-invalid');
        return false;
    }
}

function checkImageLinkValidation(){
    let imageElement = document.getElementById('imageLink');
    if(imageElement.checkValidity()){
        imageElement.classList.remove('is-invalid');
        return true;
    }else{
        imageElement.classList.add('is-invalid');
        return false;
    }
}

function checkGenderValidation(){
    let genderElement = document.querySelector('input[name="gender"]:checked');
    let fieldSet = document.querySelector("fieldset");
    if(genderElement){
        fieldSet.classList.remove('was-validated');
        return true;
    }else{
        fieldSet.classList.add('was-validated');
        return false;
    }
}

export { validateFormElements };