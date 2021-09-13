function validateFormElements(){
    /**
     * Checking validation of each form elements separately
     * each method will return true or false depending on whether validation was successful or not.
     */
    let isNameValid = checkNameValidation();
    let isEmailValid = checkEmailValidation();
    let isWebsiteValid = checkWebsiteValidation();
    let isImageLinkValid = checkImageLinkValidation();
    let isGenderValid = checkGenderValidation();
    let isSkillSelected = checkIfSkillsSelected();
    
    //If any one validation is false then we make our final validation false
    let isFormValid = isNameValid && isEmailValid && isWebsiteValid && isGenderValid && isImageLinkValid && isSkillSelected;

    return isFormValid;
}

//Checking name input validation
/**
 * This method ensures user didn't left the input blank and
 * it also ensures user has input only characters and not any number or special symbol
 */
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

//checking email validation
//It ensures user must input an email address and shouldn't leave input blank
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

//checking websiteUrl validation
//It ensures user must input a url and shouldn't leave input blank
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

//checking imageUrl validation
//It ensures user must input a image url and shouldn't leave input blank
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

//This method ensures user must select one of the two options given for gender
function checkGenderValidation(){
    let genderElement = document.querySelector('input[name="gender"]:checked');
    let fieldSet = document.querySelector("#gender");
    if(genderElement){
        fieldSet.classList.remove('was-validated');
        return true;
    }else{
        fieldSet.classList.add('was-validated');
        return false;
    }
}

function checkIfSkillsSelected(){
    let skillsSelected = document.querySelectorAll('input[name="lang"]:checked');
    let formCheckElement = document.querySelector('#formCheckbox');
    if(skillsSelected.length===0){
        formCheckElement.classList.add('is-invalid');
        return false;
    }else{
        formCheckElement.classList.remove('is-invalid');
        return true;
    }
}

export { validateFormElements };