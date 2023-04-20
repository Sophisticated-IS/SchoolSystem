import React, { Component } from 'react'

var UpdateTable = true;

export default class Classes extends Component {

  constructor(props) {
    super(props);
    this.state = {
    }
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleSubmit(event) {
    let idStudent = document.getElementById('idStudent').value;
    let idClass = document.getElementById('idClass').value;
    if (idClass !== "" && idStudent !== "") {
      fetch("http://localhost/api/Pupil?pupilId=" + idStudent + "&classId=" + idClass, {
        method: "PUT",
        headers:
        {
          "authorization": `Bearer ${window.ttoken.tok}`,
        },
      })
        .then(response => {
          if (window.confirm("Ученик - " + idStudent + " добавлен в класс " + idClass + "\nХотите посмотреть список учеников?"))
            window.location.assign('http://localhost:3000/students');
        })
        .catch(error => console.log(error));
      event.preventDefault();
    }
    else alert("Заполните все поля");
  }

  fillingtable(data) {
    let table = document.querySelector('#TabClasses');
    let mySet = new Set(["id", "number", "letter"]);

    let i = 0
    for (let line of data) {
      let tr = document.createElement('tr');

      for (let item of mySet) {
        let td = document.createElement('td');
        td.textContent = data[i][item];
        tr.appendChild(td);
      }
      table.appendChild(tr);
      i++;
    }
  }

  getClass() {
    if (UpdateTable) {
      fetch('http://localhost:80/api/Classes', {
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
    }
  }

  render() {
    return (
      <div>
        <div className='mainblockClass'>
          <h1 className="head" align="center">Список классов</h1>
          <div className="scrollbar">
            <table id="TabClasses" className="table table-bordered">
              <thead>
                <tr>
                  <th className="delete" scope="col">ID</th>
                  <th scope="col">Параллель</th>
                  <th scope="col">Буква</th>
                </tr>
              </thead>
            </table>
          </div>
          {this.getClass()}
        </div>
        <div className='blockaddClass'>
          <h1 className="head" align="center">Добавить ученика в класс</h1>
            <form className='form-inline addform' onSubmit={this.handleSubmit}>
              <div className="row">
                <div className="col-6">
                  <label>id Ученика</label>
                  <input className="form-control" type='number' id='idStudent' />
                </div>
                <div className="col-3">
                  <label>id Класса</label>
                  <input className="form-control" type='number' id='idClass' />
                </div>
                <div className="baton col">
                  <input type="submit" className="btn btn-dark" value="Добавить" />
                </div>
              </div>
            </form>
        </div>
      </div>
    )
  }
}