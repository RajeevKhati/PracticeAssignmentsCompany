function createAndInsertTableRow(table, name, email, website, imageLink, gender, skills){
    //Removing 'No Data' row
    let firstRow = table.rows[0];
    if(firstRow.cells[0].innerHTML === "No Data"){
        firstRow.remove();
    }

    //-1 refers to adding a new row at the end of all rows of the table
    let newRow = table.insertRow(-1);

    //inserting columns in a row, here we're inserting 2 columns
    let firstCell = newRow.insertCell(0);
    let secondCell = newRow.insertCell(1);

    //forming required html to insert into the table columns
    let nameHtml = `<div>${name}</div>`;
    let emailHtml = `<div>${email}</div>`;
    let websiteHtml = `<div><a href="${website}" target="_blank">${website}</a></div>`;
    let imageHtml = `<img src="${imageLink}" onerror="this.onerror=null;this.src='../image/defaultUser.jpg';">`;
    let genderHtml = `<div>${gender}</div>`;

    /**
     * skills array will have the skills selected by user
     * we're traversing this array and appending the values from skills array inside skillsHtml variable
     * so skillsHtml will look like Java, Html as per the selection of skills by user.
     */
    let skillsHtml = '';
    for(let i=0; i<skills.length; i++){
        skillsHtml+=skills[i];
        if(i!==skills.length-1)
            skillsHtml+=", ";
    }

    /**
     *  inserting html inside first column of the row
     * 'beforeend' makes sure rows added must be at the end of all rows
     * */
    firstCell.insertAdjacentHTML('beforeend', nameHtml);
    firstCell.insertAdjacentHTML('beforeend', emailHtml);
    firstCell.insertAdjacentHTML('beforeend', websiteHtml);
    firstCell.insertAdjacentHTML('beforeend', genderHtml);

    /**
     * If user doesn't select any skills then we'll show "Don't have rquired skills" in his/her profile
     */
    if(skillsHtml.length===0)
        skillsHtml = 'Don\'t have required skills';
    firstCell.insertAdjacentHTML('beforeend', skillsHtml);

    //adding image to second column of the row
    secondCell.innerHTML = imageHtml;
}

export { createAndInsertTableRow };