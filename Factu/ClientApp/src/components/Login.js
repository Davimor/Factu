﻿import React, { Component, useEffect } from 'react';
import { Route, Routes, useNavigate } from 'react-router-dom';
import PropTypes from 'prop-types';
import { useGoogleLogin } from '@react-oauth/google';


export const Login = ({ setToken }) => {

    const navigate = useNavigate();

    const setLogin = async (response) => {
        console.log(response);

        const apires = await fetch("/api/user/Login?access_token=" + response.access_token);
        
        if (apires.ok) {
            const data = await apires.json();
            localStorage.setItem('userInfo', JSON.stringify(response.access_token));
            setToken(response.access_token);
        }
    }

    const login = useGoogleLogin({
        onSuccess: response => {
            setLogin(response);
        }
    });

    useEffect(() => {
        if (localStorage.getItem('userInfo') != null) {
            setToken(localStorage.getItem('userInfo'));
        }
    });

    return (<div>
        <section className="vh-100">
            <div className="container py-5 h-100">
                <div className="row d-flex align-items-center justify-content-center h-100">
                    <div className="col-md-8 col-lg-7 col-xl-6">
                        <img src={'https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.svg'} className="img-fluid" />
                    </div>
                    <div className="col-md-7 col-lg-5 col-xl-5 offset-xl-1">
                        <form>
                            <button type="button" className="btn btn-primary btn-lg btn-block" onClick={() => login()}>!Accede!</button>
                        </form>
                    </div>
                </div>
            </div>
        </section>
    </div>);
}

Login.propTypes = {
    setToken: PropTypes.func.isRequired
};