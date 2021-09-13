import {validateFormElements} from './validation.js';
import {createAndInsertTableRow} from './tableRow.js'

//getting html element which shows alert message when email is similar in two entries of table
let sameEmailAlert = document.querySelector('#sameEmailAlert');
/**
 * This event listener makes sure that after the fade-out effect of alert message,
 * the alert html element must be removed from the web page.
 */
sameEmailAlert.addEventListener('animationend', ()=>{
    sameEmailAlert.style.display = 'none';
});

/**
 * This array will store the email Ids of all entries in table
 * It will come in handy when checking if an email id is already present in table or not
 */
let emailArr = new Array();

/**
 * Getting html element of the student form displayed in web page
 * Then calling enrollStudent method on form submission (By listening to 'submit' event)
 */
let studentForm = document.getElementById('studentForm');
studentForm.addEventListener('submit', enrollStudent);

/**
 * This method validates all the form elements using validation.js file and then
 * create and insert row in a table using tableRow.js file
 */
function enrollStudent(event){
    /**
    * event object will be passed by 'submit' event, 
    * and it has preventDefault() method which stops the default behaviour of submitting the form
    */
    event.preventDefault();

    //validateFormElements() will return true if validation passes otherwise it'll return false
    let isValid = validateFormElements();
    //If validation fails, returning the execution from here as table should not be formed without passing of validation
    if(!isValid){
        return;
    }

    //getting value of email inserted by user
    let email = document.getElementById('email').value;
    /**
     * checking if email is already present in array,
     * if it is present then showing the sameEmailAlert and 
     * returning the execution as we don't want two entries with same email id.
     * If not present then pushing email in array.
     */
    if(emailArr.includes(email)){
        sameEmailAlert.style.display = 'block';
        return;
    }
    emailArr.push(email);

    /**
     * Getting all the values inserted in form by user
     * and then passing it to createAndInsertTableRow() method present in tableRow.js which will
     * create the table row and insert it in the html page
     */
    let name = document.getElementById('name').value;
    let website = document.getElementById('website').value;
    let imageLink = document.getElementById('imageLink')?.value;
    let gender = document.querySelector('input[name="gender"]:checked')?.value;

    //this will contain all the html elements which are checked
    let skillsSelected = document.querySelectorAll('input[name="lang"]:checked');
    //this converts those html elements into values and then inserting into the array
    //if user has selected Java, HTML then skills array will contain [Java, HTML]
    let skills = Array.from(skillsSelected, skill => skill.value);

    let table = document.getElementById('tableBody');

    createAndInsertTableRow(table, name, email, website, imageLink, gender, skills);

}