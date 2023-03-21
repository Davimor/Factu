import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';
import { GoogleLogin } from '@react-oauth/google';
import jwt_decode from "jwt-decode";
import { useGoogleLogin } from '@react-oauth/google';
import  axios  from 'axios';

function App() {

    const login = useGoogleLogin({
        onSuccess: async response => {
            try {
                const data = await axios.get("https://www.googleapis.com/auth/userinfo", {
                    headers: {
                        "Authorization": `Bearer ${response.access_token}`
                    }
                });
                console.log(data);
            } catch (err) {
                console.log(err);
            }
        }
    });

    return (
        //<Layout>
        //    <Routes>
        //        {AppRoutes.map((route, index) => {
        //            const { element, ...rest } = route;
        //            return <Route key={index} {...rest} element={element} />;
        //        })}
        //        <a>Test</a>
        //    </Routes>
        //</Layout>

        //<div className="container">
        //    <GoogleLogin
        //        onSuccess={credentialResponse => {
        //            //console.log(credentialResponse);
        //            console.log(jwt_decode(credentialResponse.credential));
        //        }}
        //        onError={() => {
        //            console.log('Login Failed');
        //        }}
        //    />
        //</div>

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
    );
}


    export default App;