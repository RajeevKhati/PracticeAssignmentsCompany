let studentForm = document.getElementById('studentForm');
studentForm.addEventListener('submit', enrollStudent);




function enrollStudent(event){
    event.preventDefault();
    let name = document.getElementById('name').value;
    let email = document.getElementById('email').value;
    let website = document.getElementById('website').value;
    let imageLink = document.getElementById('imageLink').value;
    let gender = document.querySelector('input[name="gender"]:checked')?.value;
    let skillsSelected = document.querySelectorAll('input[name="lang"]:checked');
    let skills = Array.from(skillsSelected, skill => skill.value);

    let table = document.getElementById('tableBody');
    //-1 refers to adding a new row at the end of table
    let newRow = table.insertRow(-1);

    let firstCell = newRow.insertCell(0);
    let secondCell = newRow.insertCell(1);

    let nameHtml = `<div>${name}</div>`;
    let emailHtml = `<div>${email}</div>`;
    let websiteHtml = `<div><a href="${website}" target="_blank">${website}</a></div>`;
    let imageHtml = `<img src="${imageLink}">`;
    let genderHtml = `<div>${gender}</div>`;
    let skillsHtml = '';
    for(let i=0; i<skills.length; i++){
        skillsHtml+=skills[i];
        if(i!==skills.length-1)
            skillsHtml+=", ";
    }
    firstCell.insertAdjacentHTML('beforeend', nameHtml);
    firstCell.insertAdjacentHTML('beforeend', emailHtml);
    firstCell.insertAdjacentHTML('beforeend', websiteHtml);
    firstCell.insertAdjacentHTML('beforeend', genderHtml);
    firstCell.insertAdjacentHTML('beforeend', skillsHtml);

    secondCell.innerHTML = imageHtml;

}

// let clearForm = document.getElementById('clearForm');
// clearForm.addEventListener('click', clearEntry);

// function clearEntry(event){
//     event.preventDefault();
//     studentForm.reset();
// }