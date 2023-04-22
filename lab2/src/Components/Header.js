import React, { Component } from "react";
import { Navbar, Nav, Container } from "react-bootstrap";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Main from "../Pages/Main";
import Classes from "../Pages/Classes";
import Teachers from "../Pages/Teachers";
import Students from "../Pages/Students";

let logouturl = 'http://localhost:8080/realms/schoolRealm/protocol/openid-connect/logout?';

export default class Header extends Component {

    render() {
        return (
            <div>
                <Navbar fixed="top" collapseOnSelect expand="md" bg="dark" variant="dark">
                    <Container>
                        <Navbar.Brand href="/">
                            <img
                                src="logo2.jpg"
                                height="40"
                                width="40"
                                className="d-inline-block align-top"
                                alt="Logo"
                            />
                        </Navbar.Brand>
                        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                        <Navbar.Collapse id="responsive-navbar-nav">
                            <Nav className="mr=auto">
                                <Nav.Link href="/teachers">Список учителей</Nav.Link>
                                <Nav.Link href="/students">Список учеников</Nav.Link>
                                <Nav.Link href="/classes">Список классов</Nav.Link>
                                <Nav.Link href={logouturl}>Выход</Nav.Link>
                            </Nav>
                        </Navbar.Collapse>
                    </Container>
                </Navbar>
                <Router>
                    <Routes>
                        <Route expct path="/" Component={Main} />
                        <Route expct path="/teachers" Component={Teachers} />
                        <Route expct path="/students" Component={Students} />
                        <Route expct path="/classes" Component={Classes} />
                    </Routes>
                </Router>
            </div>
        )
    }
}