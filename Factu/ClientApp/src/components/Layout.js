import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import PropTypes from 'prop-types';

export const Layout = ({ children}) => {

    return (
        <div>
            <NavMenu />
            <Container>
                {children}
            </Container>
        </div>
    );
}
