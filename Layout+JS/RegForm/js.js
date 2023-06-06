const block = document.querySelector('.block');
const nameUser = document.querySelector('#nameUser');
const email = document.querySelector('#emailUser');
const telephone = document.querySelector('#phoneUser');
const age = document.querySelector('#ageUser');
const education = document.querySelector('#education');
const btn = document.querySelector('.check-butt')
const gender = document.getElementsByName('gender');
const divGender = document.querySelector('.maleUser');
const passUser = document.querySelector('#passUser');
const reppassUser = document.querySelector('#reppassUser');


function show() {
    
    block.innerHTML = '<h1>Resault Form</h1>';
    block.innerHTML += `<p>Your second name: ${nameUser.value}</p>`;
    block.innerHTML += `<p>Your email: ${email.value}</p>`;
    for (var el of gender)
        if (el.checked)
            block.innerHTML += `<p>Your gender: ${el.value}</p>`; 

    block.innerHTML += `<p>Your age: ${age.value}</p>`;
    block.innerHTML += `<p>Your education: ${education.value}</p>`;
    block.innerHTML += `<p>Your phone: ${telephone.value}</p>`;    
}

let flag = true;

btn.addEventListener('click', check = ()=> {
    if ((nameUser.value == '') || (email.value == '')
        || (telephone.value == '') || (age.value == '') || (gender[0].checked == false && gender[1].checked == false) || passUser.value != reppassUser.value ||
         passUser.value == '' || reppassUser.value == '' || passUser.value.length < 5) {
        if (nameUser.value == '')
            nameUser.classList.add('invalid');

        if (email.value == '') 
            email.classList.add('invalid');

        if (telephone.value == '')
            telephone.classList.add('invalid');

        if (age.value == '') 
            age.classList.add('invalid');

        if((gender[0].checked == false) && (gender[1].checked == false))
            divGender.classList.add('invalidRadio');
        
        if(passUser.value != reppassUser.value || passUser.value == '' || reppassUser.value == '' || passUser.value.length < 5){
            if(passUser.value.length<5){
                passUser.classList.add('invalid');
            }
            if(reppassUser.value.length<5){
                reppassUser.classList.add('invalid');
            }
        }

    }

    else {
        show();
        flag = false;
        nameUser.classList.remove('invalid');
        email.classList.remove('invalid');
        telephone.classList.remove('invalid');
        age.classList.remove('invalid');
        divGender.classList.remove('invalidRadio');
        passUser.classList.remove('invalid');
        reppassUser.classList.remove('invalid');
    }
});

nameUser.addEventListener('input', ()=> {
    const pattern = '^[a-zA-Z]{5,}$';
    let reg = new RegExp(pattern);
    let str = nameUser.value;

    if (reg.test(str) || str == '')
        nameUser.classList.remove('invalid');

    else nameUser.classList.add('invalid');
});

email.addEventListener('input', ()=> {
    const pattern = '^[a-zA-Z0-9.-_]+@[a-zA-Z]+[.][a-zA-Z]{2,4}$';
    let reg = new RegExp(pattern);
    let str = email.value;

    if (reg.test(str) || str == '')
        email.classList.remove('invalid');

    else email.classList.add('invalid');
});

telephone.addEventListener('input', ()=> {
    const pattern = /^[+][\d]{1}[\d]{2,3}[\d]{2,3}[\d]{2,3}[\d]{2,3}$/
    let reg = new RegExp(pattern);
    let str = telephone.value;

    if (reg.test(str) || str == '')
        telephone.classList.remove('invalid');

    else telephone.classList.add('invalid');
});

age.addEventListener('input', ()=> {
    if((age.value >= 16 && age.value <= 30) || age.value == '')
        age.classList.remove('invalid');
    else 
        age.classList.add('invalid');
});

passUser.addEventListener('input', ()=>{
    if (passUser.value != '')
        passUser.classList.remove('invalid');
    else
        passUser.classList.add('invalid');
})

reppassUser.addEventListener('input', ()=>{
    if (reppassUser.value != '')
        reppassUser.classList.remove('invalid');
    else
        reppassUser.classList.add('invalid');
})

let counter = 0;
const showTimer = () => {
    console.log(counter);
    counter++;
    
    if (flag) {
        setTimeout('showTimer()', 1000);
    }

    else {
        clearInterval('showTimer()')
    }

    if ((counter == 60) && ((nameUser.value == '') || (email.value == '')
    || (telephone.value == '') || (age.value == '') || ((gender[0].checked == false) || (gender[1].checked == false)))){
        window.alert("Вы не успели ввести данные в течении 60 секунд");
        counter = 0;

        nameUser.classList.remove('invalid');
        email.classList.remove('invalid');
        telephone.classList.remove('invalid');
        age.classList.remove('invalid');
        divGender.classList.remove('invalidRadio');
        passUser.classList.remove('invalid');
        reppassUser.classList.remove('invalid');

        nameUser.value = '';
        email.value = '';
        telephone.value = '';
        age.value = '';
        passUser.value='';
        reppassUser.value='';

        for (let i = 0; i < gender.length; i++) {
            gender[i].checked = false;
        }
    }
}

window.addEventListener('load', showTimer());