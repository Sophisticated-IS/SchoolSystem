import React, { Component } from "react";
import { Navbar, Nav, Container } from "react-bootstrap";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Main from "../Pages/Main";
import Authorization from "../App";
import Classes from "../Pages/Classes";
import Teachers from "../Pages/Teachers";
import Students from "../Pages/Students";

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
                                <Nav.Link href="/authorization">
                                    Вход
                                </Nav.Link>
                            </Nav>
                        </Navbar.Collapse>
                    </Container>
                </Navbar>
                <Router>
                    <Routes>
                        <Route expct path="/" element={<Main />} />
                        <Route expct path="/teachers" element={<Teachers />} />
                        <Route expct path="/students" element={<Students />} />
                        <Route expct path="/classes" element={<Classes />} />
                        <Route expct path="/authorization" element={<Authorization />} />
                    </Routes>
                </Router>
            </div>
        )
    }
}