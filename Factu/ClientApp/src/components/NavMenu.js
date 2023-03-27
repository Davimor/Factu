import React, { Component, useContext, useState } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import PropTypes from 'prop-types';
import { googleLogout } from '@react-oauth/google';
import { UserContext } from '../context/UserContext';



export const NavMenu = () => {

    const { user, setUser } = useContext(UserContext);
    const [collapsed, setCollapsed] = useState(true);

    const toggleNavbar = () => {
        setCollapsed(!collapsed);
    };

    const logout = () => {
        localStorage.removeItem('userInfo');
        setUser({
            Id: null,
            Email: "",
            Name: "",
            Apellido: "",
            Fulllname: "",
            Logged: false,
            Token: ""
        });
        googleLogout();
    }

    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
                <NavbarBrand tag={Link} to="/">{`Dakal`}</NavbarBrand>
                <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
                    <ul className="navbar-nav flex-grow">
                        <NavItem>
                            <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                        </NavItem>
                        <NavItem style={{ 'display': 'inline' }}>
                            <NavLink tag={Link} className="text-dark" >{user.Email} <a href="#" className="text-dark" onClick={() => logout()}><small>(Cerrar Sesion)</small></a></NavLink>
                        </NavItem>
                    </ul>
                </Collapse>
            </Navbar>
        </header>
    );

}

