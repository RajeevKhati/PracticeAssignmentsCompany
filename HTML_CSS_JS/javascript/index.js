import {validateFormElements} from './validation.js';
import {createAndInsertTableRow} from './tableRow.js'

let alert = document.querySelector('#alert');
alert.addEventListener('animationend', ()=>{
    alert.style.display = 'none';
});

let emailArr = new Array();

let studentForm = document.getElementById('studentForm');
studentForm.addEventListener('submit', enrollStudent);

function enrollStudent(event){
    event.preventDefault();
    let isValid = validateFormElements();
    if(!isValid){
        return;
    }

    let email = document.getElementById('email').value;
    if(emailArr.includes(email)){
        alert.style.display = 'block';
        return;
    }
    emailArr.push(email);

    let name = document.getElementById('name').value;
    let website = document.getElementById('website').value;
    let imageLink = document.getElementById('imageLink').value;
    let gender = document.querySelector('input[name="gender"]:checked')?.value;

    let skillsSelected = document.querySelectorAll('input[name="lang"]:checked');
    let skills = Array.from(skillsSelected, skill => skill.value);

    let table = document.getElementById('tableBody');

    createAndInsertTableRow(table, name, email, website, imageLink, gender, skills);

}