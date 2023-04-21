import React, { Component } from "react";

var UpdateTable = true;
var page = 0;
var line = 0;

export default class Students extends Component {

  constructor(props) {
    super(props);
    this.state = {
      idDelete: -1,
    };
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleClick = this.handleClick.bind(this);
    this.handleSearch = this.handleSearch.bind(this);
    this.handleScroll = this.handleScroll.bind(this);
  }

  handleScroll(event) {
    let heiscrol = page * 320 + 320 * (page-1)*1.4
    if (event.target.scrollTop > heiscrol) {
      console.log(event.target.scrollTop);
      UpdateTable = true;
      this.getStudent();
    }
  }

  // CHECK
  handleSearch(event) {
    let search = document.getElementById("Sfiltr").value;
    fetch("http://localhost:80/api/pupil/Filter/"+search, {
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
    document.querySelector("table").onclick = (event) => {
      let cell = event.target;
      if (cell.tagName.toLowerCase() === "td") {
        let i = cell.parentNode.rowIndex;
        let id = document.getElementById("TabStudent").rows[i].cells[0].textContent;
        switch (cell.cellIndex) {
          case 5:
            if (window.confirm("Вы хотите удалить ученика - " + id + "?")) {
              fetch("http://localhost/api/Pupil?pupilId=" + id, {
                method: "DELETE",
                headers:
                {
                  "authorization": `Bearer ${window.ttoken.tok}`,
                },

              })
                .then((response) => {alert("Ученик удален"); window.location.reload()})
                .catch((error) => alert("Вы не можете удалять, обратитесь к администратору"));
            }
            break;
          case 4:
            fetch("http://localhost/api/Pupil/" + id + "/Class", {
              method: "GET",
              headers:
              {
                "authorization": `Bearer ${window.ttoken.tok}`,
              },
            })
              .then((response) => response.json())
              .then((data) => document.getElementById("TabStudent").rows[i].cells[4].textContent = data.number + data.letter)
              .catch((error) => {
                if (window.confirm("У ученика - " + id + " нет класса.\nХотите добавить его в класс? "))
                  window.location.assign('http://localhost:3000/classes');
              });
            break;
          default:
            console.log("Отмена удаления");
            break;
        }
      } else return;
    };
  }

  handleSubmit(event) {
    let student =
    {
      name: document.getElementById("name").value,
      surName: document.getElementById("family").value,
      middleName: document.getElementById("patronymic").value
    };
    if (student.surName !== "" && student.name !== "" && student.middleName !== "") {
      console.log(JSON.stringify(student));
      fetch("http://localhost:80/api/Pupil",
        {
          method: "POST",
          headers:
          {
            "authorization": `Bearer ${window.ttoken.tok}`,
            "Content-Type": "application/json; charset=utf-8",
          },
          body: JSON.stringify(student),
        })
        .then((response) => alert("Новый ученик добавлен"))
        .catch((error) => alert("Вы не можете добавлять, обратитесь к учителю или администратору"));
    }
    else {
      alert("Заполните все поля");
      event.preventDefault();
    }
    return false;
  }

  fillingtable(data) {
    let table = document.querySelector("#TabStudent");
    //console.log(data);
    let mySet = new Set(["id", "surName", "name", "middleName"]);

    let i = 0;
    for (let line of data) {
      let tr = document.createElement("tr");

      for (let item of mySet) {
        let td = document.createElement("td");
        td.textContent = data[i][item];
        tr.appendChild(td);
      }
      table.appendChild(tr);
      let td = document.createElement("td");
      tr.appendChild(td);
      td = document.createElement("td");
      td.textContent = "X";
      td.addEventListener("onClick", this.handleClick());
      tr.appendChild(td);
      i++;
    }
  }

  getStudent() {
    if (UpdateTable) {
      fetch('http://localhost/api/Pupil/Pagination?from=' + line + '&to=' + (line + 29), {
        method: "GET",
        headers:
        {
          "authorization": `Bearer ${window.ttoken.tok}`,
        },
      })
        .then((response) => response.json())
        .then((data) => this.fillingtable(data))
        .catch((error) => console.log(error));
      UpdateTable = false;
      page = page + 1;
      line = line + 30;
    }
  }

  render() {
    return (
      <div>
        <div className="mainblock">
          <h1 className="head" align="center">Список учеников</h1>
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
            <table id="TabStudent" className="table table-bordered">
              <thead>
                <tr>
                  <th className="delete" scope="col">ID</th>
                  <th scope="col">Фамилия</th>
                  <th scope="col">Имя</th>
                  <th scope="col">Отчество</th>
                  <th className="delete" scope="col">Класс</th>
                  <th className="delete" scope="col">Удалить</th>
                </tr>
              </thead>
            </table>
          </div>
          {this.getStudent()}
        </div>
        <div className="blockadd">
          <h1 className="head" align="center">Добавить ученика</h1>
          <form className="addform" onSubmit={this.handleSubmit}>
            <div className="row gy-3">
              <div className="col-14">
                <label>Фамилия</label>
                <input className="form-control" type="family" id="family" />
              </div>
              <div className="col-14">
                <label>Имя</label>
                <input className="form-control" type="name" id="name" />
              </div>
              <div className="col-14">
                <label>Отчество</label>
                <input
                  className="form-control"
                  type="patronymic"
                  id="patronymic"
                />
              </div>
              <div className="row gy-2">
                <input
                  type="submit"
                  className="sub btn btn-dark btn-lg"
                  value="Добавить"
                />
              </div>
            </div>
          </form>
        </div>
      </div>
    );
  }
}
