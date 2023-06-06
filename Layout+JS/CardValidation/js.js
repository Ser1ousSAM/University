number = document.getElementsByClassName('number-of-card')
newCardNumber = document.getElementsByClassName('new-card-number-container')
ownerName = document.getElementsByClassName('card-owner-name')
newCardOwnerName = document.getElementsByClassName('new-card-owner-name')
newCardTerm = document.getElementsByClassName('new-card-term')
newCvv = document.getElementsByClassName('chip-span')

function Validation(cvv, newDate, newYear){
    for(let i=0; i<number.length; ++i) {
        if (newCardNumber[i].value==""){
            alert("Incorrect Number")
            return false
        }
    }
    if(ownerName[0].value==""){
        alert("Incorrect name")
        return false
    }
    if(newDate < new Date().getMonth() + 1 && newYear <= new Date().getFullYear() % 100) {
        alert('Incorrect card term')
        return false
    }
    if(cvv==""){
        alert("Incorrect cvv")
        return false
    }
    return true
}

function SubmitForm(e) {
    e.preventDefault()
    const newDate = document.getElementsByClassName('card-month')[0].value
    const newYear = document.getElementsByClassName('card-year')[0].value % 100
    const cvv = document.getElementsByClassName('newCvv')[0].value
    if (!Validation(cvv, newDate, newYear)) {
        return
    }

    for(let i=0; i<number.length; ++i) {
        console.log(number[i].value)
        newCardNumber[i].innerHTML = number[i].value
    }
    newCardOwnerName[0].innerHTML = ownerName[0].value.toUpperCase()

    newCardTerm[0].innerHTML = newDate + "/" + newYear

    newCvv[0].innerHTML = cvv
    console.log(newCvv)
}