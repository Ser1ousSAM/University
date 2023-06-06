
const description_task = document.getElementById("description-task");
const prioritise = document.querySelector('#prioritise');
const add_tas_btn = document.getElementById("add-task");
const todo_list_waiting_complete = document.querySelector(".todo-list");
const todo_list_completed = document.querySelector('.todo-list-completed');

let tasks = [];

let todoListItems = [];

!localStorage.tasks ? tasks = [] : tasks = JSON.parse(localStorage.getItem('tasks'));

function Task (description, pr) { //функция конструктор для инициализации объектов
    this.description = description;
    this.pr = +pr;
    this.complited = false;
}

const updateLocalStorage = () => {
    localStorage.setItem('tasks', JSON.stringify(tasks));
}

const filterTasks = () => {
    const activeTasks  = tasks.length && tasks.filter(item=> item.complited == false);
    const completedTasks  = tasks.length && tasks.filter(item=> item.complited == true);
    tasks = [...activeTasks,...completedTasks];
}

const addTemplateItemTask = (task, index)  =>{
    return `
        <div class='todoItem ${task.complited ? 'checked': ''}' draggable='true' ondragstart=setDraggetIndex(${index})>
            <p class ='description'> ${task.description}</p>
            <div>
                <input onclick='completeTask(${index})' type='checkbox' class ='btn-complete' ${task.complited ? 'checked': ''}>${task.pr}
                <button onclick='deleteTask(${index})' class='btn-delete'>Delete</button>
            </div>
        </div>`;
}

const addCompletedItemTask = (task, index)  =>{
    return `
        <div class='todoItem ${task.complited ? 'checked': ''}' draggable = 'true' ondragstart=setDraggetIndex(${index})>
            <p class ='description'> ${task.description}</p>
            <div>
                <input onclick='completeTask(${index})' type='checkbox' class ='btn-complete' ${task.complited ? 'checked': ''}>
                <button onclick='deleteTask(${index})' class='btn-delete'>Delete</button>
            </div>
        </div>`;
}

const fillHtmlList = () => {
    todo_list_waiting_complete.innerHTML = '';
    todo_list_completed.innerHTML = '';
    if (tasks.length > 0)
    {
        todo_list_waiting_complete.innerHTML = '<h2>My tasks</h2>';
        todo_list_completed.innerHTML = '<h2>My completed tasks</h2>';
        filterTasks();
        sortTask();
        tasks.forEach((item, index) => {
            if(!item.complited)
                todo_list_waiting_complete.innerHTML += addTemplateItemTask(item, index);
            else
                todo_list_completed.innerHTML += addCompletedItemTask(item, index);
        });
        todoListItems = document.querySelectorAll('.todoItem');
    }
}

function sortTask(){
    for (let i = 0; i < tasks.length; i++)
    {
        for (let j = 0; j < tasks.length - i - 1; j++)
        {
            if (tasks[j].pr > tasks[j + 1].pr)
            {
                let t = tasks[j];
                tasks[j] = tasks[j + 1];
                tasks[j + 1] = t;
            }
        }
    }
}

let draggedIndex = 0;
fillHtmlList();

function setDraggetIndex(index){
    draggedIndex = index;
}

var is_destination_to_waiting = false;
var is_destination_to_completed = false;

todo_list_waiting_complete.addEventListener('dragstart', (evt)=>{
    is_destination_to_waiting = false;
    is_destination_to_completed = true;
    evt.target.classList.add('selected');
})

todo_list_waiting_complete.addEventListener('dragover', (evt)=>{
    evt.preventDefault();
    evt.target.classList.add('selected');
})

todo_list_waiting_complete.addEventListener('drop', (evt)=>{
    evt.preventDefault();
    if(is_destination_to_waiting){
        evt.target.classList.add('selected');
        completeTask(draggedIndex);
    }
})

todo_list_waiting_complete.addEventListener('dragend', (evt)=>{
    evt.target.classList.add('selected');
})

todo_list_completed.addEventListener('dragstart', (evt)=>{
    evt.target.classList.add('selected');
    is_destination_to_waiting = true;
    is_destination_to_completed = false;
})

todo_list_completed.addEventListener('dragover', (evt)=>{
    evt.preventDefault();
    evt.target.classList.add('selected');
})

todo_list_completed.addEventListener('drop', (evt)=>{
    evt.preventDefault();
    if (is_destination_to_completed){
        evt.target.classList.add('selected');
        completeTask(draggedIndex);
    }
})

todo_list_completed.addEventListener('dragend', (evt)=>{
    evt.target.classList.add('selected');
})



function pushTask(){
    tasks.push(new Task(description_task.value, prioritise.value));
    updateLocalStorage();
    sortTask();
    fillHtmlList();
    description_task.value = '';
}

description_task.addEventListener('keydown', (event) => {
    var name = event.key;
    if (name === 'Enter') {
        if (description_task.value !=""){
            pushTask();
        }
    }
  }, false);

add_tas_btn.addEventListener ('click', () => {
    if (description_task.value !=""){
        pushTask();
    }
    description_task.focus();
});

prioritise.addEventListener('change', () =>{
    if (prioritise.value<1 || prioritise.value>9){
        if (prioritise.value>9){
            prioritise.value = 9;
        }
        else{
            prioritise.value = 1;
        }
    }
});

prioritise.addEventListener('input', () =>{
    if (prioritise.value<1 || prioritise.value>9){
        if (prioritise.value>9){
            prioritise.value = 9;
        }
        else{
            prioritise.value = 1;
        }
        prioritise.select();
    }
});

const completeTask = (index) => {
    tasks[index].complited=!tasks[index].complited;
    if (tasks[index].complited)
        todoListItems[index].classList.add('checked');

    else todoListItems[index].classList.remove('checked');
    updateLocalStorage();
    sortTask();
    fillHtmlList();
}

const deleteTask = index => {
    todoListItems[index].classList.add('deletion');
    setTimeout(() => {
        tasks.splice(index, 1);
    updateLocalStorage();
    fillHtmlList();
    },
    500);   
}