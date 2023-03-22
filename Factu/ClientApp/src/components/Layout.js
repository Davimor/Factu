import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import PropTypes from 'prop-types';

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div>
                <NavMenu setToken={this.props.setToken} />
                <Container>
                    {this.props.children}
                </Container>
            </div>
        );
    }
}
