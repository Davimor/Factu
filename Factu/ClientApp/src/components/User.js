import React, { Component } from 'react';

export class User extends Component {

    constructor(props) {
        super(props);
        this.access_token = props.access_token;
    }
}