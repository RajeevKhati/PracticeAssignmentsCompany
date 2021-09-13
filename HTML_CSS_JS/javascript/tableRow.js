function createAndInsertTableRow(table, name, email, website, imageLink, gender, skills){
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
    if(skillsHtml.length===0)
        skillsHtml = 'No skill';
    firstCell.insertAdjacentHTML('beforeend', skillsHtml);

    secondCell.innerHTML = imageHtml;
}

export { createAndInsertTableRow };