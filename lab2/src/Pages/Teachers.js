import React, { Component } from 'react'

var UpdateTable = true;
var page = 0;
var line = 0;

export default class Teachers extends Component {

  constructor(props) {
    super(props);
    this.state = {
    }
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleClick = this.handleClick.bind(this);
    this.handleSearch = this.handleSearch.bind(this);
    this.handleScroll = this.handleScroll.bind(this);
  }

  handleScroll(event) {
    let heiscrol = page * 320 + 320 * (page-1)*1.4
    if (event.target.scrollTop > heiscrol) {
      UpdateTable = true;
      this.getTeacher();
    }
  }

  // CHECK
  handleSearch(event) {
    let search = document.getElementById("Sfiltr").value;
    fetch("http://localhost:80/api/Teacher/Filter/" + search, {
      method: "GET",
      headers:
      {
        "authorization": `Bearer ${window.ttoken.tok}`,
      }
    })
      .then((response) => console.log(response.json()))
      // .then((response) => response.json())
      // .then((data) => this.fillingtable(data))
      .catch((error) => console.log(error));
    event.preventDefault();
  }

  handleClick(event) {
    document.querySelector('table').onclick = (event) => {
      let cell = event.target;
      if (cell.tagName.toLowerCase() !== 'td' || cell.cellIndex !== 5)
        return;
      let i = cell.parentNode.rowIndex;
      let id = document.getElementById('TabTeacher').rows[i].cells[0].textContent;
      if (window.confirm("Вы хотите удалить учителя - " + id + "?")) {
        fetch('http://localhost/api/Teacher?teacherId=' + id, {
          method: 'DELETE',
          headers:
          {
            "authorization": `Bearer ${window.ttoken.tok}`,
          },
        })
          .then(response => { console.log(response); window.location.reload(); })
          .catch((error) => alert("Вы не можете удалить запись, обратитесь к администратору"))
      }
      else {
        console.log("Отмена удаления")
      }

    }
  }

  handleSubmit(event) {
    let teacher = {
      name: document.getElementById('name').value,
      surName: document.getElementById('family').value,
      middleName: document.getElementById('patronymic').value,
      comment: document.getElementById('comment').value
    };
    if (teacher.surName !== "" && teacher.name !== "" && teacher.middleName !== "" && teacher.comment !== "") {
      console.log(JSON.stringify(teacher));
      fetch('http://localhost:80/api/Teacher', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json; charset=utf-8',
          "authorization": `Bearer ${window.ttoken.tok}`,
        },
        body: JSON.stringify(teacher)
      })
        .then((response) => alert("Новый учитель добавлен"))
        .catch((error) => alert("Вы не можете добавлять, обратитесь к учителю или администратору"));
      // .then(response => console.log(response))
      // event.preventDefault();
    }
    else {
      alert("Заполните все поля");
      event.preventDefault();
    }
    return false;
  }

  fillingtable(data) {
    let table = document.querySelector('#TabTeacher');
    let mySet = new Set(["id", "surName", "name", "middleName", "comment"]);

    let i = 0
    for (let line of data) {
      let tr = document.createElement('tr');
      table.appendChild(tr);
      for (let item of mySet) {
        let td = document.createElement('td');
        td.textContent = data[i][item];
        tr.appendChild(td);
      }
      // let img1 = document.createElement('img');
      // img1.width = 20;
      // img1.height = 20;
      // img1.src = "delete1.png";
      // img1.addEventListener('onClick', this.handleClick())
      // tr.appendChild(img1);
      let td = document.createElement('td');
      td.textContent = "X";
      td.addEventListener('onClick', this.handleClick())
      tr.appendChild(td);
      i++;
    }
  }

  getTeacher() {
    if (UpdateTable) {
      fetch('http://localhost/api/Teacher/Pagination?from=' + line + '&to=' + (line + 29), {
        method: "GET",
        headers:
        {
          "authorization": `Bearer ${window.ttoken.tok}`,
        },
      })
        .then(response => response.json())
        .then(data => this.fillingtable(data))
        .catch(error => console.log(error))
      UpdateTable = false;
      page = page + 1;
      line = line + 30;
    }
  }

  render() {
    return (
      <div>
        <div className="mainblock">
          <h1 className="head" align="center">Список учителей</h1>
          <form className='form-inline' onSubmit={this.handleSearch}>
            <div className="row">
              <div className="col">
                <input className="form-control" type='text' id='Sfiltr' />
              </div>
              <div className="col-1">
                <input type="submit" className="btn btn-dark search" value="Поиск" />
              </div>
            </div>
          </form>
          <div className="scrollbar" onScroll={this.handleScroll}>
            <table id="TabTeacher" className="table table-hover table-bordered">
              <thead>
                <tr>
                  <th className="delete" scope="col">ID</th>
                  <th scope="col">Фамилия</th>
                  <th scope="col">Имя</th>
                  <th scope="col">Отчество</th>
                  <th scope="col">Телефон</th>
                  <th className="delete" scope="col">Удалить</th>
                </tr>
              </thead>
            </table>
          </div>
          {this.getTeacher()}
        </div>
        <div className="blockadd">
          <h1 className="head" align="center">Добавить учителя</h1>
          <form className='addform' onSubmit={this.handleSubmit}>
            <div className="row gy-3">
              <div className="col-14">
                <label>Фамилия</label>
                <input className="form-control" type='text' id='family' />
              </div>
              <div className="col-14">
                <label>Имя</label>
                <input className="form-control" type='text' id='name' />
              </div>
              <div className="col-14">
                <label>Отчество</label>
                <input className="form-control" type='text' id='patronymic' />
              </div>
              <div className="col-14">
                <label>Комментарий</label>
                <input className="form-control" type='text' id='comment' />
              </div>
              <div className='row gy-2'>
                <input type="submit" className="sub btn btn-dark btn-lg" value="Добавить" />
              </div>
            </div>
          </form>
        </div>
      </div>
    )
  }
}

